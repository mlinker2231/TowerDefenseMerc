using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : TowerTile
{
    static public int cost = 100;

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
       
            foreach (Enemy enemy in enemyManager.enemyList)
            {
                if (!enemy.takingSnipeDamage)
                {
                    enemy.StartCoroutine("TakeSnipeDamage");
                    break;
                }
            }
        }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (_moneyManager.makePurchase(2 * cost))
        {
            attackSpeed *= .8f;
            CancelInvoke();
            InvokeRepeating("Shoot", 0, attackSpeed);
        }
    }
}
