using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool isBroken = false;
    public GameObject teleportsTo;
    private bool switcher = false;
    private bool canteleport;
    public Material brokenMaterial = null;
    public Material defaultMaterial = null;
    void Start()
    {
        defaultMaterial = gameObject.GetComponent<Renderer>().material;
        if (isBroken)
        {
            InvokeRepeating("brokenEffect", .01f, .01f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    void brokenEffect()
    {
        switcher = !switcher;
        if (switcher)
        {

            gameObject.GetComponent<Renderer>().material = brokenMaterial;
            canteleport = false;
        }

        else
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
            canteleport = true;
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canteleport && Time.timeScale != Time.unscaledTime)
        {
            other.gameObject.transform.position = teleportsTo.transform.position;
        }
        
        // other.gameObject.transform.Rotate(0, 0, 0, Space.World);
    }
    public void teleporterFixed() {
        CancelInvoke();
    }
}
