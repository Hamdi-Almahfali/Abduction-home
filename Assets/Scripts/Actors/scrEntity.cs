using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float startingHealth;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
    }

    void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {

        Destroy(gameObject);
    }
}
