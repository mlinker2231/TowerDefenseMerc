using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : TowerTile
{
    static public int cost = 100;

    private float damage = .8f;
    private int totalAttackCount = 1;

    void Start()
    {
        attackSpeed = 5;
        InvokeRepeating("Shoot", 0, attackSpeed);
        _rangeIndicator.transform.localScale = new Vector3(50, 50, 50);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && selected)
            upgrade();
    }

    private void Shoot()
    {
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count == 0) return;
        for (int enemiesHit = 0; enemiesHit < totalAttackCount; enemiesHit++)
        {
            foreach (Enemy enemy in enemyManager.enemyList)
            {
                if (!enemy.takingSnipeDamage)
                {
                    if (enemy is BossEnemy)
                        enemy.StartCoroutine(enemy.TakeSnipeDamage(damage));
                    else
                        enemy.StartCoroutine(enemy.TakeSnipeDamage());
                    break;
                }
            }
        }
    }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (tier < 5)
        {
            if (_moneyManager.makePurchase(2* cost))
            {
                tier++;
                attackSpeed *= .9f;
                damage *= .875f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }
        }
        else if (tier == 5)
        {
            if (_moneyManager.makePurchase(2 * cost))
            {
                tier++;
                attackSpeed *= .5f;
                damage *= .65f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }
        }
    }
}
