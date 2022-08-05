using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
{
    public class NPCDeathState : NPCState
    {
        
        public NPCStateId GetId()
        {
        return NPCStateId.Death; 
        }
        void NPCState.Enter(NPCAgent agent)
        {
            agent.isDead = true;
            if(agent.navMeshAgent != null)
            {
                agent.navMeshAgent.isStopped = true;
            }
            agent.animator.SetTrigger("death");
            agent.aiHealth.isDead = true;
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

