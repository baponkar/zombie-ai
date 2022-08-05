using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Baponkar.FPS.Simple;


namespace baponkar.npc.zombie
{
    public class NPCAttackState : NPCState
    {
        float timer;
        float attackTime;

        Vector3 offset;
        PlayerHealth playerHealth;

        RaycastHit hit;

        public NPCStateId GetId()
        {
            return NPCStateId.Attack;
        }
        
        void NPCState.Enter(NPCAgent agent)
        {
            attackTime = agent.config.attackTime;
            agent.isAttacking = true;
            offset = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
            playerHealth = agent.playerTransform.GetComponent<PlayerHealth>();
        }
        void NPCState.Update(NPCAgent agent)
        {
           
            timer -= Time.deltaTime;
           
            FacePlayer(agent, Vector3.zero);
            agent.animator.SetBool("isAttacking", agent.isAttacking);
            float distance = Vector3.Distance(agent.playerTransform.position, agent.transform.position);
            if(!agent.aiHealth.isDead && distance > agent.config.attackRadius)
            {
                agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);
            }
            else if(agent.aiHealth.isDead)
            {
                agent.stateMachine.ChangeState(NPCStateId.Death);
            }
            else if(!agent.aiHealth.isDead && distance <= agent.config.attackRadius && !playerHealth.isDead)
            {
               
                if(playerHealth != null && !playerHealth.isDead)
                {
                    timer -= Time.deltaTime;
                    if(timer <= 0)
                    {
                        playerHealth.TakeDamage(agent.config.attackDamage);
                        timer = attackTime;
                    }
                }
                
            }
            if(playerHealth.isDead)
            {
                agent.playerSeen = false;
                agent.stateMachine.ChangeState(NPCStateId.Patrol);
            }
            
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isAttacking = false;
            agent.animator.SetBool("isAttacking", agent.isAttacking);
        }

        private void FacePlayer(NPCAgent agent,Vector3 offset)
        {  
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.transform.position + offset).normalized;
        
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x,0,direction.z));
            agent.navMeshAgent.transform.rotation = Quaternion.Lerp(agent.navMeshAgent.transform.rotation, lookRotation,Time.time* agent.config.patrolTurnSpeed);
        }

        
    }
}
