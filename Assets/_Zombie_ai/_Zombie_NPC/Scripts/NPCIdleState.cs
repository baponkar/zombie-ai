using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCIdleState : NPCState
    {
        public NPCStateId GetId()
        {
            return NPCStateId.Idle; 
        }

        void NPCState.Enter(NPCAgent agent)
        {
            agent.isIdleing = true;
            agent.navMeshAgent.isStopped = true;
        }

        void NPCState.Update(NPCAgent agent)
        {

        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isIdleing = false;
            agent.navMeshAgent.isStopped = false;
        }
    }

}

