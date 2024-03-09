using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wethermon : MonoBehaviour
{
    public GameObject turret1;
    public GameObject turret2;
    private bool hasCountedToSeconds;
    private float timer;
    public float countToSeconds;
    public GameObject player;

    private void Update()
    {
        if (!hasCountedToSeconds)
        {
            timer += Time.deltaTime; 

            if (timer >= countToSeconds)
            {
                hasCountedToSeconds = true;
                CountComplete();
            }
        }
    }

    void CountComplete()
    {
        turret1.GetComponent<Turret>().enabled = false;
        turret2.GetComponent<Turret>().enabled = false;
        Debug.Log("Counted to " + countToSeconds + " seconds!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")){ 
            turret1.GetComponent<Turret>().enabled = true;
            turret2.GetComponent<Turret>().enabled=true;
         
        }
    }
}
