using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
{
    public class NPCPatrolState : NPCState
    {
        #region Variables

        bool walkPointSet;
        Vector3 tempTarget;
        Vector3 lastTempTarget;

        float timer;
        float maxTime;

        NavMeshPath navMeshPath;
        Vector3 initialPosition;

        #endregion
    
        public NPCStateId GetId()
        {
            return NPCStateId.Patrol;
        }

        void NPCState.Enter(NPCAgent agent)
        {
            navMeshPath = new NavMeshPath();
            agent.navMeshAgent.isStopped = false;

            agent.navMeshAgent.speed = agent.config.patrolSpeed;
            agent.navMeshAgent.acceleration = agent.config.patrolAcceleration;
            agent.navMeshAgent.angularSpeed  = agent.config.patrolTurnSpeed;
            maxTime = agent.config.patrolWaitTime;
            initialPosition = agent.transform.position;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.navMeshAgent.isStopped = false;
        }


        void NPCState.Update(NPCAgent agent)
        {
            
            timer -= Time.deltaTime;
            

            if(!agent.aiHealth.isDead)
            {
                if(agent.FindThePlayerWithTargetingSystem())
                {
                    agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
                }
                else
                {
                    Patrol(agent);
                }
            }
            else
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
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

        void SearchingPoint(NPCAgent agent)
        {
            Vector3 tempPos = Vector3.zero;
            tempPos = RandomNavmeshLocation(agent);
    
            NavMeshHit hit;
            if (NavMesh.SamplePosition(tempPos, out hit, agent.config.patrolRadius, NavMesh.AllAreas) )
            {
                if(agent.navMeshAgent.CalculatePath(hit.position, navMeshPath)) //check a path available or not
                {
                    tempTarget = hit.position;
                    walkPointSet = true;
                }
            }
            else
            {
                tempTarget = initialPosition;
                walkPointSet = false;
            }
        }

        Vector3 RandomNavmeshLocation(NPCAgent agent) {
            Vector3 randomDirection = Random.insideUnitSphere * agent.config.patrolRadius;
            randomDirection += agent.navMeshAgent.transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = (Vector3) agent.navMeshAgent.transform.position;
            if (NavMesh.SamplePosition(randomDirection, out hit, agent.config.patrolRadius, 1)) {
                float distance = Vector3.SqrMagnitude(initialPosition - hit.position);
                if( distance < agent.config.patrolRadius * agent.config.patrolRadius){
                    finalPosition = hit.position;
                    walkPointSet = true;
                }
            }
            return finalPosition;
        }

        void FacePatrol(NPCAgent agent)
        {   
            Vector3 direction = (tempTarget- agent.navMeshAgent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x,0,direction.z));
            agent.navMeshAgent.transform.rotation = Quaternion.Lerp(agent.navMeshAgent.transform.rotation, lookRotation,Time.time * agent.config.patrolTurnSpeed);
        }
        
        
        

        void Patrol(NPCAgent agent)
        {
            if(!walkPointSet)
            {
                SearchingPoint(agent);
            }

            if(walkPointSet && timer < 0f)
            {
                FacePatrol(agent);
                agent.navMeshAgent.SetDestination(tempTarget);
                lastTempTarget = tempTarget;
                timer = maxTime;
            }
        
            if(agent.navMeshAgent.remainingDistance <= 0.1f)
            {
                walkPointSet = false;
            }
        }
    }
}

