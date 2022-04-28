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

    private void fire()
    {

        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count <= 0)
            Destroy(gameObject);

        Enemy[] enemies = new Enemy[enemyManager.enemyList.Count];
        
        for (int x = 0; x < enemies.Length; x++)
        {
            if (enemyManager.enemyList[x] != null)
            {
                enemies[x] = enemyManager.enemyList[x];
            }
            else
            {
                Enemy enemy = Instantiate(_enemyPrefab, new Vector3(0, 100, 100), Quaternion.identity);

                enemies[x] = enemy;
            }

        }
        var closestEnemy = GetClosestEnemy(enemies);
        if (closestEnemy == null)
            DestroyImmediate(gameObject);
        else if (Vector3.Distance(closestEnemy.transform.position, transform.position) < 4)
        {
            StartCoroutine(Move(closestEnemy));
        }
        else Destroy(gameObject);
    }
    IEnumerator Move(Enemy closestEnemy)
    {
        bool isOnEnemy = false;
            while (!isOnEnemy)
            {
                if (closestEnemy == null)
                {
                    Destroy(gameObject);
                 break;
                }
            if (Vector3.Distance(transform.position, closestEnemy.transform.position) <= .5f)
            {
                isOnEnemy = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, .045f);
                yield return new WaitForSeconds(0);
        
            }
        if (closestEnemy == null) yield break;
            closestEnemy.StartCoroutine("TakeDamage");
        Destroy(gameObject);
        }


    private Enemy GetClosestEnemy(Enemy[] enemies)
    {
        if (enemies.Length <= 0)
            return null;
        Enemy enemy = enemies[0];
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
