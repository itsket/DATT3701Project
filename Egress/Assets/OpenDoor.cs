using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isUnlocked = false;
    public GameObject moveto;

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked) {
            float step = 3f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveto.transform.position, step);
        }
    }
}
