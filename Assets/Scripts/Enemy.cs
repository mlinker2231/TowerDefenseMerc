using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private GameObject _damage;

    void Start()
    {
        
    }

    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        StartCoroutine(takeDamage());
    }
   IEnumerator takeDamage()
    {
        health -= 1;
        _damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damage.SetActive(false);
    }
}
