using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.VFX;

public class NahIdWin : MonoBehaviour
{

    public GameObject player;
    public bool active = true;
    public float distanceBetween;
    public float a;
    public Color beginning;
    public Color end;
    public GameObject objectEffects;
    public Color currentColor;
    public Material materialOnObject;
    // Update is called once per frame
    private void Start()
    {
        a = 20f;
        materialOnObject.SetColor("_EmissionColor", new Color(1,1,1));
        currentColor = Color.white;

    }
    void Update()
    {
       
            
            Infinity();
    }

    void Infinity()
    {
        distanceBetween = Vector3.Distance(transform.position, player.transform.position);
       
        if (distanceBetween <= a)
            {
            float t = Mathf.InverseLerp(0, 135f, distanceBetween);
            objectEffects.GetComponent<VisualEffect>().SetVector4("Color02", Color.Lerp(currentColor, end, t));
            objectEffects.GetComponent<VisualEffect>().SetFloat("Size", objectEffects.GetComponent<VisualEffect>().GetFloat("Size") * 1.078f);
            currentColor = Color.Lerp(currentColor, end, t);
            materialOnObject.SetColor("_EmissionColor", Color.red * 20);
           
            player.GetComponent<PlayerMotor>().playerSpeedSetter = player.GetComponent<PlayerMotor>().playerSpeedSetter / 1.2f;
                a -= 1f;
            Debug.Log("AAAAAAAAAA");
            }


            else if (distanceBetween >= a + 1f)
            {
                if (a >= 20f) {  
            
                } else
                {
                float t = Mathf.InverseLerp(0, 50f, distanceBetween);
                objectEffects.GetComponent<VisualEffect>().SetVector4("Color02", Color.Lerp(currentColor, beginning, t));
                objectEffects.GetComponent<VisualEffect>().SetFloat("Size", objectEffects.GetComponent<VisualEffect>().GetFloat("Size") / 1.08f);
               player.GetComponent<PlayerMotor>().playerSpeedSetter = player.GetComponent<PlayerMotor>().playerSpeedSetter * 1.2f;
                    a += 1f;
                currentColor = Color.Lerp(currentColor, beginning, t);
                materialOnObject.SetColor("_EmissionColor", Color.white*5);

            }
              
            }
           
    }

    
    
}
