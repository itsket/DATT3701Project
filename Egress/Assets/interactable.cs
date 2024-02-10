using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacttest : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool hasDialogue = true;
    public GameObject keyplacement;
    void Start()
    {
       
    }
    public void Interact() {
        Debug.Log("Interacted " + Random.Range(0,100));
        if (hasDialogue)
        {
            
            gameObject.GetComponent<StoryElement>().TriggerDialogue();
        }
        else {
            if (gameObject.GetComponent<StoryElement>().dialogue.name.Contains("Key")) {
                keyplacement.GetComponent<keyplacement>().KeyEntered(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
