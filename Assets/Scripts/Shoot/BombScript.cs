using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    void Start()
    {
        Fire();
        StartCoroutine(Move(transform));
    }

    void Update()
    {

    }

    private void Fire()
    {

        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        //Checks if list empty
        if (enemyManager.enemyList.Count <= 0)
            DestroyImmediate(gameObject);
        else
        {
            Move(transform);
            //Iterates through a list of unkown size
            for (int x = 0; x < enemyManager.enemyList.Count; x++)
            {
                // if current enemy is there
                if (enemyManager.enemyList[x] != null)
                {
                    // if the distance betweeen this object and enemy is less than or equal to 4
                    if (Vector3.Distance(transform.position, enemyManager.enemyList[x].transform.position) <= 4)
                    {

                        enemyManager.enemyList[x].StartCoroutine("TakeBombDamage");
                        print(x + "took damage x");
                        //moves to where enemy is
                        StartCoroutine(Move(enemyManager.enemyList[x].transform));
                        //iterates through list again
                        foreach (Enemy enemy in enemyManager.enemyList)
                        {
                            // distance between this object and enemy position <= 1.5
                            if (Vector3.Distance(transform.position, enemy.transform.position) <= 1.5)
                            {
                                //if enemy already took damage, skip
                                if (enemy != enemyManager.enemyList[x])
                                {
                                    enemy.StartCoroutine("TakeBombDamage");
                                }
                            }
                        }
                        break;
                    }
                }
               
            }
        }
    }
    IEnumerator Move(Transform enemy)
    {
        transform.position = enemy.transform.position;
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
}
