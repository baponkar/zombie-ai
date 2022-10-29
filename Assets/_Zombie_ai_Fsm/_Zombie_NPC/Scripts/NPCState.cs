using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
        public enum NPCStateId{
        Idle,
        Patrol,
        ChasePlayer,
        Attack,
        Death,
        Flee,
        Alert,
        WaypointPatrol

    }
    public interface NPCState 
    {
        NPCStateId GetId();
        void Enter(NPCAgent agent);
        void Update(NPCAgent agent);
        void Exit(NPCAgent agent);
    }
}
