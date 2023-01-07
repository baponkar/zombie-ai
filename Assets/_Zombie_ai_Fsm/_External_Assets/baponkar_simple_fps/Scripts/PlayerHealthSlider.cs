using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using baponkar.npc.zombie;

namespace Baponkar.FPS.Simple
{
    public class PlayerHealthSlider : MonoBehaviour
    {
        public Slider slider;
        public Text text;
        public PlayerHealth health;
        
        void Start()
        {
            text.text = (health.currentHealth * 100f /health.maxHealth).ToString() + "%";
            slider.value = health.currentHealth/health.maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            text.text = (health.currentHealth * 100f/health.maxHealth).ToString() + "%";
            slider.value = health.currentHealth/health.maxHealth;
        }
    }
}
