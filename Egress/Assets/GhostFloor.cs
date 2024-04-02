using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GhostFloor : MonoBehaviour
{
public GameObject floor;
    public float disappearSpeed = 1f;
    private GameObject currentFloor = null;
    public Vector3 scaleChange;
  
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
            currentFloor.transform.localScale += scaleChange;
            currentFloor.transform.localRotation = new Quaternion(0f, 0f, 0.707106829f, 0.707106829f);
            Destroy(currentFloor, disappearSpeed);
        }
       
    }
}
