using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    [ExecuteInEditMode]
    public class NPCSoundSensor : MonoBehaviour
    {
        SphereCollider sphereCollider;
        public Color color;
        NPCAgent agent;
        
        public float radius = 5f;
        void Start()
        {
            agent = GetComponent<NPCAgent>();
            sphereCollider = GetComponent<SphereCollider>();
            if(sphereCollider == null)
            {
                sphereCollider = gameObject.AddComponent<SphereCollider>();
            }
            sphereCollider.radius = radius;
            sphereCollider.isTrigger = true;
        }

        
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                agent.isChaseing = true;
                agent.playerSeen = true;
                agent.stateMachine.ChangeState(NPCStateId.ChasePlayer);     
            }   
        }

   

        void OnDrawGizmos()
        {
            Gizmos.color = color;
            Vector3 position = transform.position;
            position.y = position.y + 0.9f;
            Gizmos.DrawSphere(transform.position, radius);

        }
    }
}

