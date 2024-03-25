using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Terminal : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public GameObject keybone;
    public string keyname;
    public GameObject keyGoesHere;
    public GameObject beam;
    public bool beam1;
    public bool beam2;
    public GameObject forceField;
    private void Awake()
    {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
        gameObject.GetComponent<Outline>().OutlineWidth = 6f;
        gameObject.GetComponent<Outline>().enabled = false;
    }
    public void Interact()
    {
        if (keybone.transform.childCount > 0 && keybone.transform.GetChild(0).gameObject.GetComponent<StoryElement>().dialogue.name.Equals(keyname))
        {
            keyGoesHere.GetComponent<keyplacement>().KeyEntered(keybone.transform.GetChild(0).gameObject);
            keybone.transform.DetachChildren();



            if (beam1)
            {
                forceField.GetComponent<ForceFieldBehaviour>().beam1Down = true;
                forceField.GetComponent<ForceFieldBehaviour>().TurnOff();
            }
            else if (beam2)
            {
                forceField.GetComponent<ForceFieldBehaviour>().beam2Down = true;
                forceField.GetComponent<ForceFieldBehaviour>().TurnOff();

            }
            if (beam != null)
                beam.SetActive(false);
        }
        else { 
            
        }
        
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
