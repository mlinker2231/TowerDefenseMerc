using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _height, _numberOfEnemies;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private BossEnemy _bossEnemyPrefab;



    public List<Enemy> enemyList = new List<Enemy>();
    public int level = 1;
    private bool spawningEnemies = false;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        InvokeRepeating("CheckForEnemies", 8, 1);
    }
    

    IEnumerator SpawnEnemies()
    {
        spawningEnemies = true;
        if (level % 5 != 0)
        {
            _numberOfEnemies += level / 2;
            for (int x = 0; x <= _numberOfEnemies; x++)
            {
                double secondsWaited = ((1 / (2 * Mathf.Pow(level + 1, 3))) * (7 * Mathf.Pow(level + 1, 1.9f)));
                yield return new WaitForSeconds(((float)secondsWaited));
                SpawnNormalEnemy(x);
            }
        }
        if (level % 5 == 0)
        {
            for (int x = 0; x <= level / 5; x++)
            {
            
                double secondsWaited = 3;
                yield return new WaitForSeconds(((float)secondsWaited));
                SpawnBossEnemy(x);
            }
        }
        spawningEnemies = false;
        
    }

    private void SpawnNormalEnemy(int x)
    {
        var spawnedEnemy = Instantiate(_enemyPrefab, new Vector3(0, _height, -1), Quaternion.identity);
        spawnedEnemy.name = $"Enemy {x}";
        spawnedEnemy.transform.Translate(new Vector3(0, 0));
        spawnedEnemy.health += level / 2;
        spawnedEnemy._speed += (float)level / 4.7f;
        enemyList.Add(spawnedEnemy);
    }


    private void SpawnBossEnemy(int x)
    {
        var spawnedEnemy = Instantiate(_bossEnemyPrefab, new Vector3(0, _height, -1), Quaternion.identity);
        spawnedEnemy.name = $"BossEnemy {x}";
        spawnedEnemy.transform.Translate(new Vector3(0, 0));
        spawnedEnemy.health += (level) * 15;
        spawnedEnemy._speed = (float)level / 15f;
        enemyList.Add(spawnedEnemy);
    }

private void CheckForEnemies()
    {
        if (!spawningEnemies && enemyList.Count == 0)
        {
            level += 1;
            _levelText.text = "Level: " + level;
            StartCoroutine(SpawnEnemies());
        }

    }



}
