using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCStateMachine 
    {
        public NPCState [] states;
        public  NPCAgent agent;
        public NPCStateId currentState;

        public NPCStateMachine(NPCAgent agent)
        {
            this.agent = agent;
            int numStates = System.Enum.GetNames(typeof(NPCStateId)).Length;
            states = new NPCState[numStates];

        }

        public void RegisterState(NPCState state){
            int index = (int)state.GetId();
            states[index] = state;
        }

        public NPCState GetState(NPCStateId stateId){
            int index  = (int) stateId;

            return states[index];
        }
        public void Update(){
            GetState(currentState)?.Update(agent);
        }
        public void ChangeState(NPCStateId newState){
            GetState(currentState)?.Exit(agent);
            currentState = newState;
            GetState(currentState)?.Enter(agent);
        }
    }
}
