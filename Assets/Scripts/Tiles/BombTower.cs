using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : TowerTile
{
    [SerializeField] private BombScript _bombPrefab;
    static public int cost = 200;
    private int damage = 2;
    private float area = 1.25f;

    void Start()
    {
        attackSpeed = 1.8f;
        InvokeRepeating("Shoot", 0, attackSpeed);
        _rangeIndicator.transform.localScale = new Vector3(4.5f, 4.5f, 6);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && selected)
            upgrade();
    }
    private void Shoot()
    {
        var spawnedBullet = Instantiate(_bombPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bomb";
        spawnedBullet.damage = damage;
        spawnedBullet.explodeArea = area;
    }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (tier < 5)
        {
            if (_moneyManager.makePurchase(2 *cost))
            {
                tier++;
                damage++;
                attackSpeed *= .75f;
                area += .1f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }

        }
        else if (tier == 5)
        {
            if (_moneyManager.makePurchase(2 * cost))
            {
                tier++;
                area += .7f;
                attackSpeed *= .66f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }
        }
    }
}
