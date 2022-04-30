using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using baponkar.npc;


    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(NPCHealth))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(DebugNavmeshAgent))]
    [RequireComponent(typeof(NPCVisonSensor))]
    [RequireComponent(typeof(NPCSoundSensor))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(NPCCall))]

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
        public NPCHealth aiHealth;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public CapsuleCollider capsuleCollider;
        public bool isIdleing;
        public bool isPatrolling;
        public bool isChaseing;
        public bool isAttacking;
        public bool isDead;
        public bool playerSeen = false;
        public Vector3 initialPosition;

    
        void Start()
        {
            if(playerTransform == null){
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }

            initialPosition = this.transform.position;
            navMeshAgent = GetComponent<NavMeshAgent>();
            visonSensor = GetComponent<NPCVisonSensor>();
            soundSensor = GetComponent<NPCSoundSensor>();
            aiHealth = GetComponent<NPCHealth>();
            animator = GetComponentInChildren<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            

            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            stateMachine = new NPCStateMachine(this);
            stateMachine.RegisterState(new AiChasePlayerState());
            stateMachine.RegisterState(new AiDeathState());
            stateMachine.RegisterState(new NPCIdleState());
            stateMachine.RegisterState(new NPCPatrolState());
            stateMachine.RegisterState(new NPCAttackState());
        

            stateMachine.ChangeState(initialState);
        }

        
        void Update()
        {
            stateMachine.Update();
        }
    }

