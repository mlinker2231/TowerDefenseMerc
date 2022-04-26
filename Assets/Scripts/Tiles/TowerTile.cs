using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{

    [SerializeField] private BulletScript _bulletPrefab;
    [SerializeField] public GameObject _rangeIndicator;

    private int ascendedLevel = 0;

    protected MoneyManager _moneyManager;
    protected float attackSpeed;
    protected bool selected = false;
    protected int tier = 0;

    static public int cost = 50;

    public List<BulletScript> enemyList = new List<BulletScript>();

    void Start()
    {
        attackSpeed = .7f;
        InvokeRepeating("Shoot", 0, attackSpeed);
        _rangeIndicator.transform.localScale = new Vector3(7, 7, 7);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && selected)
            upgrade();
    }

    private void Shoot()
    {
        var spawnedBullet = Instantiate(_bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bullet";
    }
    private void OnMouseEnter()
    {
        if (this.isActiveAndEnabled)
        {
            _rangeIndicator.SetActive(true);
            selected = true;
        }
    }
    private void OnMouseExit()
    {
        _rangeIndicator.SetActive(false);
        selected = false;
    }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (tier < 5)
        {
            if (_moneyManager.makePurchase(2 * cost))
            {
                print(tier);
                tier++;
                attackSpeed *= .8f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }
        }
        else if (tier == 5)
        {
            tier++;
            attackSpeed *= .2f;
            CancelInvoke();
            InvokeRepeating("Shoot", 0, attackSpeed);
        }

    }
}
