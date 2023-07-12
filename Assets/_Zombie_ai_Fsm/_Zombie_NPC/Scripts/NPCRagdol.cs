using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCRagdol : MonoBehaviour
    {
        Rigidbody [] rigidBodies;
        Animator anim;
        
        void Start()
        {
            rigidBodies = GetComponentsInChildren<Rigidbody>();
            anim = GetComponent<Animator>();
            DeActivateRagdol();
        }

        void Update()
        {
            
        }

        public void DeActivateRagdol()
        {
            anim.enabled = true;
            foreach(Rigidbody rb in rigidBodies)
            {
                rb.isKinematic = true;
            }
        }

        public void ActivateRagdol()
        {
            anim.enabled = false;
            foreach(Rigidbody rb in rigidBodies)
            {
                rb.isKinematic = false;
            }
        }

        public void ApplyForce(Vector3 force)
        {
            var rb = anim.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
