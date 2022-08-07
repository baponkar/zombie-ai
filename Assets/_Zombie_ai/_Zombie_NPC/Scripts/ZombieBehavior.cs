using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baponkar.npc.zombie;

public class ZombieBehavior : MonoBehaviour
{
    #region Variables

    BehaviorTree tree;
    NPCAgent agent;
    public enum ActionState { Idle, WORKING };
    public ActionState actionState = ActionState.Idle;
    Node.Status treeStatus = Node.Status.Running;

    #endregion

    void Start()
    {
        agent = GetComponent<NPCAgent>();
        tree = new BehaviorTree();

        Repeat repeat = new Repeat("repeat");

        Leaf isDead = new Leaf("is dead", IsDead);
        Leaf hasVision = new Leaf("Has Vision", HasVision);
        Leaf canHear = new Leaf("Can Hear", CanHear);
        Leaf isInjured = new Leaf("is injured", IsInjured);
        Leaf isInAttackRange = new Leaf("is in attack range", IsInAttackRange);
        //Leaf isPlayerDead = new Leaf("is player dead", IsPlayerDead);

        Leaf patrol = new Leaf("patrol", Patrol);
        Leaf chasePlayer = new Leaf("chase player", ChasePlayer);
        Leaf attack = new Leaf("attack", Attack);
        Leaf flee = new Leaf("flee", Flee);
        Leaf alert = new Leaf("alert", Alert);
        Leaf death = new Leaf("death", Death);
        Leaf idle = new Leaf("idle", Idle);

        Sequence mainbehavior = new Sequence("Main Behavior");


        mainbehavior.AddChild(isDead);
        mainbehavior.AddChild(isInjured);
        mainbehavior.AddChild(patrol);
        mainbehavior.AddChild(hasVision);
        mainbehavior.AddChild(canHear);
        mainbehavior.AddChild(isInAttackRange);
        mainbehavior.AddChild(chasePlayer);
        mainbehavior.AddChild(attack);

        tree.AddChild(mainbehavior);

        tree.PrintTree();

    }

    
    void Update()
    {
        Debug.Log("tree status: " + treeStatus);
        if(treeStatus != Node.Status.Success)
        {
            treeStatus = tree.Process();
        }
    }

    public Node.Status IsDead()
    {
        if(agent.aiHealth.isDead)
        {
            return Node.Status.Success;
        }
        return Node.Status.Failure;
    }

    public Node.Status IsInjured()
    {
        if(agent.aiHealth.currentHealth < agent.aiHealth.maxHealth)
        {
            return Node.Status.Success;
        }
        return Node.Status.Failure;
    }

    public Node.Status HasVision()
    {
        if(agent.targetingSystem.HasTarget)
        {
            return Node.Status.Success;
        }
        return Node.Status.Failure;
    }

    public Node.Status CanHear()
    {
        if(agent.soundSensor.canHear)
        {
            return Node.Status.Success;
        }
        return Node.Status.Failure;
    }

    public Node.Status Patrol()
    {
        return Node.Status.Success;
    }

    public Node.Status ChasePlayer()
    {
        return Node.Status.Success;
    }

    public Node.Status Attack()
    {
        return Node.Status.Success;
    }

    public Node.Status Flee()
    {
        return Node.Status.Success;
    }

    public Node.Status Alert()
    {
        return Node.Status.Success;
    }

    public Node.Status Death()
    {
        return Node.Status.Success;
    }

    public Node.Status Idle()
    {
        return Node.Status.Success;
    }

    public Node.Status IsInAttackRange()
    {
        if(agent.targetingSystem.HasTarget)
        {
            float distance = Vector3.Distance(agent.transform.position,agent.targetingSystem.TargetPosition);
            if(distance <= agent.config.attackRadius)
            {
                return Node.Status.Success;
            }
        }
        return Node.Status.Failure;
    }


}
