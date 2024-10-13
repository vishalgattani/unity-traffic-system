using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    AnimationStateController controller;
    public Waypoint currentWaypoint;
    public int direction;

    private void Awake(){
        controller = GetComponent<AnimationStateController>();
    }
    void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.reachDestination){
            if (currentWaypoint.nextWaypoint != null){
                if (direction == 0){
                    currentWaypoint = currentWaypoint.nextWaypoint;
                }
                else{
                    currentWaypoint = currentWaypoint.previousWaypoint;
                }
                controller.SetDestination(currentWaypoint.GetPosition());
            }
        }
        
    }
}
