using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public GameObject Key;
    public Transform Keyarea;

    void Start()
    {
        Key.GetComponent<Rigidbody>().isKinemtic = true;
    }

    void Update()
    {
        
    }
}
