using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc
{
    public class AiDeathState : NPCState
    {
        
        public NPCStateId GetId()
        {
        return NPCStateId.Death; 
        }
        void NPCState.Enter(NPCAgent agent)
        {
            agent.isDead = true;
            agent.navMeshAgent.isStopped = true;
            agent.animator.SetTrigger("death");
            agent.animator.SetInteger("deathType", 0);
            agent.capsuleCollider.enabled = false;
        }
        
        void NPCState.Exit(NPCAgent agent)
        {
            agent.isDead = false;
        }

    

        void NPCState.Update(NPCAgent agent)
        {

        }


    }
}

