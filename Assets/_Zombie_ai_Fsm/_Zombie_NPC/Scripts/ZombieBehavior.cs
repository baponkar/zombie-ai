using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baponkar.npc.zombie;

public class ZombieBehavior : MonoBehaviour
{
    // #region Variables

    // NPCAgent agent;
    // public enum ActionState { IDLE, PATROL, WAYPOINT_PATROL, CHASE, ATTACK, FLEE, ALERT, DEATH };
    // public ActionState actionState;

    // #endregion

    // void Start()
    // {
    //     agent = GetComponent<NPCAgent>();
    //     actionState = ActionState.IDLE;
    // }

    
    // void Update()
    // {
    //     if(agent.aiHealth.isDead)
    //     {
    //         agent.stateMachine.ChangeState(NPCStateId.Death);
    //         actionState = ActionState.DEATH;
    //     }
    //     else
    //     {
    //         if(agent.aiHealth.currentHealth < agent.aiHealth.maxHealth * 0.9f)
    //         {
    //             actionState = ActionState.FLEE;
    //             agent.stateMachine.ChangeState(NPCStateId.Flee);
    //         }
    //         else 
    //         {
    //             agent.stateMachine.ChangeState(agent.initialState);

    //             if(agent.aiHealth.currentHealth < agent.aiHealth.maxHealth)
    //             {
    //                 actionState = ActionState.ALERT;
    //                 agent.stateMachine.ChangeState(NPCStateId.Alert);
    //             }

    //             if(agent.targetingSystem.HasTarget)
    //             {
    //                 actionState = ActionState.ALERT;
    //                 agent.stateMachine.ChangeState(NPCStateId.Alert);
    //                 if(agent.targetingSystem.TargetDistance < agent.config.attackRadius)
    //                 {
    //                     actionState = ActionState.ATTACK;
    //                     agent.stateMachine.ChangeState(NPCStateId.Attack);
    //                 }
    //                 else
    //                 {
    //                     actionState = ActionState.CHASE;
    //                     agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
    //                 }
    //             }

    //             if(agent.soundSensor.canHear && !agent.targetingSystem.HasTarget)
    //             {
                    
    //                 actionState = ActionState.ALERT;
    //                 agent.FacePlayer();
    //                 agent.stateMachine.ChangeState(NPCStateId.Alert);
    //             }
    //         }
    //     }
    // }

    // #region methods
    
   

    // #endregion

}
