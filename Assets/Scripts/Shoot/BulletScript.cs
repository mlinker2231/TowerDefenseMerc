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
        if (Vector3.Distance(closestEnemy.transform.position, transform.position) < 4)
        {
            StartCoroutine(Move(closestEnemy));
            closestEnemy.StartCoroutine("TakeDamage");
        }
        else Destroy(gameObject);
    }
    IEnumerator Move(Enemy closestEnemy)
    {


        for (int x = 1; x < 100; x++)
        {
            if (closestEnemy != null)
            {
                var posE = closestEnemy.transform.position;
                var pos = transform.position;
                yield return new WaitForSeconds(0.003f);
                if (pos.x > posE.x)
                {
                    if (pos.y > posE.y)
                    {
                        transform.position = new Vector3(pos.x - .03f, pos.y - .03f);
                    }
                    else
                    {
                        transform.position = new Vector3(pos.x - .03f, pos.y + .03f);
                    }
                }
                else
                {
                    if (pos.y > posE.y)
                    {
                        transform.position = new Vector3(pos.x + .03f, pos.y - .03f);
                    }
                    else
                    {
                        transform.position = new Vector3(pos.x + .03f, pos.y + .03f);
                    }
                }
            }else
            {
                Destroy(gameObject);
                break;
            }
        }
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
