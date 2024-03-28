using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VisualEffects : MonoBehaviour
{

    UnityEngine.Rendering.Universal.ChromaticAberration chrome;
    public UnityEngine.Rendering.VolumeProfile volumeProf;
    float currentTime = 0;
    public bool on;


    private void Start()
    {
       volumeProf.TryGet(out chrome);
        chrome.intensity.value = 0;


    }
    void Update()
    {
       

        if (on) {
            activateEffects();
        }

      
    }

    void activateEffects() {
       
            currentTime += Time.unscaledDeltaTime * 2f;
            var t = Mathf.Clamp01(currentTime / 2f);
           var lerpedValue = Mathf.Lerp(0f, 1f, t);

            if (currentTime >= 5f)
            {
                // Reset timer
                currentTime = 0.0f;
            on = false;
            }
                Debug.Log("HERE: " + lerpedValue);
            chrome.intensity.value = lerpedValue;
      
        
       
    }
    void deactivateEffects()
    {

    }
}
