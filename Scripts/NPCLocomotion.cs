using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc
{
   public class NPCLocomotion : MonoBehaviour
    {
        NPCAgent agent;
        float speed;
        void Start()
        {
            agent = GetComponent<NPCAgent>();
            speed = 0;
        }

        void Update()
        {
            speed = agent.navMeshAgent.velocity.magnitude;
            agent.animator.SetFloat("Speed", speed);
            
        }
    }
}