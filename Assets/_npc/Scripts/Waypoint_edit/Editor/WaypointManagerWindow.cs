using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace baponkar
{
    
    public class WaypointManagerWindow : EditorWindow
    {
        [MenuItem("Zombie Ai/Waypoint Manager")]
        public static void Open()
        {
            GetWindow<WaypointManagerWindow>("Waypoint Manager");
        }

        public Transform waypointRoot;

        public void OnGUI()
        {
            SerializedObject obj = new SerializedObject(this);

            EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

            if(waypointRoot == null)
            {
                EditorGUILayout.HelpBox("A transform must be selected. Please assign a root transform!", MessageType.Warning);
            }
            else
            {
                EditorGUILayout.BeginVertical("box");
                DrawButtons();
                EditorGUILayout.EndVertical();
            }

            obj.ApplyModifiedProperties();
        }

        void DrawButtons()
        {
            if(GUILayout.Button("Create Waypoints"))
            {
                CreateWaypoints();
            }

            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>() != null)
            {
                
                if(GUILayout.Button("Create Waypoint After."))
                {
                    CreateWaypointAfter();
                }
                
                if(GUILayout.Button("Create Waypoint Before."))
                {
                    CreateWaypointBefore();
                }
                
                if(GUILayout.Button("Delete Waypoint!"))
                {
                    DeleteWaypoint();
                }
            }

            if(GUILayout.Button("Add Branch."))
            {
                AddBranch();
            }
        }

        void AddBranch()
        {
            GameObject waypointObject = new GameObject("waypoint_" + waypointRoot.childCount, typeof(Waypoint));
            waypointObject.transform.SetParent(waypointRoot,false);

            Waypoint waypoint = waypointObject.GetComponent<Waypoint>();

            Waypoint branchedFrom = Selection.activeGameObject.GetComponent<Waypoint>();
            branchedFrom.branches.Add(waypoint);

            waypoint.transform.position = branchedFrom.transform.position;
            waypoint.transform.forward = branchedFrom.transform.forward;

            Selection.activeGameObject = waypoint.gameObject;
        }

        void CreateWaypoints()
        {
            GameObject waypointObject = new GameObject("Waypoint_" + waypointRoot.childCount,typeof(Waypoint)); 
            waypointObject.transform.SetParent(waypointRoot, false);

            Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
            if(waypointRoot.childCount > 1)
            {
                waypoint.prevWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>();
                waypoint.prevWaypoint.nextWaypoint = waypoint;
                //place the waypoint at the last position
                waypointObject.transform.position = waypoint.prevWaypoint.transform.position;
                waypoint.transform.forward = waypoint.prevWaypoint.transform.forward;
            }

            Selection.activeGameObject = waypoint.gameObject;
            
        }

        void CreateWaypointAfter()
        {
            GameObject waypointObject = new GameObject("Waypoint_" + waypointRoot.childCount,typeof(Waypoint)); 
            waypointObject.transform.SetParent(waypointRoot, false);

            Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

            Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
            waypointObject.transform.position = selectedWaypoint.transform.position;
            waypointObject.transform.forward = selectedWaypoint.transform.forward;

            if(selectedWaypoint.nextWaypoint != null)
            {
                selectedWaypoint.nextWaypoint.prevWaypoint = newWaypoint;
                newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            }

            newWaypoint.prevWaypoint = selectedWaypoint;


            selectedWaypoint.nextWaypoint = newWaypoint;

            newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

            Selection.activeGameObject = newWaypoint.gameObject;
            
            
        }

        void CreateWaypointBefore()
        {
            GameObject waypointObject = new GameObject("Waypoint_" + waypointRoot.childCount,typeof(Waypoint)); 
            waypointObject.transform.SetParent(waypointRoot, false);

            Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();

            Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
            waypointObject.transform.position = selectedWaypoint.transform.position;
            waypointObject.transform.forward = selectedWaypoint.transform.forward;

            if(selectedWaypoint.prevWaypoint != null)
            {
                newWaypoint.prevWaypoint = selectedWaypoint.prevWaypoint;
                newWaypoint.prevWaypoint.nextWaypoint = newWaypoint;
            }

            newWaypoint.nextWaypoint = selectedWaypoint;

            selectedWaypoint.prevWaypoint = newWaypoint;

            newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

            Selection.activeGameObject = newWaypoint.gameObject;
        }

        void DeleteWaypoint()
        {
            Waypoint waypoint = Selection.activeGameObject.GetComponent<Waypoint>();
            if(waypoint.prevWaypoint != null)
            {
                waypoint.prevWaypoint.nextWaypoint = waypoint.nextWaypoint;
            }
            if(waypoint.nextWaypoint != null)
            {
                waypoint.nextWaypoint.prevWaypoint = waypoint.prevWaypoint;
            }
            DestroyImmediate(waypoint.gameObject);
        }
        
    }
}

