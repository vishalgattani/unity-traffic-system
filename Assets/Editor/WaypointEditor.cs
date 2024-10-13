using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType){
        if((gizmoType & GizmoType.Selected) != 0){
            Gizmos.color = Color.yellow;
        }
        else {
            Gizmos.color = Color.yellow * 0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, 0.1f);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width/2f),waypoint.transform.position - (waypoint.transform.right * waypoint.width/2f));
        if (waypoint.previousWaypoint != null){
            Gizmos.color = Color.red;
            Vector3 offset = (waypoint.transform.right * waypoint.width/2f);
            Vector3 offsetto = (waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.width/2f);
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetto);
        }
        if (waypoint.nextWaypoint != null){
            Gizmos.color = Color.green;
            Vector3 offset = (waypoint.transform.right * -waypoint.width/2f);
            Vector3 offsetto = (waypoint.nextWaypoint.transform.right * -waypoint.nextWaypoint.width/2f);
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWaypoint.transform.position + offsetto);
        }
        if (waypoint.branches != null){
            foreach(Waypoint branch in waypoint.branches){
                Gizmos.color = Color.blue;
                // Vector3 offset = (waypoint.transform.right * waypoint.width/2f);
                // Vector3 offsetto = (branch.transform.right * branch.width/2f);
                Gizmos.DrawLine(waypoint.transform.position, branch.transform.position);
            }
        }
    }
}
