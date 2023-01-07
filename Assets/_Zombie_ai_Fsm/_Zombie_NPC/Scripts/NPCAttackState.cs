using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace baponkar.npc.zombie
{
    public class NPCAttackState : NPCState
    {
        float timer;
        float attackTime;

        Vector3 offset;
        

        RaycastHit hit;
        RaycastHit hitL;
        RaycastHit hitR;

        private Vector3 direction;
        private Vector3 directionL;
        private Vector3 directionR;

        public NPCStateId GetId()
        {
            return NPCStateId.Attack;
        }
        
        void NPCState.Enter(NPCAgent agent)
        {
            attackTime = agent.config.attackTime;
            agent.navMeshAgent.isStopped = true;
            offset = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
            //playerHealth = agent.playerTransform.GetComponent<Health>();
            agent.animator.SetBool("isAttacking", true);
            agent.FacePlayer();
        }

        void NPCState.Update(NPCAgent agent)
        {
            timer -= Time.deltaTime;

            if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }
            else
            {
                /*if(agent.playerHealth.isDead)
                {
                    agent.stateMachine.ChangeState(NPCStateId.Patrol);
                }
                else
                {*/
                    if(agent.targetingSystem.HasTarget && agent.targetingSystem.TargetDistance <= agent.config.attackRadius)
                    {
                        if(timer <= 0f )
                        {
                            Attack(agent);
                            timer = attackTime;
                        }
                    }
                    else if(agent.targetingSystem.HasTarget && agent.targetingSystem.TargetDistance > agent.config.attackRadius)
                    {
                        agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
                    }
                    else
                    {
                        agent.stateMachine.ChangeState(NPCStateId.Alert);
                    }
                //}
            }
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.navMeshAgent.isStopped = false;
            agent.animator.SetBool("isAttacking", false);
        }

        private void Attack(NPCAgent agent)
        {
            direction = (agent.playerTransform.position - agent.transform.position).normalized;
            var raycast = Physics.Raycast(agent.transform.position, direction, out hit, agent.config.attackRadius);

            if(raycast)
            {
                if(hit.collider.gameObject.tag == "Player" )
                {
                    Debug.Log("Attacking");
                    
                }
            }
        }
    }
}
