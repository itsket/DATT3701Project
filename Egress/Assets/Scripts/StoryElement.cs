using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryElement : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public bool onTriggerInteract = false;
    public GameObject textdisplay;
    public GameObject player;
    public bool alreadyEntered = false;
    public GameObject SceneManager;
    public void TriggerDialogue() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogueManager.GetComponent<TextController>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogueOnEnter();
       
    }
 
    public void TriggerDialogueOnEnter()
    {
        if (onTriggerInteract && !alreadyEntered)
        {
            alreadyEntered = true;
            dialogueManager.GetComponent<TextController>().StartDialogue(dialogue);
            textdisplay.GetComponent<Canvas>().enabled = true;
            player.GetComponent<InputManager>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

    }
}

