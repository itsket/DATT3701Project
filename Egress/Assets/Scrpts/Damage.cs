using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool gotHit = false;

    public void Die()
    {
       
            Debug.Log("Got hit");
        gotHit = true;
    }
}
