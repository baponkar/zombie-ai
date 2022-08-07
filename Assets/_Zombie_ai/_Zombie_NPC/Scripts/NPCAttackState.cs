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
            agent.navMeshAgent.isStopped = true;
            offset = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
            playerHealth = agent.playerTransform.GetComponent<PlayerHealth>();
        }
        void NPCState.Update(NPCAgent agent)
        {
            timer -= Time.deltaTime;
            FacePlayer(agent, Vector3.zero);
            agent.animator.SetBool("isAttacking", agent.isAttacking);
                
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                playerHealth.TakeDamage(agent.config.attackDamage);
                timer = attackTime;
            }
        }

        void NPCState.Exit(NPCAgent agent)
        {
            agent.isAttacking = false;
            agent.navMeshAgent.isStopped = false;
            agent.animator.SetBool("isAttacking", agent.isAttacking);
        }

        private void FacePlayer(NPCAgent agent,Vector3 offset)
        {  
            Vector3 direction = (agent.targetingSystem.TargetPosition - agent.navMeshAgent.transform.position + offset).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x,0,direction.z));
            agent.navMeshAgent.transform.rotation = Quaternion.Lerp(agent.navMeshAgent.transform.rotation, lookRotation,Time.time* agent.config.patrolTurnSpeed);
        }
    }
}
