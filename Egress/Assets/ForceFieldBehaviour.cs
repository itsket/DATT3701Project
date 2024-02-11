using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldBehaviour : MonoBehaviour
{
    public bool beam1Down;
    public bool beam2Down;

    void TurnOff() {
        if (beam1Down && beam2Down)
        {
            gameObject.SetActive(false);
        }
    }
}
