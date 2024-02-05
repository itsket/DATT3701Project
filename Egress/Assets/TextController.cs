using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

}
