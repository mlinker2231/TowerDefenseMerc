using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{

    [SerializeField] private BulletScript _bulletPrefab;
    [SerializeField] private GameObject _rangeIndicator;


    public List<BulletScript> enemyList = new List<BulletScript>();

    void Start()
    {
        InvokeRepeating("Shoot", 1, 1);
        _rangeIndicator.transform.localScale = new Vector3(6, 6, 2);
    }

    void Update()
    {
    }

     private void Shoot()
    {

        var spawnedBullet = Instantiate(_bulletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
        spawnedBullet.name = $"Bullet";
    }
    private void OnMouseEnter()
    {
        if  (this.isActiveAndEnabled)
        _rangeIndicator.SetActive(true);
    }
    private void OnMouseExit()
    {
        _rangeIndicator.SetActive(false);
    }
}
