using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] protected GameObject _damage;
    [SerializeField] protected GameObject _sniperDamage;
    [SerializeField] protected GameObject _electricDamage;
    [SerializeField] protected GameObject _bombDamage;
    [SerializeField] public float _speed;

    public bool takingSnipeDamage = false;

    protected EnemySpawner _enemyManager;
    protected MoneyManager _moneyManager;
    protected LifeManager lifeManager;


    void Start()
    {
              _moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
              lifeManager = GameObject.Find("EnemyManager").GetComponent<LifeManager>();
               _enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
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
            _enemyManager.enemyList.Remove(this);
            lifeManager.loseLife();
            Destroy(gameObject); 
        }
        if (health <= 0)
        {
            _enemyManager.enemyList.Remove(this);
            _moneyManager.killedEnemy();
            Destroy(gameObject);
        }
    }

    protected void move()
    {
        float speed = _speed * Time.deltaTime;
        
            if (gameObject != null)
            {
                var position = gameObject.transform.position;
                if (position.x < 2)
                    gameObject.transform.Translate(new Vector3(speed, 0));
                if (position.x > 2 && position.x <= 3.5)
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
        health -= 1;
        _damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damage.SetActive(false);
    }
    public IEnumerator TakeSnipeDamage()
    {
        takingSnipeDamage = true;
        _sniperDamage.SetActive(true);
        yield return new WaitForSeconds(1f);
        _sniperDamage.SetActive(false);
        health -= 1000;

    }
    public IEnumerator TakeBombDamage(int damage)
    {
        health -= 2;
        _bombDamage.SetActive(true);
        yield return new WaitForSeconds(.75f);
        _bombDamage.SetActive(false);
    }

    IEnumerator Zap()
        {
            _electricDamage.SetActive(true);
            yield return new WaitForSeconds(0.17f);
            _electricDamage.SetActive(false);
            health -= 1;
        }
    public void TakeElectricDamage()
    {
        StartCoroutine(Zap());
       
    }

    public IEnumerator TakeSnipeDamage(float damage)
    {
        print(health + "b");
        takingSnipeDamage = true;
        _sniperDamage.SetActive(true);
        yield return new WaitForSeconds(1f);
        _sniperDamage.SetActive(false);
        health = (int)(health * damage);
        health -= (int)(6 / damage);
        print(health + "a");
        takingSnipeDamage = false;
    }

}
