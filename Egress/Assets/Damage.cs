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
    public GameObject respawn;
    public void Die()
    {
      
        gameObject.transform.position = respawn.transform.position;
    }

    public void ResetRoom() { 
    turret1.GetComponent<Turret>() .enabled = false;
        turret2.GetComponent<Turret>().enabled = false;
    }
}
