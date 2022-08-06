using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baponkar.FPS.Simple;

namespace baponkar.npc.zombie
{
    public class NPCChasePlayerState : NPCState
    {
        float timer;
        public NPCStateId GetId()
        {
            return NPCStateId.ChasePlayer;
        }

        void NPCState.Enter(NPCAgent agent)
        {
            agent.playerSeen = true;
            agent.isChaseing = true;
            agent.navMeshAgent.isStopped = false;
            agent.navMeshAgent.stoppingDistance = agent.config.attackRadius;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isChaseing = false;
            agent.navMeshAgent.stoppingDistance = 0.0f;
            agent.navMeshAgent.isStopped = false;
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
                    if(timer <= 0.0f){
                        if(agent.targetingSystem.TargetPosition != null)
                        {
                            agent.navMeshAgent.SetDestination(agent.targetingSystem.TargetPosition);
                            timer = agent.config.waitTime;
                        }
                    }
                }
                else
                {
                    if(timer <= 0.0f)
                    {
                        //ChasePlayer(agent);
                        if(agent.targetingSystem.HasTarget)
                        {
                            agent.navMeshAgent.SetDestination(agent.targetingSystem.TargetPosition);
                        }
                        else
                        {
                            agent.stateMachine.ChangeState(NPCStateId.Patrol);
                        }
                        timer = agent.config.waitTime;
                    }
                }

                if(agent.targetingSystem.TargetDistance <= agent.config.attackRadius)
                {
                    agent.stateMachine.ChangeState(NPCStateId.Attack);
                }
            }
        }

        private static void ChasePlayer(NPCAgent agent)
        {
            PlayerHealth playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
            if(agent.targetingSystem.HasTarget)
            {
                float distance = Vector3.Distance(agent.targetingSystem.TargetPosition, agent.transform.position);
                if (distance > agent.config.attackRadius)
                {
                    agent.animator.SetBool("isAttacking", false);
                    //agent.navMeshAgent.speed = agent.config.chaseWalkingSpeed + agent.config.offsetChaseSpeed;
                    agent.navMeshAgent.destination = agent.targetingSystem.TargetPosition;
                }
                else
                {
                    agent.stateMachine.ChangeState(NPCStateId.Attack);
                }
            }
            else
            {
                agent.stateMachine.ChangeState(NPCStateId.Patrol);
            }
            

            
            
            if(playerHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Patrol);
            }
        }
    }
}