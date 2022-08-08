using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar
{
    public class CharacterNavigationController : MonoBehaviour
    {
        CharacterController controller;
        Animator animator;

        [HideInInspector] public bool reachedDestination = false;
        Vector3 destination;

        public float rotationSpeed = 120f;
        private Vector3 velocity;
        public float movementSpeed;
        private Vector3 lastPosition;

        public float stoppingDistance;

        
        void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>(); 
            movementSpeed = (float) Random.Range(2f,5.0f);
        }

        
        void Update()
        {
            
            if(transform.position != destination)
            {
                Vector3 destinationDirection = destination - transform.position;
                destinationDirection.y = 0;
                float destinationDistance = destinationDirection.magnitude;
                if(destinationDistance > stoppingDistance)
                {
                    reachedDestination = false;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                    controller.Move(transform.forward * movementSpeed * Time.deltaTime);
                    animator.SetFloat("SpeedX",0f);
                    animator.SetFloat("SpeedY",0.9f);
                }
                else
                {
                    reachedDestination = true;
                    lastPosition = transform.position;
                }
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdProduct = Vector3.Dot(transform.forward, velocity);
            var rightProduct = Vector3.Dot(transform.right, velocity);
        }

        public void SetDestination(Vector3 destination)
        {
            this.destination = destination;
            reachedDestination = false;
        }
    }
}
