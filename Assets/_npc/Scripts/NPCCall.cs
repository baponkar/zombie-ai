using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    [ExecuteInEditMode]
    public class NPCCall : MonoBehaviour
    {
        public Color color;
        NPCAgent [] agents;
        NPCAgent agent;
        public float callingDistance = 20f;
        public float offset = 5f;
        public bool getCall;
        // Start is called before the first frame update
        void Start()
        {
            agents = FindObjectsOfType<NPCAgent>();
            agent = GetComponent<NPCAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            Call();
        }

        public void Call()
        {
            
            if(agent.playerSeen)
            {
                for(int i = 0; i < agents.Length; i++)
                {
                    float distance = Vector3.Distance(agents[i].transform.position, transform.position);
                    if(distance < callingDistance && !agents[i].aiHealth.isDead )
                    {
                        if(agents[i].transform != agent.transform)
                    {
                            NPCAgent nearAgent = agents[i].transform.GetComponent<NPCAgent>();
                            NPCCall nearCalling = agents[i].transform.GetComponent<NPCCall>();
                            nearAgent.playerSeen = true;
                            nearCalling.getCall = true;
                            if(!getCall) nearAgent.stateMachine.ChangeState(NPCStateId.Alert);
                        }
                    }

                }
            }
            else
            {
                return;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, callingDistance);
        }
    }
}

