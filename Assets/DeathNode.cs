using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

using baponkar.npc.zombie;

public class DeathNode : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Debug.Log("Player is dead!");
        context.agent.GetComponent<NPCRagdol>().ActivateRagdol();
        return State.Running;
    }
}
