using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints2 : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject turret;
    public int current = 0;
    public float speed;
    public bool destroyOnEnd = false;
    float WPradius = 1;

    public bool path2 = false;

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
            if (current == 1)
            {
                speed = 75f;
            }
           else if (current == 4)
            {
                speed = 10f;
            }
            else
            {
                speed = 5f;
            }
            
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, step);
      
    }
 
 



}