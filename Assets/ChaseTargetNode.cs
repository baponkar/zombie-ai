using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

using UnityEngine.AI;
using baponkar.npc.zombie;

public class ChaseTargetNode : ActionNode
{
    Transform player;
    NavMeshAgent navMeshAgent;
    NPCTargetingSystem targetingSystem;

    protected override void OnStart() {
        player = GameObject.FindWithTag("Player").transform;
        navMeshAgent = context.agent.GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 2f;
        targetingSystem = context.agent.GetComponent<NPCTargetingSystem>();

        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if(targetingSystem.HasTarget && targetingSystem.TargetDistance > 2f)
        {
            navMeshAgent.destination = player.position;
            return State.Running;
        }
        return State.Success;
    }
}
