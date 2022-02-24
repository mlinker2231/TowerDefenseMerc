using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject _damage;
    [SerializeField] private float _speed;
    private MoneyManager _moneyManager;
    private LifeManager lifeManager;


    void Start()
    {
              _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
              lifeManager = GameObject.Find("EnemyManager").GetComponent<LifeManager>();

    }

    void Update()
    {
        move();
        if (transform.position.y > 80)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 12)
        {
            lifeManager.loseLife();
            Destroy(gameObject);
            
        }
        if (health == 0)
        {
            _moneyManager.killedEnemy();
            Destroy(gameObject);
        }
    }

    private void move()
    {
        float speed = _speed * Time.deltaTime;
        
            if (gameObject != null)
            {
                var position = gameObject.transform.position;
                if (position.x < 2)
                    gameObject.transform.Translate(new Vector3(speed, 0));
                if (position.x > 2 && position.x <= 2.2)
                {
                    if (position.y <= 8)
                        gameObject.transform.Translate(new Vector3(0, speed));
                    else gameObject.transform.Translate(new Vector3(speed, 0));
                }
                else
                if (position.x >= 2)
                {
                    if (position.x >= 7)
                    {
                        if (position.y <= 2)
                            gameObject.transform.Translate(new Vector3(speed, 0));
                        else
                            gameObject.transform.Translate(new Vector3(0, -speed));
                    }

                    else gameObject.transform.Translate(new Vector3(speed, 0));

                }
            }
        
    }

    IEnumerator TakeDamage()
    {
        _damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damage.SetActive(false);
        health -= 1;
    }
}
