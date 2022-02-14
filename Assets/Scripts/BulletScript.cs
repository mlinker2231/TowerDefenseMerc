using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] private Enemy _enemyPrefab;

    void Start()
    {
        fire();
        
    }

    void Update()
    {
        
    }

    private void fire()
    {
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();

        Enemy[] enemies = new Enemy[enemyManager.enemyList.Count];

        for (int x = 0; x < enemies.Length; x++)
        {
            if (enemyManager.enemyList[x] != null)
            {
                enemies[x] = enemyManager.enemyList[x];
            }
            else
            {
                Enemy enemy = Instantiate(_enemyPrefab, new Vector3(100, 100, 100), Quaternion.identity);

                enemies[x] = enemy;
            }

        }
        var closestEnemy = GetClosestEnemy(enemies);
        closestEnemy.StartCoroutine("TakeDamage");
        StartCoroutine(Move(closestEnemy));
        //transform.position = new Vector3(((transform.position.x + closestEnemy.transform.position.x) / 2), ((transform.position.y + closestEnemy.transform.position.y) / 2), -2);
    }
    IEnumerator Move(Enemy closestEnemy)
    {
        for(int x = 1; x < 100; x++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position = new Vector3(((transform.position.x + closestEnemy.transform.position.x) / (100/x)), ((transform.position.y + closestEnemy.transform.position.y) / (100/x)), -2);
        }
    }


    private Enemy GetClosestEnemy(Enemy[] enemies)
    {
        Enemy enemy = null;
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Enemy t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                enemy = t;
                tMin = t.transform;
                minDist = dist;
            }
        }

        return enemy;
    }
}
