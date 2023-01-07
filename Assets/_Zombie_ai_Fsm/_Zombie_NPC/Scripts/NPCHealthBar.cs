using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace baponkar.npc.zombie
{
    public class NPCHealthBar : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        [HideInInspector] public ZombieHealth health;

        [HideInInspector] public Slider slider;
        
        void Start()
        {
            health = GetComponentInParent<ZombieHealth>();
            slider = GetComponentInChildren<Slider>();
        }
    

        void LateUpdate()
        {
            if(!health.isDead)
            {
                transform.position =Camera.main.WorldToScreenPoint(target.position + offset);
                slider.value = health.currentHealth / health.maxHealth;
            }
            else
            {
                slider.gameObject.SetActive(false);
            }
        }
    }
}
