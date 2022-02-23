using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] TMP_Text moneyText;
    void Start()
    {
        moneyText.text = "$" + money;
    }

    void Update()
    {
        
    }

    public bool buyTower()
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
    public void killedEnemy()
    {
        money += 10;
        moneyText.text = "$" + money;


    }

}
