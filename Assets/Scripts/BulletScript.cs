using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void fire()
    {
        EnemySpawner enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();

        Transform[] transforms = new Transform[enemyManager.enemyList.Count];

        for (int x = 0; x < transforms.Length; x++)
        {
            transforms[x] = enemyManager.enemyList[x].transform;
        }

    }

    private Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
