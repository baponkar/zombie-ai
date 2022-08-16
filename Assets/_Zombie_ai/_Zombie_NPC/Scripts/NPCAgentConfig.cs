using UnityEngine;

namespace baponkar.npc.zombie
{
    [CreateAssetMenu()]
    public class NPCAgentConfig : ScriptableObject
    {
        
        [Header("Patrol.")]
        public float patrolRadius = 10f;
        public float patrolSpeed = 3f;
        public float patrolAcceleration = 8f;
        public float patrolTurnSpeed = 520f;
        [Range(0.0f, 2.0f)]
        public float patrolWaitTime = 1f;

        [Header("Waypoints Based Patrol")]
        public GameObject waypoints;

        [Header("Alert!")]
        public float alertRadius = 20f;
        public float alertSpeed = 4f;
        public float alertAcceleration = 20f;
        public float alertTurnSpeed = 720f;
        [Range(0.0f, 4.0f)]
        public float alertWaitTime = 1f;


        [Header("Attack")]
        [Range(0.0f, 2.5f)]
        public float offsetAttackRadius = 5f;
        public float attackRadius = 20f;
        public float attackTurnSpeed = 5f;
        [Range(0.0f, 2.0f)]
        public float offsetAttackSpeed = 0.5f;
        public float attackWalkingSpeed = 2f;
        public float attackDamage = 10f;
        public float attackTime = 1.0f;

        [Header("Chase")]
        [Range(0.0f, 2.0f)]
        public float chaseWaitTime = 1.0f;
        public float offsetChaseRadius = 2.5f;
        public float chaseRadius = 20f;
        public float chaseTurnSpeed = 5f;
        public float chaseWalkingSpeed = 2f;

        [Header("Flee")]
        [Range(0.0f, 30.0f)]
        public float fleeRange = 30f;
    }
}


