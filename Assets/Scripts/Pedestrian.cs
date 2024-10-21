using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject pedestrianPrefab;
    public int numberOfPedestrians;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPedestrians());
    }

    IEnumerator SpawnPedestrians()
    {
        for (int i = 0; i < numberOfPedestrians; i++)
        {
            GameObject pedestrian = Instantiate(pedestrianPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount-1));
            pedestrian.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            pedestrian.transform.position = child.position;
            yield return new WaitForEndOfFrame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
