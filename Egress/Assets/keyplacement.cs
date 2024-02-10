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
    public void KeyEntered(GameObject key1)
    {
        /*
         when terminal is empty, key enters and saves it prev
        when terminal has a key it moves its current ckey back and
         
         */

        if (currentkey != null && currentkey.GetComponent<StoryElement>().dialogue.name != correctKey)
        {
            currentkey.transform.position = previousPosition;
            previousPosition = key1.transform.position;


            currentkey = key1;
            currentkey.transform.position = gameObject.transform.position;
            if (currentkey.GetComponent<StoryElement>().dialogue.name == correctKey)
            {
                Debug.Log("correctKey key1");

            }
        }
        else if (currentkey == null)
        {
            previousPosition = key1.transform.position;
            currentkey = key1;

            if (currentkey.GetComponent<StoryElement>().dialogue.name == correctKey)
            {
                Debug.Log("correctKey key1");
                currentkey.transform.position = gameObject.transform.position;
            }
            else
            {
                currentkey.transform.position = gameObject.transform.position;
            }
        }
        else {
            Debug.Log("correctKey key1");
        }
    }
}
