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
        if (transform.position.y > 80)
        {
            StartCoroutine("TakeDamage");
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
    }
   IEnumerator TakeDamage()
    {
        health -= 1;
        _damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damage.SetActive(false);
    }
}
