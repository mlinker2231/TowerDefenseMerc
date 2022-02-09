using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{

    [SerializeField] private BulletScript _bulletPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Shoot());
    }

     IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        var spawnedBullet = Instantiate(_bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bullet";

    }
}
