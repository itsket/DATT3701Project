using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitless : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "limitless")
        {
            Debug.Log("Limitless");

           GetComponent<PlayerMotor>().speed = 1;
        }


    }

}
