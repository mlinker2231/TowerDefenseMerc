using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : TowerTile
{
    [SerializeField] private BombScript _bombPrefab;
    void Start()
    {
        InvokeRepeating("Shoot", 0, 5);
        _rangeIndicator.transform.localScale = new Vector3(6, 6, 6);

    }

    private void Shoot()
    {
        var spawnedBullet = Instantiate(_bombPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bomb";
    }
}
