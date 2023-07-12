using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace baponkar
{
    public class WaypointNavigator : MonoBehaviour
    {
        NavMeshAgent agent;
        
        public Waypoint currentWaypoint;
        public float direction ;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        void Start()
        {
            direction = Mathf.RoundToInt(Random.Range(0f,1f));
            agent.SetDestination(currentWaypoint.GetPosition());
        }

        
        void Update()
        {
            if(agent.remainingDistance <= 0.1f)
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

                    agent.SetDestination(currentWaypoint.GetPosition());
                }
            }
        }
    }
}

