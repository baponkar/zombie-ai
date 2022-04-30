using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc
{
    public class NPCHealth : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public bool isDead = false;
        public bool  isInjured = false;
        
        public void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            if(currentHealth > 0)
            {
                currentHealth -= damage;
            }
            if(currentHealth <= 30f && currentHealth > 0)
            {
                isInjured = true;
            }
            else{
                currentHealth = 0;
                isInjured = false;
                isDead = true;
            }
        }
    }
}
