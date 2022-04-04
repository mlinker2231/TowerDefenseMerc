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
  


    IEnumerator TakeSnipeDamage()
    {
        print(health + "b");
        takingSnipeDamage = true;
        _sniperDamage.SetActive(true);
        yield return new WaitForSeconds(1f);
        _sniperDamage.SetActive(false);
        health = health / 2;
        health -= 2;
        print(health + "a");
        takingSnipeDamage = false;
    }

}
