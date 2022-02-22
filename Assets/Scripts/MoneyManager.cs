using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
     

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool buyTower()
    {
        if (money >= 50)
        {
            money -= 50;
            return true;
        }
        else
            return false;
    }
    public void killedEnemy()
    {
        
    }

}
