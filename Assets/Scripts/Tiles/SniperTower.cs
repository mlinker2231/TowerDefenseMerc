using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : TowerTile
{

    void Start()
    {
        InvokeRepeating("Shoot", 0, 5);
        _rangeIndicator.transform.localScale = new Vector3(50, 50, 50);
    }


    private void Shoot()
    {
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count == 0) return;
       
            foreach (Enemy enemy in enemyManager.enemyList)
            {
                if (!enemy.takingSnipeDamage)
                {
                    enemy.StartCoroutine("TakeSnipeDamage");
                    break;
                }
            }
        }
    
}
