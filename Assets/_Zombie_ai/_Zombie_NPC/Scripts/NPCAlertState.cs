using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar.npc.zombie
{
    public class NPCAlertState : NPCState
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
            return NPCStateId.Alert;
        }
        void NPCState.Enter(NPCAgent agent)
        {
            agent.isAlert = true;
            navMeshPath = new NavMeshPath();
            agent.navMeshAgent.isStopped = false;
            agent.navMeshAgent.speed = agent.config.alertTurnSpeed;
            initialPosition = agent.transform.position;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isAlert = false;
            agent.navMeshAgent.isStopped = false;
        }


        void NPCState.Update(NPCAgent agent)
        {
            
            timer -= Time.deltaTime;
            Alert(agent);
        }

        void SearchingPoint(NPCAgent agent)
        {
            Vector3 tempPos = Vector3.zero;
            tempPos = RandomNavmeshLocation(agent);
            //tempTarget = new Vector3(agent.navMeshAgent.transform.position.x + tempPos.x, agent.navMeshAgent.transform.position.y, agent.navMeshAgent.transform.position.z + tempPos.z);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(tempPos, out hit, agent.config.alertRadius, NavMesh.AllAreas) )
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
            Vector3 randomDirection = Random.insideUnitSphere * agent.config.alertRadius;
            randomDirection += agent.navMeshAgent.transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = (Vector3) agent.navMeshAgent.transform.position;
            if (NavMesh.SamplePosition(randomDirection, out hit, agent.config.alertRadius, 1)) {
                float distance = Vector3.SqrMagnitude(initialPosition - hit.position);
                if( distance < agent.config.alertRadius * agent.config.alertRadius){
                    finalPosition = hit.position;
                    walkPointSet = true;
                }
            }
            return finalPosition;
        }

        void FaceAlert(NPCAgent agent)
        {   
            Vector3 direction = (tempTarget- agent.navMeshAgent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x,0,direction.z));
            agent.navMeshAgent.transform.rotation = Quaternion.Lerp(agent.navMeshAgent.transform.rotation, lookRotation,Time.time*agent.config.alertTurnSpeed);
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

        void Alert(NPCAgent agent)
        {
            if(!walkPointSet)
            {
                SearchingPoint(agent);
            }

            if(walkPointSet && timer < 0f)
            {
                FaceAlert(agent);
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

