using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTower : TowerTile
{
   
    [SerializeField] GameObject electricAttack;
    void Start()
    {
        _rangeIndicator.transform.localScale = new Vector3(2, 2, 2);
        InvokeRepeating("Shoot", 0, 5);
    }

    void Update()
    {

    }

    private void Shoot()
    {
        
        electricAttack.SetActive(true);
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count != 0)
             {
            foreach (Enemy enemy in enemyManager.enemyList)
            {
                float dist = Vector3.Distance(enemy.transform.position, transform.position);
                if (dist < 2)
                {
                    enemy.InvokeRepeating("TakeElectricDamage",0, 1);
                }
            }
        }
        electricAttack.SetActive(false);
    }
}
