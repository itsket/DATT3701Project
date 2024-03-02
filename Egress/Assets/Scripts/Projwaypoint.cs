using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projwaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;
    private Transform previousParent;

    public TimeManager timeManager;


    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player && timeManager.slowmo)
        {

            player = other.gameObject;
            other.transform.SetParent(transform);
            // Debug.Log("Entered " + other.name + " parent is " + other.transform.parent.name);

            Debug.Log(timeManager.slowmo);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            other.transform.parent = null;
            Debug.Log("Left");
        }
    }
}
