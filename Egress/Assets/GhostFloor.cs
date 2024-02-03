using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GhostFloor : MonoBehaviour
{
public GameObject floor;
    private GameObject currentFloor = null;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "summoner") {
            Summon();
        }
    }
    public void Summon() {
        Vector3 origin = transform.position + transform.forward;
        if (currentFloor == null)
        {
            currentFloor = Instantiate(floor, origin, Quaternion.identity);
            Destroy(currentFloor,4f);
        }
       
    }
}
