using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTower : TowerTile
{
   
    [SerializeField] GameObject electricAttack;
    static public new int cost = 150;


    void Start()
    {
        cost = 150;
        attackSpeed = 3.5f;
        _rangeIndicator.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        InvokeRepeating("Shoot", 0, attackSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && selected)
            upgrade();
    }

    private void Shoot()
    {
        StartCoroutine(Attack());
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count != 0)
             {
            foreach (Enemy enemy in enemyManager.enemyList)
            {
                float dist = Vector3.Distance(enemy.transform.position, transform.position);
                if (dist < 2.5)
                {
                    enemy.InvokeRepeating("TakeElectricDamage",0, 1);
                }
            }
        }
    }
    IEnumerator Attack()
    {
        electricAttack.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        electricAttack.SetActive(false);

    }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (tier < 5)
        {
            if (_moneyManager.makePurchase(2 *cost))
            {
                tier++;
                attackSpeed *= .8f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }
        }
        else if (tier == 55)
        {
            tier++;
            attackSpeed *= .5f;
            CancelInvoke();
            InvokeRepeating("Shoot", 0, attackSpeed);
        }
    }
}
