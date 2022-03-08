using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : TowerTile
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
        if (enemyManager.enemyList.Count == 0)
        {
            
        }else
        {
            int count = enemyManager.enemyList.Count;
            Enemy currentEnemy = enemyManager.enemyList[0];
            currentEnemy.StartCoroutine("TakeSnipeDamage");
        }
    }
}
