using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace baponkar.npc.zombie
{
    public class NPCWaypointBasedPatrolState : NPCState
    {
        public Waypoint currentWaypoint;
        public float direction ;

        public NPCStateId GetId()
        {
            return NPCStateId.WaypointPatrol;
        }
        void NPCState.Enter(NPCAgent agent)
        {
            currentWaypoint = agent.config.waypoints.GetComponentInChildren<Waypoint>();
            direction = Mathf.RoundToInt(Random.Range(0f,1f));
            agent.navMeshAgent.SetDestination(currentWaypoint.GetPosition());
        }

        void NPCState.Exit(NPCAgent agent)
        {

        }


        void NPCState.Update(NPCAgent agent)
        {
            if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }

            /*if(agent.playerHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Patrol);
            }
            */
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

            WaypointPatrol(agent);
        }


        void WaypointPatrol(NPCAgent agent)
        {
            if(agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance + 0.1f)
            {
                bool shouldBranch = false;
                
                if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
                {
                    shouldBranch = Random.Range(0f,1f) <= currentWaypoint.branchProbability ? true : false;
                }

                if(shouldBranch)
                {
                    currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
                }
                else
                {
                    if(direction == 0)
                    {
                        if(currentWaypoint.nextWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.prevWaypoint;
                            direction = 1;
                        }
                    }

                    if( direction == 1)
                    {
                        if(currentWaypoint.prevWaypoint != null)
                        {
                            currentWaypoint = currentWaypoint.prevWaypoint;
                        }
                        else
                        {
                            currentWaypoint = currentWaypoint.nextWaypoint;
                            direction = 0;
                        }
                    }

                    agent.navMeshAgent.SetDestination(currentWaypoint.GetPosition());
                }
            }
        }
    }
}