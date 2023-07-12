using UnityEngine;

namespace baponkar.npc.zombie
{
    [CreateAssetMenu()]
    public class NPCAgentConfig : ScriptableObject
    {
        
        [Header("Patrol State Variables.")]
        public float patrolRadius = 10f;
        public float patrolSpeed = 3f;
        public float patrolAcceleration = 8f;
        public float patrolTurnSpeed = 520f;
        [Range(0.0f, 2.0f)]
        public float patrolWaitTime = 1f;

   

        [Header("Alert State Variables!")]
        public float alertRadius = 20f;
        public float alertSpeed = 4f;
        public float alertAcceleration = 20f;
        public float alertTurnSpeed = 720f;
        [Range(0.0f, 4.0f)]
        public float alertWaitTime = 1f;


        [Header("Attack State Variables")]
        public float attackRadius = 2f;       
        public float attackDamage = 10f;
        public float attackTime = 1.0f;
        public Vector3 attackPositionCorection = Vector3.zero;

        [Header("Chase State Variables")]
        public float chaseRadius = 20f;
        public float chaseSpeed = 2f;
        public float chaseAcceleration = 30f;
        public float chaseTurnSpeed = 720f;
        [Range(0.0f, 2.0f)]
        public float chaseWaitTime = 1.0f;

        [Header("Flee State Variables")]
        [Range(0.0f, 30.0f)]
        public float fleeRange = 30f;
    }
}


