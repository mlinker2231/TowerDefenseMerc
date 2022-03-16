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
