using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
{
    public class NPCPatrolState : NPCState
    {
        bool walkPointSet;
        Vector3 tempTarget;
        Vector3 lastTempTarget;
        float timer;
        float maxTime = 1f;
        NavMeshPath navMeshPath;
        Vector3 initialPosition;
    
        public NPCStateId GetId()
        {
            return NPCStateId.Patrol;
        }
        void NPCState.Enter(NPCAgent agent)
        {
            agent.isPatrolling = true;
            navMeshPath = new NavMeshPath();
            agent.navMeshAgent.isStopped = false;
            initialPosition = agent.transform.position;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isPatrolling = false;
            agent.navMeshAgent.isStopped = false;
        }


        void NPCState.Update(NPCAgent agent)
        {
            
            timer -= Time.deltaTime;
            if(!agent.aiHealth.isDead){
                if(agent.targetingSystem.HasTarget){
                    agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
                }
                else
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
            else
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }
        }

        void SearchingPoint(NPCAgent agent)
        {
            Vector3 tempPos = Vector3.zero;
            tempPos = RandomNavmeshLocation(agent);
            //tempTarget = new Vector3(agent.navMeshAgent.transform.position.x + tempPos.x, agent.navMeshAgent.transform.position.y, agent.navMeshAgent.transform.position.z + tempPos.z);
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
            agent.navMeshAgent.transform.rotation = Quaternion.Lerp(agent.navMeshAgent.transform.rotation, lookRotation,Time.time*agent.config.patrolTurnSpeed);
        }
        
        
        bool findThePlayer(NPCAgent agent)
        {
            //finding Player by using only Vison Sensor
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

