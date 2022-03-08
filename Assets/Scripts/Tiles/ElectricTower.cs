using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTower : TowerTile
{

    void Start()
    {
        InvokeRepeating("Shoot", 0, 5);
    }

    void Update()
    {

    }

    private void Shoot()
    {
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
    }
}
