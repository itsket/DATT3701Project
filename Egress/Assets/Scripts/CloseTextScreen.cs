using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTextScreen : MonoBehaviour
{
    public GameObject textScreen;
    public GameObject player;
    public void closeButton() {
        textScreen.GetComponent<Canvas>().enabled = false;
        player.GetComponent<InputManager>().enabled = true;
    }
}
