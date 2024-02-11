using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool isBroken = false;
    public GameObject teleportsTo;
    private bool switcher = false;
    public Material brokenMaterial = null;
    public Material defaultMaterial = null;
    void Start()
    {
        defaultMaterial = gameObject.GetComponent<Renderer>().material;
        if (isBroken)
        {
            InvokeRepeating("brokenEffect", 1f, 1f);
            
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
        }

        else
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = teleportsTo.transform.position;
        // other.gameObject.transform.Rotate(0, 0, 0, Space.World);
    }
    public void teleporterFixed() {
        CancelInvoke();
    }
}
