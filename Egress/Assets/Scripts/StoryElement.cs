using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public void TriggerDialogue() {
        dialogueManager.GetComponent<TextController>().StartDialogue(dialogue);
    }
}

