using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _height, _numberOfEnemies;
    [SerializeField] private Enemy _enemyPrefab;


    public List<Enemy> enemyList = new List<Enemy>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        InvokeRepeating("CheckForEnemies", 3, 3);
    }
    private void Update()
    {
        
   
    }

    

    IEnumerator SpawnEnemies()
    {
        for (int x = 0; x <= _numberOfEnemies; x++)
        {
            yield return new WaitForSeconds(1.5f);
            var spawnedEnemy = Instantiate(_enemyPrefab, new Vector3(0, _height, -1), Quaternion.identity);
            spawnedEnemy.name = $"Enemy {x}";
            spawnedEnemy.transform.Translate(new Vector3(0, 0));
            enemyList.Add(spawnedEnemy);

        }
    }
    private void CheckForEnemies()
    {
        print(enemyList.Count);
     if (enemyList.Count == 0)
        {
            StartCoroutine(SpawnEnemies());
        }

    }


}
