using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

using baponkar.npc.zombie;

public class AttackNode : ActionNode
{
    NPCTargetingSystem targetingSystem;
    Animator animator;
    float timer = 0;
    float attackTime = 1f;

    protected override void OnStart() {
        targetingSystem = context.agent.GetComponent<NPCTargetingSystem>();
        animator = context.agent.GetComponent<Animator>();
        timer = attackTime;
    }

    protected override void OnStop() {
        animator.SetBool("isAttacking", false);
    }

    protected override State OnUpdate() {

        timer -= Time.deltaTime;

        if(targetingSystem.HasTarget)
        {
            Health targetHealth = targetingSystem.Target.GetComponent<Health>();
            if(targetingSystem.TargetDistance <= 2f)
            {
                if(targetHealth.isDead)
                {
                    return State.Success;
                }
                else
                {
                    //Debug.Log("ATtacking");
                    if(timer <= 0f)
                    {
                        if(targetHealth != null)
                        targetHealth.TakeDamage(10f,targetHealth.transform.forward);
                        timer = attackTime;
                    }
                    animator.SetBool("isAttacking", true);
                    return State.Running;
                }
            } 
        }
        return State.Failure;
    }
}
