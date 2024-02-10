using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    private float defspeed;
    public bool destroyOnEnd = false;
    float WPradius = 1;

    private Transform previousParent;
    public bool moveOnTrigger = false;
    private bool playerOn = false;

    void Start () {
        defspeed = speed;
    }

    void Update() {
      if(moveOnTrigger)
        {
            if (playerOn) {
                if (current >= waypoints.Length) {
                  
                }

                else
                {
                    if (Vector3.Distance(waypoints[current].transform.position, transform.position) < 1)
                    {
                        current++;
                        if (current >= waypoints.Length)
                        {

                            if (destroyOnEnd)
                            {
                                Destroy(gameObject);
                            }
                        }

                    }
                    if (current == 2)
                    {
                        speed = 1;
                    }
                    else {
                        speed = defspeed;
                    }
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, step);
                }
            }
        }
        else { 
		if(Vector3.Distance(waypoints[current].transform.position, transform.position) < 1)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
                if (destroyOnEnd) {
                    Destroy(gameObject);
                }
            }
        
        }
        float step = speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, step);
      }
    }
 
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered " + other.name);
        if (gameObject.tag == "platform") {
        if (other.gameObject.tag == "Player")
        {
            
           player = other.gameObject;
            other.transform.SetParent(transform);
                playerOn = true;

            
            
         
        }
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
    /*void OnTriggerEnter(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
    */
}