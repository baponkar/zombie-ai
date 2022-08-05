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
        }

        void NPCState.Update(NPCAgent agent)
        {
            if(!agent.aiHealth.isDead  && findThePlayer(agent))
            {
                agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
            }

            if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }

            if(agent.aiHealth.currentHealth < agent.aiHealth.maxHealth )
            {
                agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
            }

            agent.navMeshAgent.isStopped = true;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isIdleing = false;
        }

        
        bool findThePlayer(NPCAgent agent)
        {
            for (int i=0; i < agent.visonSensor.Objects.Count;i++)
            {
                if(agent.visonSensor.Objects[i].tag == "Player")
                {
                    agent.playerSeen = true;
                    return true;
                }
            }
            return false;
        }
        
    }

}

