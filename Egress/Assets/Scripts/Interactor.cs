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
    public Transform InteractorSource;
    public float InteractRange;
    public Material material;
    public Material defaultMaterial;
    private GameObject currentObj;
    public GameObject textdisplay;
    public GameObject player;
    void Start()
    {
      
        currentObj = null;
        textdisplay.GetComponent<Canvas>().enabled = false;

    }
    private void Awake()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (currentObj != null && hitInfo.collider.gameObject != currentObj)
                currentObj.transform.SendMessage("NotHitByRay");
            //defaultMaterial = hitInfo.collider.gameObject.GetComponent<MeshRenderer>().material;
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
             if (currentObj !=null && hitInfo.collider.gameObject != currentObj)
                    currentObj.transform.SendMessage("NotHitByRay");

                currentObj = hitInfo.collider.gameObject;
                currentObj.transform.SendMessage("HitByRay");
                // currentObj.GetComponent<MeshRenderer>().material = material;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                   

                }

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

        else {
       
        }
       
    }
}
