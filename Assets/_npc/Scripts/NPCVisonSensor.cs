using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baponkar.npc.zombie
{
    //[ExecuteInEditMode]
    public class NPCVisonSensor : MonoBehaviour
    {
        
        public float distance = 20f;
        public float angle = 30f;
        public float height = 3.0f;
        public Color meshColor = Color.red;
        Mesh mesh;

        public int scanFrequency = 30;

        [Tooltip("The layers which find by the sensor")]
        public LayerMask targetLayers;// = LayerMask.GetMask("Character");

        public Vector3 sensorYOffset;

        Collider[] colliders = new Collider[50];

        int count;
        float scanInterval;
        float scanTimer;
        public bool isScanning;

        public List<GameObject> Objects{
            get {
                objects.RemoveAll(obj => !obj);
                return objects;
            }
        }

        private List<GameObject> objects = new List<GameObject>();

        [Tooltip("The layers which blocking sensor.")]
        public LayerMask occlusionLayers;// = LayerMask.GetMask("Default");

        void Start(){
            scanInterval = 1.0f/scanFrequency;
        }

        void Update(){
            scanTimer -= Time.deltaTime;
            if(scanTimer < 0){
                scanTimer += scanInterval; 
                Scan();
                isScanning = true;
            }
            else{
                isScanning = false;
            }
        }

        private void Scan(){
            count = Physics.OverlapSphereNonAlloc(transform.position,distance,colliders,targetLayers,QueryTriggerInteraction.Collide);
            objects.Clear();
            for(int i =0; i< count;i++){
                GameObject obj = colliders[i].gameObject;
                if(IsInsight(obj)){
                    objects.Add(obj);
                }
            }
        }

        public bool IsInsight(GameObject obj){
            Vector3 origin = transform.position;
            Vector3 dest = obj.transform.position;
            Vector3 direction = dest - origin;
            if(direction.y < -0.1f || direction.y > height){
                return false;
            }

            direction.y = 0;
            float deltaAngle = Vector3.Angle(direction, transform.forward);
            if(deltaAngle > angle){
                return false;
            }

            origin.y += height/2;
            dest.y = origin.y;
            if(Physics.Linecast(origin, dest, occlusionLayers)){
                return false;
            }
            return true;
        }

        Mesh CreateWedgeMesh(){
            Mesh mesh = new Mesh();
            int segments = 10;
            int numTriangles = (segments*4)+2+2; //each segments has 4 verices and 2 up and 2 downside
            int numVertices = numTriangles*3;

            Vector3 [] vertices = new Vector3[numVertices];
            int [] triangles = new int[numVertices];

            Vector3 bottomCenter = Vector3.zero + sensorYOffset;
            Vector3 bottomLeft = Quaternion.Euler(0,-angle,0)*Vector3.forward*distance;
            Vector3 bottomRight = Quaternion.Euler(0,angle,0)*Vector3.forward*distance;

            Vector3 topCenter = bottomCenter + Vector3.up*height;
            Vector3 topLeft = bottomLeft+ Vector3.up*height;
            Vector3 topRight = bottomRight + Vector3.up*height;

            int vert = 0;

            //leftside
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomLeft;
            vertices[vert++] = topLeft;

            vertices[vert++] = topLeft;
            vertices[vert++] = topCenter;
            vertices[vert++] = bottomCenter;


            //rightside
            vertices[vert++] = bottomCenter;
            vertices[vert++] = topCenter;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomCenter;

            float currentAngle = -angle;
            float deltaAngle = (angle*2)/segments;
            for(int i =0; i<segments; i++){
                
                bottomLeft = Quaternion.Euler(0,currentAngle,0)*Vector3.forward*distance;
                bottomRight = Quaternion.Euler(0,currentAngle+deltaAngle,0)*Vector3.forward*distance;

                topLeft = bottomLeft+ Vector3.up*height;
                topRight = bottomRight + Vector3.up*height;
                //farside
                vertices[vert++] = bottomLeft;
                vertices[vert++] = bottomRight;
                vertices[vert++] = topRight;

                vertices[vert++] = topRight;
                vertices[vert++] = topLeft;
                vertices[vert++] = bottomLeft;

                //topside
                vertices[vert++] = topCenter;
                vertices[vert++] = topLeft;
                vertices[vert++] = topRight;

                //bottomside
                vertices[vert++] = bottomCenter;
                vertices[vert++] = bottomRight;
                vertices[vert++] = bottomLeft;

                currentAngle += deltaAngle;
            }
            

            for(int i=0; i<numVertices;i++){
                triangles[i] = i;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();


            return mesh;
        }

        private void OnValidate(){
            mesh = CreateWedgeMesh();
            scanInterval = 1.0f/scanFrequency;
        }

        private void OnDrawGizmos(){
            if(mesh){
                Gizmos.color = meshColor;
                Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
                Gizmos.DrawWireSphere(transform.position,distance);
                
                for(int i=0; i<colliders.Length; ++i){
                    if(colliders[i] != null){
                        Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
                    }
                    
                }

                Gizmos.color = Color.green;

                foreach( var obj in Objects){
                    Gizmos.DrawSphere(obj.transform.position, 1.0f); 
                }
            }
        }

        public int Filter(GameObject [] buffer, string layerName)
        {
            int layer = LayerMask.NameToLayer(layerName);
            int count  = 0;
            foreach(var obj in Objects)
            {
                if(obj.layer == layer)
                {
                    buffer[count] = obj;
                    ++count;
                }
                if(buffer.Length == count)
                {
                    break; //buffer is full
                }
            }
            return count;
        }
    }
}
