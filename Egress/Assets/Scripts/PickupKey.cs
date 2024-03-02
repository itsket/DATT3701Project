using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public GameObject Key;
    public Transform Keyarea;

    void Start()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
      if(Input.GetKey(KeyCode.F))  {
        Drop();
      }
    }
    public void Drop()
    {
        Keyarea.DetachChildren();
        Key.transform.eulerAngles = new Vector3(Key.transform.position.x, Key.transform.position.z, Key.transform.position.y);
        Key.GetComponent<Rigidbody>().isKinematic = false;
        Key.GetComponent<MeshCollider>().enabled = true;
    }
   public void Pickup()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;
        Key.transform.position = Keyarea.transform.position;
        Key.transform.rotation = Keyarea.transform.rotation;

        Key.GetComponent<MeshCollider>().enabled = false;
        Key.transform.SetParent(Keyarea);


    }
   private void OnTriggerStay(Collider other)
   {
    if(other.gameObject.tag == "Player"){
        if(Input.GetKey(KeyCode.E)){
            Pickup();
        }
    }
   }
}
