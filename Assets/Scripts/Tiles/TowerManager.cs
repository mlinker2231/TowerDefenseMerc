using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public string towerSelected;

    
    void Start()
    {
        towerSelected = "Basic";
    }

  

    public void SelectBasic()
    {
        towerSelected = "Basic";

    }
    public void SelectSniper()
    {
        towerSelected = "Sniper";
    }
    public void SelectElectric()
    {
        towerSelected = "Electric";

    }
    public void SelectBomb()
    {
        towerSelected = "Bomb";

    }
}
