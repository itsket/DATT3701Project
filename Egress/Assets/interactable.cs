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
      
            gameObject.GetComponent<Outline>().enabled = false;
    }

    void Awake()
    {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
        gameObject.GetComponent<Outline>().OutlineWidth = 6f;
    }
    public void Interact() {
        Debug.Log("Interacted " + Random.Range(0,100));
        if (hasDialogue)
        {
            
            gameObject.GetComponent<StoryElement>().TriggerDialogue();
        }
      
            if (gameObject.GetComponent<StoryElement>().dialogue.name.Contains("Key_1")) {
                keyplacement.GetComponent<keyplacement>().KeyEntered(gameObject);
            }
        else if (gameObject.GetComponent<StoryElement>().dialogue.name.Contains("Key_2_placer"))
        {

            if (keybone.transform.childCount > 0)
            {
                keyplacement.GetComponent<keyplacement>().KeyEntered(keybone.transform.GetChild(0).gameObject);
                keybone.transform.DetachChildren();
            }
        }
        else if (gameObject.GetComponent<StoryElement>().dialogue.name.Contains("Key_2"))
            {

                gameObject.GetComponent<PickupKey>().Pickup();
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
