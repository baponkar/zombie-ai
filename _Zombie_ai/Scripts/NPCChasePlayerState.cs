using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc
{
    public class AiChasePlayerState : NPCState
    {
        
        float timer = 0.0f;

        public NPCStateId GetId()
        {
        return NPCStateId.ChasePlayer;
        }
        void NPCState.Enter(NPCAgent agent)
        {
            agent.playerSeen = true;
            agent.isChaseing = true;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isChaseing = false;
        }



        void NPCState.Update(NPCAgent agent)
        {
            timer -= Time.deltaTime;
            if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }
            else
            {
                if(!agent.navMeshAgent.hasPath){
                    agent.navMeshAgent.speed = agent.config.chaseWalkingSpeed + agent.config.offsetChaseSpeed;
                    agent.animator.SetBool("isAttacking", false);
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
                else
                {
                    ChasePlayer(agent);
                }
            }
        }

        private static void ChasePlayer(NPCAgent agent)
        {
            float distance = Vector3.Distance(agent.playerTransform.position, agent.transform.position);
            if (distance > agent.config.attackRadius)
            {
                agent.navMeshAgent.isStopped = false;
                agent.animator.SetBool("isAttacking", false);
                agent.navMeshAgent.speed = agent.config.chaseWalkingSpeed + agent.config.offsetChaseSpeed;
                agent.navMeshAgent.destination = agent.playerTransform.position;
            }
            else
            {
                agent.navMeshAgent.isStopped = true;
                agent.stateMachine.ChangeState(NPCStateId.Attack);
            }
        }
    }
}