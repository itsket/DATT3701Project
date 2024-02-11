using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    [SerializeField]
    private Image ProgressImage;
    [SerializeField]
    private float Defaultspeed = 1f;
    [SerializeField]
    private UnityEvent<float> OnProgress;//not needed

    [SerializeField]
    private UnityEvent OnCompleted;

    private Coroutine AnimationCoroutine;

    private void Start()
    {
        if(ProgressImage.type != Image.Type.Filled)
        {
            this.enabled = false;
        }
    }

    public void SetProgress(float Progress)
    {
        SetProgress(Progress, Defaultspeed);

    }

    public void SetProgress(float Progress, float Speed)
    {
        if(Progress < 0 || Progress>1) 
        {
            Debug.LogWarning($"Invalid progress passed, expected value is between 0 and 1. Got {Progress}");
            Progress = Mathf.Clamp01(Progress);
        }
        if (Progress != ProgressImage.fillAmount)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(AnimateProgress(Progress, Speed));
        }
    }

    private IEnumerator AnimateProgress (float progress, float speed)
    {
        float time = 0;
        float initialProgress = ProgressImage.fillAmount;


        while (time < 1)
        {
            ProgressImage.fillAmount = Mathf.Lerp(initialProgress, progress, time);
            time += Time.deltaTime*speed;

            OnProgress?.Invoke(ProgressImage.fillAmount);
            yield return null;
        }

        ProgressImage.fillAmount = progress;
        OnProgress?.Invoke(progress);
        OnCompleted.Invoke();

    }




}
