using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public bool sequence1;
    public float s1;
    public Component[] arr;
    private void Start()
    {
      
    }
    private void Update()
    {
        if(sequence1)
        seqenceStart();
    }
    public void seqenceStart() {
        if (obj1.GetComponent<ConstantSpin>().y < 2.5f)
        {
           
            s1 = obj1.GetComponent<ConstantSpin>().y += .08f * Time.deltaTime;

        }




    }
}
