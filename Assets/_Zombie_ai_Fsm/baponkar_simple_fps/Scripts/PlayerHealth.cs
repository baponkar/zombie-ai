using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Baponkar.FPS.Simple
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public bool isDead = false;


        void Start()
        {
            currentHealth = maxHealth;

        }

        // Update is called once per frame
        void Update()
        {
           if(currentHealth <= 0 && !isDead)
           {
                Dead();
           }
        }

        public void TakeDamage(float damage)
        {
            if (currentHealth <= 0)
            {
                Dead();
            }
            else
            {
                currentHealth -= damage;
            }
        }

        

        public void Dead()
        {
            isDead = true;
            
        }
    }
}
