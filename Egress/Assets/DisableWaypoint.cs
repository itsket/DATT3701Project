using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWaypoint : MonoBehaviour
{
    public GameObject w;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(w.gameObject.activeSelf == true && other.gameObject.CompareTag("Player"))
        w.GetComponent<WaypointHandler>().disappear();

    }
}
