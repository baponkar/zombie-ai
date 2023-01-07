using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS.Simple
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerFootStep : MonoBehaviour
    {
        #region Variables
        AudioSource audioSource;
        PlayerMovement playerMovement;
        public AudioClip[] footSteps;
        AudioClip clip;
        #endregion

        
        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            audioSource = GetComponent<AudioSource>();
        }

        
        void Update()
        {
            if(playerMovement.movement.magnitude > 0 && playerMovement.isGrounded)
            {
                clip = footSteps[Random.Range(0, footSteps.Length)];
                if(!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(clip);
                }
            }
        }
    }
}
