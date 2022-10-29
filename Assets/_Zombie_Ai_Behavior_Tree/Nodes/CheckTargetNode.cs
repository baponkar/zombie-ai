using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

using baponkar.npc.zombie;

public class CheckTargetNode : ActionNode
{
    NPCTargetingSystem targetingSystem;

    protected override void OnStart() {
        targetingSystem = context.agent.GetComponent<NPCTargetingSystem>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if(targetingSystem.HasTarget)
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
        
    }
}
