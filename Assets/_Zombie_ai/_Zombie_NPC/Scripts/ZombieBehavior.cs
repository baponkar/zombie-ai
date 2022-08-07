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

    //     Sequence attackSequence = new Sequence("Attack to the Player.");
    //     Leaf health = new Leaf("Health", Health);
    //     Leaf idle = new Leaf("Idle", Idle);
    //     Leaf patrol = new Leaf("Patrol", Patrol);
    //     Leaf attack = new Leaf("Attack", Attack);
    //     Leaf flee = new Leaf("Flee", Flee);
    //     Leaf chase = new Leaf("Chase", Chase);
    //     //Leaf search = new Leaf("Search", Search);
    //     //Leaf hide = new Leaf("Hide", Hide);
    //     Leaf dead = new Leaf("Dead", Dead);
    //     //Leaf getUp = new Leaf("Get Up", GetUp);
    //     //Leaf getUpFromGround = new Leaf("Get Up From Ground", GetUpFromGround);
    //     Selector attackSelector = new Selector("Attack Selector");
    //     attackSelector.AddChild(attack);
    //     attackSelector.AddChild(flee);
    //     attackSelector.AddChild(chase);
    //     //attackSelector.AddChild(search);
    //     //attackSelector.AddChild(hide);
    //     attackSequence.AddChild(health);
        
    //     tree.PrintTree();
     }

    
    void Update()
    {
    //     Debug.Log("tree status: " + treeStatus);
    //     if(treeStatus != Node.Status.Success)
    //     {
    //         treeStatus = tree.Process();
    //     }
    }
}
