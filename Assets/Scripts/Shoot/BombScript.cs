using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    void Start()
    {
        Fire();

    }

    void Update()
    {

    }

    private void Fire()
    {

        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        if (enemyManager.enemyList.Count == 0)
            DestroyImmediate(gameObject);
        else
        {
            for (int x = 0; x < enemyManager.enemyList.Count; x--)
            {
                
                if (enemyManager.enemyList[x] != null)
                {
                    if (Vector3.Distance(transform.position, enemyManager.enemyList[x].transform.position) <= 4)
                    {
                        enemyManager.enemyList[x].StartCoroutine("TakeDamage");
                        print(x + "took damage x");
                        Move(enemyManager.enemyList[x]);
                        for (int y = enemyManager.enemyList.Count - 1; y >= 0; y--)
                        {
                            if (Vector3.Distance(transform.position, enemyManager.enemyList[y].transform.position) <= 1.5)
                            {
                                if (y != x)
                                {
                                    enemyManager.enemyList[y].StartCoroutine("TakeDamage");
                                    print(y + "Took damage y");
                                }
                            }
                        }
                        print("Would break");
                        //break;
                    }
                    print("herere");

                }
                else
                {
                    
                }
            }
        }
        print("idk whats gonim");
    }
    private void Move(Enemy enemy)
    {
        transform.position = enemy.transform.position;
    }
}
