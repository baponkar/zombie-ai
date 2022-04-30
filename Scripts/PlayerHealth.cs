using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHitPoints = 100f;
    public float health;
    public bool isDead = false;
    void Start()
    {
        health = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        
        if (health <= 0)
        {
            isDead = true;
        }
        else{
            health -= damage;
        }
    }
}
