using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] TMP_Text moneyText;

    private EnemySpawner enemySpawner;
    void Start()
    {
        moneyText.text = "$" + money;
        enemySpawner = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        
    }

    public bool buyTower(string tower)
    {

        if (tower.Equals("Electric"))
        {
            if (money >= 150)
            {
                money -= 150;
                moneyText.text = "$" + money;
                return true;
            }
            else
                return false;
        }
        else if (tower.Equals("Bomb"))
        {
            if (money >= 200)
            {
                money -= 200;
                moneyText.text = "$" + money;
                return true;
            }
            else
                return false;
        }
        else if (tower.Equals("Sniper"))
        {
            if (money >= 100)
            {
                money -= 100;
                moneyText.text = "$" + money;
                return true;
            }
            else
                return false;
        }
        else if(tower.Equals("basic"))
        {

            if (money >= 50)
            {
                money -= 50;
                moneyText.text = "$" + money;
                return true;
            }
            else
                return false;
        }

        return false;

    }
    public void killedEnemy()
    {
        money += 5;
        if (enemySpawner.level <= 29)
        money += (5 - (enemySpawner.level / 5));
        moneyText.text = "$" + money;
        

    }

}
