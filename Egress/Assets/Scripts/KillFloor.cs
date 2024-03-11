using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "key" && other.gameObject.tag != "teleporter")
        {
            Destroy(other.gameObject);
        }
        else {
            other.gameObject.SendMessage("Die");

        }
    }
}
