using UnityEngine;

namespace baponkar.npc.zombie
{
    [CreateAssetMenu()]
    public class NPCAgentConfig : ScriptableObject
    {
        [Header("NPC Zombie Agent")]
        public float waitTime = 1.0f; //the wait time to ai re follow the player
        public float maxDistance = 1.0f;
        public float maxSightDistance = 30.0f;


        [Header("Patrol")]
        [Range(0.0f, 5.0f)]
        public float offsetPatrolRadius = 2.5f;
        public float patrolRadius = 10f;
        public float patrolTurnSpeed = 5f;
        [Range(0.0f, 1.0f)]
        public float offsetPatrolSpeed = 0.5f;
        public float patrolWalkingSpeed = 2f;
        [Range(0.0f, 1.0f)]
        public float patrolWaitTime = 0.5f;

        [Header("Waypoints Based Patrol")]
        public GameObject waypoints;

        [Header("Alert")]
        [Range(0.0f, 5.0f)]
        public float offsetAlertRadius = 2.5f;
        public float alertRadius = 10f;
        public float alertTurnSpeed = 5f;
        [Range(0.0f, 1.0f)]
        public float offsetalertSpeed = 0.5f;
        public float alertWalkingSpeed = 2f;
        [Range(0.0f, 1.0f)]
        public float alertWaitTime = 0.5f;


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
        [Range(0.0f, 5.0f)]
        public float offsetChaseRadius = 2.5f;
        public float chaseRadius = 20f;
        public float chaseTurnSpeed = 5f;
        [Range(0.0f, 2.0f)]
        public float offsetChaseSpeed = 1.0f;
        public float chaseWalkingSpeed = 2f;

        [Header("Flee")]
        [Range(0.0f, 30.0f)]
        public float fleeRange = 30f;
    }
}


