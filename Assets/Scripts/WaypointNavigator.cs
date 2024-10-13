using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    AnimationStateController controller;
    public Waypoint currentWaypoint;

    private void Awake(){
        controller = GetComponent<AnimationStateController>();
    }
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.reachDestination){
            if (currentWaypoint.nextWaypoint != null){
                currentWaypoint = currentWaypoint.nextWaypoint;
                controller.SetDestination(currentWaypoint.GetPosition());
            }
        }
        
    }
}
