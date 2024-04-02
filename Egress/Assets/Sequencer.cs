using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public GameObject player;
    public bool sequence1;
    public float s1;
    public Component[] arr;
    private float dis = 0f;
    public float timer = 0f;
    public GameObject dialogue;
    private void Start()
    {
        mat1.SetFloat("_DissolveAmount", 0);
        mat2.SetFloat("_DissolveAmount", 0);
        mat3.SetFloat("_DissolveAmount", 0);
    }

    private void Update()
    {
        if(sequence1)
        seqenceStart();
    }
    public void seqenceStart() {
        timer += .08f * Time.deltaTime;
        if (obj1.GetComponent<ConstantSpin>().y < 3f)
        {

            s1 = obj1.GetComponent<ConstantSpin>().y += .08f * Time.deltaTime;
           
        }
        else { 
            
      //  sequence1 = false;
        }
       
        if (timer > 3.1) {
            
            
            s1 = obj1.GetComponent<ConstantSpin>().y -= .3f * Time.deltaTime;
            if (s1 < 0) {
                sequence1 = false;
                dialogue.GetComponent<StoryElement>().TriggerDialogue();
            }
        }
        dis += .03f * Time.deltaTime;
        mat1.SetFloat("_DissolveAmount",dis);
        mat2.SetFloat("_DissolveAmount", dis);
        mat3.SetFloat("_DissolveAmount", dis);
        mat4.SetFloat("_DissolveAmount", dis);

    }
}
