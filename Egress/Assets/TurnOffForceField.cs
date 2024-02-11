using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffForceField : MonoBehaviour
{
    public bool unlocked1 = false;
    public bool unlocked2 = false;
    void Update()
    {
        
    }
    public void DestroyBeam() {
        if (unlocked1 && unlocked2) { 
        gameObject.SetActive(false);
        }
    }
}
