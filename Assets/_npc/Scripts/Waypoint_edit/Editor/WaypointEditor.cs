using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace baponkar
{
    [InitializeOnLoad]
    public class WaypointEditor
    {
    [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy | GizmoType.Pickable | GizmoType.Selected)]
        static void OnDrawGizmos(Waypoint waypoint, GizmoType gizmoType)
        {
            if((gizmoType & GizmoType.Selected) != 0)
            {
                Gizmos.color = Color.yellow;
            }
            else
            {
                Gizmos.color = Color.yellow*0.5f;
            }
            

            Gizmos.DrawSphere(waypoint.transform.position, 0.5f);
            Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right*waypoint.width/2f),waypoint.transform.position - (waypoint.transform.right*waypoint.width/2f));
            
            if(waypoint.prevWaypoint != null)
            {
                Gizmos.color = Color.red;

                Vector3 offset = waypoint.transform.right * waypoint.width/2f;
                Vector3 offsetTo = waypoint.prevWaypoint.transform.right * waypoint.prevWaypoint.width/2f;
                Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.prevWaypoint.transform.position + offsetTo);
            }

            if(waypoint.nextWaypoint != null)
            {
                Gizmos.color = Color.green;

                Vector3 offset = waypoint.transform.right * -waypoint.width/2f;
                Vector3 offsetTo = waypoint.nextWaypoint.transform.right * -waypoint.nextWaypoint.width/2f;
                Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWaypoint.transform.position + offsetTo);
            }

            if(waypoint.branches != null)
            {
                Gizmos.color = Color.blue;
                foreach(Waypoint branch in waypoint.branches)
                {
                    Gizmos.DrawLine(waypoint.transform.position, branch.transform.position);
                }
            }
            
        }
    }
}
