using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints1 : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject turret;
    int current = 0;
    public float speed;
    public bool destroyOnEnd = false;
    float WPradius = 1;
    public int path = 1;
   

    void Start ()
    {
     
    }
    void Update() {
      
		if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
                if (destroyOnEnd) {
                    Destroy(gameObject);
                }
            }

            if (current >= 10)
            {
                speed = 100f;
            }
            else
            {
                speed = 4f;
            }
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, step);
      
    }
 
 



}