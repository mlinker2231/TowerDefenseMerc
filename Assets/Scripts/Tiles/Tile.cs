using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, _trackColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _greenT;
    [SerializeField] private Component _towerTile;
    [SerializeField] private GameObject _sniperSkin;
    [SerializeField] private GameObject _electricSkin;
    [SerializeField] private GameObject _bombSkin;



    private MoneyManager _moneyManager;
    private TowerManager _towerManager;
    private void Start()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        _towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();


    }

    public void Init(bool isOffset, bool isTrack) 
    {
        if (isTrack)
            _renderer.color = _trackColor;
        else _renderer.color = isOffset ? _offsetColor : _baseColor;

    }

    private void OnMouseDown()
    {
 
            if (!_greenT.activeSelf)
            {
            
            if (_moneyManager.buyTower())
            {
                TowerManager towerManager = _towerManager.GetComponent<TowerManager>();
                if (towerManager.towerSelected.Equals("Sniper"))
                {
                    _sniperSkin.SetActive(true);
                    gameObject.GetComponent<SniperTower>().enabled = true;
                    _renderer.enabled = false;
                }
                else if (towerManager.towerSelected.Equals("Electric"))
                {
                    _electricSkin.SetActive(true);
                    gameObject.GetComponent<ElectricTower>().enabled = true;
                    _renderer.enabled = false;
                }
                else if (towerManager.towerSelected.Equals("Bomb"))
                {
                    _bombSkin.SetActive(true);
                    gameObject.GetComponent<BombTower>().enabled = true;
                    _renderer.enabled = false;
                }
                else
                {
                    _greenT.SetActive(true);
                    gameObject.GetComponent<TowerTile>().enabled = true;
                }


            }
        }
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
