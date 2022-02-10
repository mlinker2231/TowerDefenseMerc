using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{

    [SerializeField] private BulletScript _bulletPrefab;

    public List<BulletScript> enemyList = new List<BulletScript>();

    void Start()
    {
        InvokeRepeating("Shoot", 1, 1);
        
    }

    void Update()
    {
    }

     private void Shoot()
    {

        var spawnedBullet = Instantiate(_bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bullet";

       
    }

}
