using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffForceField : MonoBehaviour
{
    public bool unlocked1 = false;
    public bool unlocked2 = false;
    public GameObject forceField;
    void Update()
    {
        
    }
    public void DestroyBeam() {
        if (unlocked1 && unlocked2) {
            if (gameObject.name == "beam") {
                forceField.GetComponent<ForceFieldBehaviour>().beam1Down = true;
                forceField.GetComponent<ForceFieldBehaviour>().TurnOff();
            }

            else if (gameObject.name == "beam2") {
                forceField.GetComponent<ForceFieldBehaviour>().beam2Down = true;
                forceField.GetComponent<ForceFieldBehaviour>().TurnOff();
            }
        gameObject.SetActive(false);


        }
    }
}
