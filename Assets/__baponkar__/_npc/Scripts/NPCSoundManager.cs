using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace baponkar.npc.zombie
{
    public class NPCSoundManager : MonoBehaviour
    {
        public AudioSource mouthAudio;
        public AudioSource handAudioL;
        public AudioSource handAudioR;
        public AudioSource legAudioL;
        public AudioSource legAudioR;
        public AudioSource bodyAudio;

        public AudioClip[] handClips;

        public AudioClip[] attackMouthClips;

        public AudioClip screamAudioClip;

        NPCTargetingSystem targetingSystem;
        NPCAgent agent;

        float screamingIntervalTime = 1f;
        float timer;

        void Start()
        {
            targetingSystem = GetComponent<NPCTargetingSystem>();
            agent = GetComponent<NPCAgent>();

            timer = screamingIntervalTime;
        }


        void Update()
        {
            if(targetingSystem.HasTarget && agent.currentState != NPCStateId.Attack)
            {
                timer -= Time.deltaTime;
                if(!mouthAudio.isPlaying && timer < 0)
                {
                    mouthAudio.PlayOneShot(screamAudioClip);
                    timer = Random.Range(0 , 3*screamingIntervalTime);
                }
            }
        }

        public void Attack()
        {
            if (!handAudioR.isPlaying)
            {
                handAudioR.PlayOneShot(handClips[Random.Range(0, handClips.Length)]);
            }

            if (!mouthAudio.isPlaying)
            {
                handAudioR.PlayOneShot(attackMouthClips[Random.Range(0, handClips.Length)]);
            }
        }
    }
}
