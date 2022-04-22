using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    void Start()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        lifeManager = GameObject.Find("EnemyManager").GetComponent<LifeManager>();
        _enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        move();
        if (transform.position.y > 80)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 12)
        {
            _enemyManager.enemyList.Remove(this);
            for (int x = 0; x <= 10; x++)
            lifeManager.loseLife();
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            _enemyManager.enemyList.Remove(this);
            _moneyManager.killedBossEnemy();
            Destroy(gameObject);
        }
    }
}
