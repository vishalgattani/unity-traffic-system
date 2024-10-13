using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Tools/Waypoint Manager")]
    public static void Open(){
        GetWindow<WaypointManagerWindow>();

    }

    public Transform waypointRoot;
    // Start is called before the first frame update

    private void OnGUI(){
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));
        if (waypointRoot == null){
            EditorGUILayout.HelpBox("Waypoint Root is null", MessageType.Warning);
        }
        else{
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    void DrawButtons(){
        if (GUILayout.Button("Create Waypoint")){
            CreateWaypoint();
        }
    }

    void CreateWaypoint(){
        GameObject waypointObject = new GameObject("Waypoint "+waypointRoot.childCount,typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot,false);
        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if (waypointRoot.childCount > 1){
            waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;
            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }
}
