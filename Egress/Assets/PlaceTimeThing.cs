using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTimeThing : MonoBehaviour, IInteractable
{
    public GameObject obj1;
    public Sequencer sequencer;
    public GameObject player;

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
        obj1.SetActive(true);
        sequencer.sequence1 = true;
      player.GetComponent<CharacterController>().enabled = false;
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
