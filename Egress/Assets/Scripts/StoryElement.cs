using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryElement : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public bool onTriggerInteract = false;
    public GameObject canvas;
    public GameObject player;
    public bool alreadyEntered = false;

    public void TriggerDialogue()
    {
        if (!onTriggerInteract) { 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogueManager.GetComponent<TextController>().StartDialogue(dialogue);
    }
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
            canvas.GetComponent<Canvas>().enabled = true;
            player.GetComponent<InputManager>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (dialogue.name == "BulletTimeDevice") {
                player.GetComponent<PlayerMotor>().timeManager.canSlowDownTime = true;
            }

        }

    }
}

