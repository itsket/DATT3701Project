using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keyplacement : MonoBehaviour
{
    public bool hasKey;
    public bool hasCorrectKey;
    private GameObject currentkey;
    public string correctKey;
    private Vector3 previousPosition;
    public GameObject beam;
    private Vector3 previousSize;
    private Quaternion previousRotation;
    public bool unlocked1 = false;
    public bool unlocked2 = false;
    public bool isExit = false;
    public GameObject exitDoor1;
    public GameObject exitDoor2;
    public GameObject teleporter;
    public void KeyEntered(GameObject key1)
    {
        /*
         when terminal is empty, key enters and saves it prev
        when terminal has a key it moves its current ckey back and
         
         */
       
        if (currentkey != null)
        {
            currentkey.transform.position = previousPosition;
            currentkey.transform.localScale = previousSize;
            currentkey.transform.rotation = previousRotation;
            previousPosition = key1.transform.position;


            currentkey = key1;
            currentkey.transform.position = gameObject.transform.position;
            currentkey.transform.localScale = previousSize * 2;
            currentkey.transform.rotation = gameObject.transform.rotation;
            if (currentkey.GetComponent<StoryElement>().dialogue.name == correctKey)
            {
                Debug.Log("correctKey key1");

                if (unlocked1)
                {
                    beam.GetComponent<TurnOffForceField>().unlocked1 = true;
                    beam.GetComponent<TurnOffForceField>().DestroyBeam();
                }
                if (unlocked2)
                {
                    beam.GetComponent<TurnOffForceField>().unlocked2 = true;
                    beam.GetComponent<TurnOffForceField>().DestroyBeam();
                }
            }
        }
        else if (currentkey == null)
        {
            previousPosition = key1.transform.position;
            previousSize = key1.transform.localScale;
            previousRotation = key1.transform.rotation;
            currentkey = key1;
            currentkey.transform.localScale = previousSize * 2;
            currentkey.transform.rotation = gameObject.transform.rotation;
            if (currentkey.GetComponent<StoryElement>().dialogue.name == correctKey)
            {
                if (unlocked1)
                {
                    beam.GetComponent<TurnOffForceField>().unlocked1 = true;
                    beam.GetComponent<TurnOffForceField>().DestroyBeam();
                }
                if (unlocked2)
                {
                    beam.GetComponent<TurnOffForceField>().unlocked2 = true;
                    beam.GetComponent<TurnOffForceField>().DestroyBeam();
                    teleporter.GetComponent<Teleporter>().canteleport = true;
                }
                if (unlocked2 && unlocked1)
                {
                    beam.GetComponent<TurnOffForceField>().unlocked1 = true;
                    beam.GetComponent<TurnOffForceField>().unlocked2 = true;
                    beam.GetComponent<TurnOffForceField>().DestroyBeam();
                }
                else if (isExit) {
                    exitDoor1.GetComponent<OpenDoor>().isUnlocked = true;
                    exitDoor2.GetComponent<OpenDoor>().isUnlocked = true;
                    currentkey.transform.parent = gameObject.transform;
                }
                
                Debug.Log("correctKey key1");
                currentkey.transform.position = gameObject.transform.position;
            }

            else
            {
                currentkey.transform.position = gameObject.transform.position;
            }
        }
        
    }
}
