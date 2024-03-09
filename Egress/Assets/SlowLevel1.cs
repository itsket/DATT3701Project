using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class slowLevel_1 : MonoBehaviour
{
    public bool triggeredlimitless = false;
   private Rigidbody rb;
    private Vector3 max;
    public bool killer = false;
     public bool resetAreaOnKill = false;
    public bool summoner = false;
    public GameObject respawnPoint;
    private void Awake()
    {
         rb = gameObject.GetComponent<Rigidbody>();

        if (summoner) {
            gameObject.tag = "summoner";
        }

    }
    private void FixedUpdate()
    {
        if (triggeredlimitless) {
            rb.velocity = max;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "limitless") {
            Debug.Log("Limitless");
            triggeredlimitless = true;
            max = rb.velocity / 20;
            rb.velocity = max;
        }

        else if (other.gameObject.tag == "Player" && killer) {
            other.gameObject.SendMessage("Die");
            other.gameObject.SendMessage("ResetRoom");
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggeredlimitless)
        {
            rb.velocity = rb.velocity * 20;
            triggeredlimitless = false;
        }
    }
}
