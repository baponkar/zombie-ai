using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCFootStep : MonoBehaviour
    {
        public AudioSource legAudioSourceL;
        public AudioSource legAudioSourceR;

      
        public AudioClip[] grassStepClips;
        public AudioClip[] gravelStepClips;
        public AudioClip[] metalStepClips;
        public AudioClip[] normalStepClips;

        [Range(0, 3)]
        public int groundType = 0;

        void Start()
        {
            
        }

        
        void Update()
        {
            
        }

        public void FootStep()
        {
            switch(groundType)
            {
                case 0:
                    int randomIndex0 = (int) Random.Range(0, grassStepClips.Length);
                    legAudioSourceR.PlayOneShot(grassStepClips[randomIndex0]);
                    break;
                case 1:
                    int randomIndex1 = (int)Random.Range(0, gravelStepClips.Length);
                    legAudioSourceR.PlayOneShot(gravelStepClips[randomIndex1]);
                    break;
                case 2:
                    int randomIndex2 = (int)Random.Range(0, metalStepClips.Length);
                    legAudioSourceR.PlayOneShot(metalStepClips[randomIndex2]);
                    break;
                case 3:
                    int randomIndex3 = (int)Random.Range(0, normalStepClips.Length);
                    legAudioSourceR.PlayOneShot(normalStepClips[randomIndex3]);
                    break;
                default:
                    int randomIndex4 = (int)Random.Range(0, normalStepClips.Length);
                    legAudioSourceR.PlayOneShot(normalStepClips[randomIndex4]);
                    break;
            }
            
        }
    }
}
