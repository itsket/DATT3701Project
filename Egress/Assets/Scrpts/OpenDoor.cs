using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isUnlocked = false;
    public GameObject moveto;

    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (isUnlocked) {

            anim.SetBool("Key", true);

        }
        else
        {
            anim.SetBool("Key", false);
        }

    }
}
