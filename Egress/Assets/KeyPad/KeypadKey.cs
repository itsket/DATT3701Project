using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour, IInteractable
{
    public string key;

    void Awake() {
        gameObject.AddComponent<Outline>();
        gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
        gameObject.GetComponent<Outline>().OutlineWidth = 6f;
        gameObject.GetComponent<Outline>().enabled = false;
    }
    public void Interact()
    {
        SendKey();
    }

    public void SendKey()
    {
        this.transform.GetComponentInParent<keypad>().PasswordEntry(key);
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