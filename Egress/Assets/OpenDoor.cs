using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isUnlocked = false;
    public GameObject unlockPostion;
    public GameObject secondPosition;
    // Update is called once per frame
    void Update()
    {
        if (isUnlocked)
        {
            float step = 3f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, unlockPostion.transform.position, step);
        }

        else if (!secondPosition.Equals(null) && !isUnlocked) {
            float step = 3f * Time.unscaledDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, secondPosition.transform.position, step);
        }
    }
}
