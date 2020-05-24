using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;

    public int _health = 100;

    public Health()
    {
        _health = startingHealth;
    }

    private void Awake()
    {
        _health = startingHealth;
    }

    public void GetDamage(int damage)
    {
        _health = _health - damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
