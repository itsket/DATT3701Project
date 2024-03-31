using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    
    public float InteractRange;
    public Material material;
    public Material defaultMaterial;
    private GameObject currentObj;
    public GameObject textdisplay;
    public GameObject player;
    IInteractable interactObj;
    void Start()
    {
      
        currentObj = null;
        textdisplay.GetComponent<Canvas>().enabled = false;
    
    }
    private void Awake()
    {
       
      
    }
    private void Update()
    {
        if (currentObj != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactObj.Interact();
                if (currentObj.GetComponent<PickupKey>())
                    currentObj.GetComponent<PickupKey>().Pickup();

                if (currentObj.GetComponent<disableEnable>()) {

                    currentObj.GetComponent<disableEnable>().Interact();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
          /*  if (currentObj != null && other.gameObject != currentObj)
                currentObj.transform.SendMessage("NotHitByRay");
          */
            //defaultMaterial = hitInfo.collider.gameObject.GetComponent<MeshRenderer>().material;
            if (other.gameObject.TryGetComponent(out IInteractable interactObjsource))
            {
            if (currentObj != null) {
                currentObj.transform.SendMessage("NotHitByRay");
               
            }
            currentObj = other.gameObject;
            interactObj = interactObjsource;
            currentObj.transform.SendMessage("HitByRay");
    

            }
            else
            {


                /* if (currentObj != hitInfo.collider.gameObject)
                 {
                     currentObj.GetComponent<MeshRenderer>().material = defaultMaterial;
                     currentObj = null;
                     defaultMaterial = null;
                 }
                */
            }
        

       
    }

    private void OnTriggerExit(Collider other)
    {
        currentObj.transform.SendMessage("NotHitByRay");
        currentObj = null;
    }

}
