using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCDeathSoundManager : MonoBehaviour
    {
        AudioSource audio;
        NPCAgent agent;
        bool played = false;
        [SerializeField] AudioClip clip;

        void Start()
        {
            audio = GetComponent<AudioSource>();
            agent = GetComponent<NPCAgent>();
        }

    
        public void PlayDeathEffect()
        {
            if(agent.aiHealth.isDead && !played)
            {
                audio.PlayOneShot(clip);
                played = true;
            }
        }
    }

}
