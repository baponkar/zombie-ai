using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace baponkar.npc.zombie
{
    public class NPCAgent : MonoBehaviour
    {
        #region Variables

        [HideInInspector]
        public Transform playerTransform;
        public NPCStateMachine stateMachine;
        public NPCStateId initialState;
        [SerializeField] NPCStateId currentState;

        [HideInInspector]
        public NavMeshAgent navMeshAgent;
        public NPCAgentConfig config;
        [HideInInspector]
        public NPCVisonSensor visonSensor;
        [HideInInspector]
        public NPCSoundSensor soundSensor;
        [HideInInspector]
        public NPCCall call;
        [HideInInspector]
        public ZombieHealth aiHealth;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public CapsuleCollider capsuleCollider;
        [HideInInspector]
        public NPCTargetingSystem targetingSystem;

        public GameObject waypoints;
        //public Transform attackOrigin;//This point to determine attack


        public bool playerSeen = false;

        [HideInInspector]
        public Vector3 initialPosition; //storeing the initial position of the zombie.

        #endregion

        void Start()
        {
            if (playerTransform == null) {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            else
            {
                Debug.LogError("No player object with Player tag found!");
            }

            if (playerTransform != null)
            {

            }
            else
            {
                Debug.LogError("Player Health is not assigned!");
            }

            initialPosition = this.transform.position;
            navMeshAgent = GetComponent<NavMeshAgent>();
            visonSensor = GetComponentInChildren<NPCVisonSensor>();
            soundSensor = GetComponentInChildren<NPCSoundSensor>();
            call = GetComponentInChildren<NPCCall>();
            aiHealth = GetComponent<ZombieHealth>();
            animator = GetComponentInChildren<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            targetingSystem = GetComponent<NPCTargetingSystem>();

            stateMachine = new NPCStateMachine(this);
            stateMachine.RegisterState(new NPCChasePlayerState());
            stateMachine.RegisterState(new NPCDeathState());
            stateMachine.RegisterState(new NPCIdleState());
            stateMachine.RegisterState(new NPCPatrolState());
            stateMachine.RegisterState(new NPCAttackState());
            stateMachine.RegisterState(new NPCFleeState());
            stateMachine.RegisterState(new NPCAlertState());
            stateMachine.RegisterState(new NPCWaypointBasedPatrolState());

            stateMachine.ChangeState(initialState);
        }


        void Update()
        {
            stateMachine.Update();
            currentState = stateMachine.currentState;
        }

        public void FaceTarget()
        {
            Vector3 direction = (targetingSystem.TargetPosition - navMeshAgent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.time * 720f);
        }

        public void FacePlayer()
        {
            Vector3 direction = (playerTransform.position - navMeshAgent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.time * 720f);
        }



        public bool findThePlayer()
        {
            //finding Player by using only Vison Sensor
            for (int i = 0; i < visonSensor.Objects.Count; i++)
            {
                if (visonSensor.Objects[i].tag == "Player")
                {
                    playerSeen = true;
                    return true;
                }
            }
            return false;
        }

        public bool FindThePlayerWithTargetingSystem()
        {
            //finding Player by using Targeting System
            if (targetingSystem.HasTarget)
            {
                if (targetingSystem.Target.tag == "Player")
                {
                    playerSeen = true;
                    return true;
                }
            }
            playerSeen = false;
            return false;
        }

        // void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.red;
        //     if(targetingSystem.HasTarget)
        //     {
        //         Gizmos.DrawLine(attackOrigin.position, targetingSystem.TargetPosition);
        //         Vector3 left = targetingSystem.TargetPosition;
        //         left.x -= 1f;
        //         Gizmos.DrawLine(attackOrigin.position, left);
        //         Vector3 right = targetingSystem.TargetPosition;
        //         right.x += 1f;
        //         Gizmos.DrawLine(attackOrigin.position, right);
        //     }
        // }
    }
}

