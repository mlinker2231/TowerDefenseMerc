using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : TowerTile
{
    [SerializeField] private BombScript _bombPrefab;
    static public int cost = 200;


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
    }
    protected void upgrade()
    {
        _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        if (tier < 10)
        {
            if (_moneyManager.makePurchase(2 *cost))
            {
                tier++;
                attackSpeed *= .8f;
                CancelInvoke();
                InvokeRepeating("Shoot", 0, attackSpeed);
            }

        }
        else if (tier == 10)
        {
            tier++;
            attackSpeed *= .4f;
            CancelInvoke();
            InvokeRepeating("Shoot", 0, attackSpeed);
        }
    }
}
