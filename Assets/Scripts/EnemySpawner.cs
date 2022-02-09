using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _height, _numberOfEnemies;
    [SerializeField] private float _speed;
    [SerializeField] private Enemy _enemyPrefab;


    private List<Enemy> enemyList = new List<Enemy>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        moveEnemies();
    }

    private void moveEnemies()
    {
        float speed = _speed * Time.deltaTime;
        foreach (Enemy enemy in enemyList)
        {
            if (enemy != null)
            {
                var position = enemy.transform.position;
                if (position.x < 2)
                    enemy.transform.Translate(new Vector3(speed, 0));
                if (position.x > 2 && position.x <= 2.2)
                {
                    if (position.y <= 8)
                        enemy.transform.Translate(new Vector3(0, speed));
                    else enemy.transform.Translate(new Vector3(speed, 0));
                }
                else
                if (position.x >= 2)
                {
                    if (position.x >= 7)
                    {
                        if (position.y <= 1)
                            enemy.transform.Translate(new Vector3(speed, 0));
                        else
                            enemy.transform.Translate(new Vector3(0, -speed));
                    }

                    else enemy.transform.Translate(new Vector3(speed, 0));

                }
            }
        }
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

}
