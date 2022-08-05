using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS.Simple
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        public float speed = 12f;
        public float gravity = -9.81f;
        public KeyCode jumpKey = KeyCode.Space;
        public float jumpHeight = 3f;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float pushPower = 2.0F;
        [HideInInspector]public Vector3 movement;
        [HideInInspector]public bool isGrounded;
        [HideInInspector]public bool isJumping;

        Vector3 velocity;
        CharacterController controller;
       #endregion

        public bool jumpUp
        {
            get{return isJumping;}
            set
            {
                if(isJumping != value)
                {
                    isJumping = value;
                    // Run some function or event here
                }
            }
        }

        
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        
        void Update()
        {
            GroundCheck();
            Jump();
            MoveMent(); 
        }

        void Jump()
        {
            isJumping = !isGrounded;
            if(Input.GetKeyDown(jumpKey) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void MoveMent()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            movement = transform.right * x + transform.forward * z;
            controller.Move(movement * Time.deltaTime * speed);
            velocity += (Vector3.up * gravity) * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            // no rigidbody
            if (body == null || body.isKinematic)
                return;

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3f)
                return;

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * pushPower;
        }

        void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }

    }
}
