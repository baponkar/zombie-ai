using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using baponkar.npc.zombie;


    // [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    // [RequireComponent(typeof(NPCHealth))]
    // [RequireComponent(typeof(Rigidbody))]
    // [RequireComponent(typeof(DebugNavmeshAgent))]
    // [RequireComponent(typeof(NPCVisonSensor))]
    // [RequireComponent(typeof(NPCSoundSensor))]
    // [RequireComponent(typeof(AudioSource))]
    // [RequireComponent(typeof(CapsuleCollider))]
    // [RequireComponent(typeof(NPCCall))]

    public class NPCAgent : MonoBehaviour
    {
        [HideInInspector]
        public Transform playerTransform;
        public NPCStateMachine stateMachine;
        public NPCStateId initialState;
       
        [HideInInspector]
        public NavMeshAgent navMeshAgent;
        public NPCAgentConfig config;
        [HideInInspector]
        public NPCVisonSensor visonSensor;
        [HideInInspector]
        public NPCSoundSensor soundSensor;
        [HideInInspector]
        public Health aiHealth;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public CapsuleCollider capsuleCollider;
        [HideInInspector]
        public NPCTargetingSystem targetingSystem;
        
        [Header("NPC Zombie Agent.")]
        public bool isIdleing;
        public bool isPatrolling;
        public bool isChaseing;
        public bool isAttacking;
        public bool isDead;
        public bool isFleeing;
        public bool playerSeen = false;
        public bool isAlert = false;

        [HideInInspector]
        public Vector3 initialPosition;

    
        void Start()
        {
            if(playerTransform == null){
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }

            initialPosition = this.transform.position;
            navMeshAgent = GetComponent<NavMeshAgent>();
            visonSensor = GetComponentInChildren<NPCVisonSensor>();
            soundSensor = GetComponentInChildren<NPCSoundSensor>();
            aiHealth = GetComponent<Health>();
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
        

            stateMachine.ChangeState(initialState);
        }

        
        void Update()
        {
            stateMachine.Update();

        }
    }

