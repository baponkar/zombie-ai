using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace baponkar.npc.zombie
{
    public class NPCFleeState : NPCState
    {
        int multiplier = 1; // or more

        public NPCStateId GetId()
        {
            return NPCStateId.Flee;
        }

        void NPCState.Enter(NPCAgent agent)
        {
            agent.navMeshAgent.isStopped = false;
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.navMeshAgent.isStopped = false;
        }

        void NPCState.Update(NPCAgent agent)
        {
            Vector3 runTo = agent.transform.position + (agent.transform.position - agent.playerTransform.position) * multiplier;
            float distance = Vector3.Distance(agent.transform.position, agent.playerTransform.position);
            if (distance < agent.config.fleeRange)
            {
                agent.navMeshAgent.SetDestination(runTo);
            }    
        }
    }
}
