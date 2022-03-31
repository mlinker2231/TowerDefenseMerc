using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _height, _numberOfEnemies;
    [SerializeField] private Enemy _enemyPrefab;


    public List<Enemy> enemyList = new List<Enemy>();
    public int level = 1;
    private bool spawningEnemies = false;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        InvokeRepeating("CheckForEnemies", 8, 1);
    }
    private void Update()
    {
        
   
    }

    

    IEnumerator SpawnEnemies()
    {

        spawningEnemies = true;
        _numberOfEnemies += level;
        for (int x = 0; x <= _numberOfEnemies; x++)
        {
           double secondsWaited = ((1 / (2 * Mathf.Pow(level + 1, 5))) * (7 * Mathf.Pow(level + 1, 3.8f)));
            yield return new WaitForSeconds(((float)secondsWaited));
            SpawnNormalEnemy(x);
        }
        spawningEnemies = false;
        
    }

    private void SpawnNormalEnemy(int x)
    {
        var spawnedEnemy = Instantiate(_enemyPrefab, new Vector3(0, _height, -1), Quaternion.identity);
        spawnedEnemy.name = $"Enemy {x}";
        spawnedEnemy.transform.Translate(new Vector3(0, 0));
        spawnedEnemy.health += level / 2;
        spawnedEnemy._speed += (float)level / 5;
        enemyList.Add(spawnedEnemy);
    }

    private void CheckForEnemies()
    {
        if (!spawningEnemies && enemyList.Count == 0)
        {
            level += 1;
            StartCoroutine(SpawnEnemies());
        }

    }



}
