using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private EnemySpawner enemyManager;
    void Start()
    {
        Fire();
        
    }



    private void Fire()
    {

        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
        //Checks if list empty
        if (enemyManager.enemyList.Count <= 0)
            DestroyImmediate(gameObject);
        else
        {
            
            //Iterates through a list of unkown size
            for (int x = 0; x < enemyManager.enemyList.Count; x++)
            {
                // if current enemy is there
                if (enemyManager.enemyList[x] != null)
                {
                    // if the distance betweeen this object and enemy is less than or equal to 2.5
                    if (Vector3.Distance(transform.position, enemyManager.enemyList[x].transform.position) <= 2.5f)
                    {
                        //moves to where enemy is
                        StartCoroutine(Move(enemyManager.enemyList[x]));
                        break;
                    }
                    if (enemyManager.enemyList.Count - 1 == x)
                        Destroy(gameObject);
                }  
             
               
            }
        }
    }
    private void Explode()
    {
        foreach (Enemy enemy in enemyManager.enemyList)
        {
            // distance between this object and enemy position <= 1.5
            if (Vector3.Distance(transform.position, enemy.transform.position) <= 1.25)
            {                
                    enemy.StartCoroutine("TakeBombDamage");
            }
        }
        Destroy(gameObject);
    }
    IEnumerator Move(Enemy enemy)
    {
        for (int x = 0; x < 70; x++)
        {
            if (enemy == null) {
                Destroy(gameObject);
                    break;
                    }
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, .045f);
            yield return new WaitForSeconds(.001f);
        }
        Explode();
    }
}
