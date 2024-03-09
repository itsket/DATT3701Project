using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {       

            other.gameObject.GetComponent<Damage>().respawn = checkpoint;
        }
    }
}
