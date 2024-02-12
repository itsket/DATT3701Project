using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public GameObject respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
        }
        else {
            other.gameObject.transform.position = respawnPoint.transform.position;
            other.gameObject.transform.rotation = respawnPoint.transform.rotation;

        }
    }
}
