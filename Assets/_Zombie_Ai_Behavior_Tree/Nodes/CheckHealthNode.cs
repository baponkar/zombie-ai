using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

using baponkar.npc.zombie;

public class CheckHealthNode : ActionNode
{
    Health health;
    protected override void OnStart() {
        health = context.agent.GetComponent<Health>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if(!health.isDead)
        {
            //Debug.Log("Inside of CheckHealthNode!");
             return State.Success;
        }
        else
        {
             return State.Failure;
        }
    }
}
