using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacttest : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Interact() {
        Debug.Log("Interacted " + Random.Range(0,100));
        gameObject.GetComponent<StoryElement>().TriggerDialogue();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
