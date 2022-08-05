using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
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
            speed = Mathf.Clamp(agent.navMeshAgent.velocity.magnitude,0,1);
            agent.animator.SetFloat("Speed", speed);
        }
    }
}