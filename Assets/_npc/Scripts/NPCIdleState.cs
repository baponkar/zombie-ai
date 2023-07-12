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
            agent.navMeshAgent.isStopped = true;
        }

        void NPCState.Update(NPCAgent agent)
        {
            if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }

            

            if(agent.targetingSystem.HasTarget)
            {
                agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
            }

            if(agent.soundSensor.canHear || agent.call.getCall)
            {
                agent.FacePlayer();
                if(agent.targetingSystem.HasTarget)
                {
                    agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
                }
                else
                {
                    agent.stateMachine.ChangeState(NPCStateId.Alert);
                }
            }

            if(agent.aiHealth.currentHealth < agent.aiHealth.maxHealth)
            {
               agent.FacePlayer();
                if(agent.targetingSystem.HasTarget)
                {
                    agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
                }
                else
                {
                    agent.stateMachine.ChangeState(NPCStateId.Alert);
                } 
            }

        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.navMeshAgent.isStopped = false;
        }
    }

}

