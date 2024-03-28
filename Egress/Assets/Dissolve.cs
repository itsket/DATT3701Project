using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public float dissolveTime = 3f;
    public Material dissolveMaterial;
    public bool activateDis = false;

    public bool ReverseactivateDis = false;

    public float maxCutoffHeight = 1.5f;
    public float minCutoffHeight = -0.5f;

    public void Update()
    {
        if (activateDis)
        {
            dissolveActivate();
            Debug.Log("activated");
        }
        if (ReverseactivateDis)
        {
            reverseDissolveEffect();
        }

    }
    public void dissolveActivate()
    {

        StartCoroutine(PerformDissolve(minCutoffHeight,maxCutoffHeight, dissolveTime));

    }

    public void reverseDissolveEffect(bool reverse = true)
    {
        float startValue = reverse ? maxCutoffHeight : minCutoffHeight;
        float endValue = reverse ? minCutoffHeight : maxCutoffHeight;

        StartCoroutine(PerformDissolve(startValue, endValue, dissolveTime));
    }

    // Coroutine for performing the dissolve effect
    private IEnumerator PerformDissolve(float startValue, float endValue, float time)
    {
        float elapsedTime = 0f;

        // Loop until the dissolve effect is complete
        while (elapsedTime < time)
        {
            // Interpolate the dissolve value based on the elapsed time
            float dissolveValue = Mathf.Lerp(startValue, endValue, elapsedTime / time);
            Debug.Log("Dissolving Value" + dissolveValue);

            // Set the dissolve value in the material
            dissolveMaterial.SetFloat("_Cutoff_height", dissolveValue);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the dissolve effect completes with the end value
        dissolveMaterial.SetFloat("_Cutoff_height", endValue);
    }

    // Call this function to reset the dissolve effect
    public void ResetDissolveEffect()
    {
        // Set the dissolve value back to 0
        dissolveMaterial.SetFloat("_Cutoff_height", 0f);
    }


}
