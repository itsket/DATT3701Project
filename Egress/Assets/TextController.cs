using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Queue<string> sentences;
    private string nameText;
    // private TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject textScreen;
    public GameObject player;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue) {
        nameText = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) { 
            sentences.Enqueue(sentence); 
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() { 
        if (sentences.Count == 0) {
            if (nameText == "Key 2")
            {
                Debug.Log(nameText + " Behaviour");
            }
            else if (nameText == "Key 3") {
                Debug.Log(nameText+ " Behaviour");
            }
           
                  else if (nameText == " key 1 area")
            {
                Debug.Log(nameText + " Behaviour");
            }
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
       dialogueText.text = sentence;
    }

    void EndDialogue() {
        Debug.Log("Convo over");
        textScreen.GetComponent<Canvas>().enabled = false;
        player.GetComponent<InputManager>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
