using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wethermon : MonoBehaviour
{
    public GameObject turret1;
    public GameObject turret2;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    private bool hasCountedToSeconds;
    private bool completed =false;
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
        door1.GetComponent<OpenDoor>().isUnlocked = true;
        door2.GetComponent<OpenDoor>().isUnlocked = true;
        door3.GetComponent<OpenDoor>().isUnlocked = true;
        door4.GetComponent<OpenDoor>().isUnlocked = true;
        completed = true;
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag.Equals("Player") && completed == false){ 
            turret1.GetComponent<Turret>().enabled = true;
            turret2.GetComponent<Turret>().enabled=true;

            door1.GetComponent<OpenDoor>().isUnlocked = false;
            door2.GetComponent<OpenDoor>().isUnlocked = false;
            door3.GetComponent<OpenDoor>().isUnlocked = false;
            door4.GetComponent<OpenDoor>().isUnlocked = false;
       
        }

     
    }
}
