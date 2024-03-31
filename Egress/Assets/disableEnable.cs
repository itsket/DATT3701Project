using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableEnable : MonoBehaviour, IInteractable
{
    public GameObject[] enableThis;
    public GameObject[] disableThis;
    public void Interact()
    {
        int i = 0;
        while (i< enableThis.Length) {
            enableThis[i].SetActive(true);
        }
        i = 0;
        while (i< disableThis.Length) {
            disableThis[i].SetActive(false);
        
        }
       
    }


}
