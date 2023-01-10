using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
{
   public class NPCLocomotion : MonoBehaviour
    {
        NPCAgent agent;
        Animator animator;
        [SerializeField] float maxSpeed;
        float speed;
        

        
        void Start()
        {
            agent = GetComponent<NPCAgent>();
            animator = GetComponent<Animator>();
            maxSpeed = Mathf.Max(agent.config.chaseSpeed, 
                agent.config.alertSpeed, 
                agent.config.patrolSpeed);
            Debug.Log(maxSpeed);
        }

        void Update()
        {
            speed = agent.navMeshAgent.velocity.magnitude / maxSpeed;
            //Debug.Log(agent.navMeshAgent.velocity.magnitude.ToString() + "," + speed.ToString());
            animator.SetFloat("Speed", speed);
        }
    }
}