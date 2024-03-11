using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
  
    public GameObject teleportsTo;
    private bool switcher = false;
    public bool canteleport = true;
    public Material brokenMaterial = null;
    public Material defaultMaterial = null;
    void Start()
    {
       if (!canteleport)
            GetComponent<Renderer>().material = brokenMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canteleport && other.tag.Equals("Player"))
        {
            other.gameObject.transform.position = teleportsTo.transform.position;
            GetComponent<Renderer>().material = defaultMaterial;
        }
        
        // other.gameObject.transform.Rotate(0, 0, 0, Space.World);
    }
 
}
