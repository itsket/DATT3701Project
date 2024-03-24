using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacttest : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool hasDialogue = true;
    public GameObject keyplacement;
    public GameObject keybone;

    void Start()
    {
      
           
    }

    void Awake()
    {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
        gameObject.GetComponent<Outline>().OutlineWidth = 6f;
        gameObject.GetComponent<Outline>().enabled = false;
    }
    public void Interact() {
        Debug.Log("Interacted " + Random.Range(0,100));
        if (hasDialogue)
        {
            
            gameObject.GetComponent<StoryElement>().TriggerDialogue();
        }
      
            
        
      

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void HitByRay()
    {
       
            gameObject.GetComponent<Outline>().enabled = true;
    }
    void NotHitByRay()
    {
      
            gameObject.GetComponent<Outline>().enabled = false;
    }
}
