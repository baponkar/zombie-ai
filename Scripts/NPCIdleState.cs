using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc
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
            if(findThePlayer(agent)){
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

