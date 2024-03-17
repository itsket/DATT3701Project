using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
 
    public GameObject nextPoint;
    public bool disableOnStart;
    public GameObject[] W;
    public bool isHomeWaypoint;
    public int currentWaypoint = 0;
    private void Start()
    {
        if (disableOnStart) {
            gameObject.SetActive(false);
        }
        currentWaypoint = 0;
    }

    public void disappear() {
       
        if (!isHomeWaypoint)
        {
            if (nextPoint != null)
                nextPoint.SetActive(true);
          
            gameObject.SetActive(false);
        }

        else {
          
                W[currentWaypoint].SetActive(true);
                gameObject.SetActive(false);
            
        }
  

    
    }

    private void OnDisable()
    {
        currentWaypoint++;
    }
}
