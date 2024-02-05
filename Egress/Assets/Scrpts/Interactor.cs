using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
      
        currentObj = null;

    }

    // Update is called once per frame
    void Update()
    {
        
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (currentObj != hitInfo.collider.gameObject) {
                currentObj.GetComponent<MeshRenderer>().material = defaultMaterial;
                currentObj = null;
                defaultMaterial = null;
            }
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                currentObj = hitInfo.collider.gameObject;
                if (defaultMaterial == null)
                {
                    defaultMaterial = currentObj.GetComponent<MeshRenderer>().material;
                }
                currentObj.GetComponent<MeshRenderer>().material = material;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }

            }
            else
            {
               
                   

            }
        }
       
    }
}
