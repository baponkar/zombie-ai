using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    public class NPCMemory
    {
        public GameObject gameObject;
        public Vector3 position;
        public Vector3 direction;
        public float distance;
        public float angle;
        public float lastSeen;
        public float score;
        
        public float age
        {
            get { return Time.time - lastSeen; }
        }
    }
    public class NPCSensoryMemory 
    {
        public List<NPCMemory> memories = new List<NPCMemory>();
        GameObject [] characters;

        public NPCSensoryMemory(int maxPlayers)
        {
            characters = new GameObject[maxPlayers];
        }

        public void UpdateSenses(NPCVisonSensor sensor)
        {
            int targets = sensor.Filter(characters, "Character");
            for(int i =0; i< targets; ++i)
            {
                GameObject target = characters[i];
                RefreshMemory(sensor.gameObject, target);
            }
        }

        public void RefreshMemory(GameObject agent, GameObject target)
        {
            NPCMemory memory = FetchMemory(target);
            memory.gameObject = target;
            memory.position = target.transform.position;
            memory.direction = target.transform.position - agent.transform.position;
            memory.distance = memory.direction.magnitude;
            memory.angle = Vector3.Angle(agent.transform.forward, memory.direction);
            memory.lastSeen = Time.time;
        }

        public NPCMemory FetchMemory(GameObject gameObject)
        {
            NPCMemory memory = memories.Find(x => x.gameObject == gameObject);
            if(memory == null)
            {
                memory = new NPCMemory();
                memories.Add(memory);
            }
            return memory;
        }

        public void ForgetMenories(float olderThan)
        {
            memories.RemoveAll(m => m.age > olderThan); // Remove all memories older than olderThan
            memories.RemoveAll(m => !m.gameObject); // Remove all memories that have no gameObject
            memories.RemoveAll(m => m.gameObject.GetComponent<Health>().isDead); // Remove all memories that already dead
            //memories.RemoveAll(m => m.gameObject.GetComponent<HitBox>().health.isDead); // Remove all memories that already dead
            // var toRemove = memories.Find(m => m.gameObject.GetComponent<Health>().isDead); // Remove all memories that already dead
            // if(toRemove != null) memories.Remove(toRemove); // Remove all memories that already dead
        }
        
    }
}
