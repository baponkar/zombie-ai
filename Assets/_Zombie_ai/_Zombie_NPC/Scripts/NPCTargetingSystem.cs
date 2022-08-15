using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    [ExecuteInEditMode]
    public class NPCTargetingSystem : MonoBehaviour
    {
        public float memorySpan = 3.0f;
        public float distanceWeight = 1.0f;
        public float angleWeight = 1.0f;
        public float ageWeight = 1.0f;

        public bool HasTarget 
        {
            get 
            {
                return bestMemory != null; 
            }
        }

        NPCMemory bestMemory = null;
        public GameObject Target 
        { 
            get 
            {
                if(HasTarget)
                {
                    return bestMemory.gameObject; 
                }
                else
                {
                    return null;
                }
             } 
        }

        public Vector3 TargetPosition 
        { 
            get 
            { 
                if(HasTarget)
                {
                    return bestMemory.gameObject.transform.position;
                } 
                else 
                {
                    return Vector3.zero;
                } 
            } 
        }

        public bool TargetInSight 
        { 
            get 
            {
                if(HasTarget) 
                {
                    return bestMemory.age < 0.5f;
                } 
                else
                {
                    return false;
                }
            } 
        }

        public float TargetDistance 
        { 
            get 
            { 
                if(HasTarget)
                {
                    return bestMemory.distance; 
                }
                else
                {
                    return Mathf.Infinity;
                }
            } 
        }
        NPCSensoryMemory memory = new NPCSensoryMemory(10);
        NPCVisonSensor sensor;
        
        
        void Start()
        {
            sensor = GetComponent<NPCVisonSensor>();
        }

        void Update()
        {
            memory.UpdateSenses(sensor);
            memory.ForgetMenories(memorySpan);
            EvaluateScores();
        }

    

        void EvaluateScores()
        {
            bestMemory = null;
            foreach(NPCMemory memory in memory.memories)
            {
                if(memory.gameObject != this.gameObject)
                {
                    memory.score = CalculateScore(memory);
                    if(bestMemory == null || memory.score > bestMemory.score)
                    {
                        bestMemory = memory;
                    }
                }
            }
        }

        float Normalize(float value, float maxValue)
        {
            return 1.0f - (value / maxValue);
        }

        float CalculateScore(NPCMemory memory)
        {
            float distanceScore = Normalize(memory.distance, sensor.distance) * distanceWeight;
            float angleScore = Normalize(memory.angle, sensor.angle) * angleWeight;
            float ageScore = Normalize(memory.age, memorySpan) * ageWeight;
            float score = distanceScore + angleScore + ageScore;
            return score;
        }


        private void OnDrawGizmos()
        {
            float maxScore = float.MinValue;
            foreach(NPCMemory memory in memory.memories)
            {
                maxScore = Mathf.Max(maxScore, memory.score);
            }
            foreach(var memory in memory.memories)
            {
                Color color = Color.red;
                if(memory == bestMemory)
                {
                    color = Color.yellow;
                }
                color.a = memory.score / maxScore;
                Gizmos.color = color;
                
                Gizmos.DrawSphere(memory.position, 0.4f);
            }
        }
    }
}
