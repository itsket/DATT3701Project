using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool gotHit = false;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject respawn;
    public GameObject challengeRoom;
    public void Die()
    {
      
        gameObject.transform.position = respawn.transform.position;
    }

    public void ResetRoom() { 
    turret1.GetComponent<Turret>() .enabled = false;
        turret2.GetComponent<Turret>().enabled = false;
        door1.GetComponent<OpenDoor>().isUnlocked = true;
        door2.GetComponent<OpenDoor>().isUnlocked = true;
        door3.GetComponent<OpenDoor>().isUnlocked = true;
        door4.GetComponent<OpenDoor>().isUnlocked = true;
        challengeRoom.GetComponent<Wethermon>().isInRoom = false;
        challengeRoom.GetComponent<Wethermon>().timer = 0f;
    }
}
