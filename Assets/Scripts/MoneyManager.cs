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

  
    
    public bool makePurchase(int cost)
    {

        
            if (money >= cost)
            {
                money -= cost;
                moneyText.text = "$" + money;
                return true;
            }
            
                return false;
    }

    public void killedEnemy()
    {
        money += 5;
        money += 5 - (enemySpawner.level / 10);
        moneyText.text = "$" + money;

    }
    public void killedBossEnemy()
    {
        money += 100;
        money += (10 * enemySpawner.level) - 50;
        moneyText.text = "$" + money;

    }
}
