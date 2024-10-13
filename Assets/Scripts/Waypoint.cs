using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;
    [Range(0f,5f)]
    public float width = 1f;

    public List<Waypoint> branches;

    [Range(0f,1f)]
    public float branchRatio = 0.5f;

    public Vector3 GetPosition(){
        Vector3 minBound = transform.position + transform.right * width/2f;
        Vector3 maxBound = transform.position - transform.right * width/2f;
        return Vector3.Lerp(minBound, maxBound, Random.Range(0, 1f)); // randomized path from a waypoint to another within the width

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
