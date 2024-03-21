using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteractor : MonoBehaviour
{
   public  GameObject interactor;
    private void OnTriggerEnter(Collider other)
    {
        interactor.GetComponent<CapsuleCollider>().radius = .01f;

    }

    private void OnTriggerExit(Collider other)
    {
        interactor.GetComponent<CapsuleCollider>().radius = .5f;
    }
}
