using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningWheel : MonoBehaviour
{
   [SerializeField] Image CircleImg;
   [SerializeField] [Range(0,1)] float progress = 0f;
    void Update()
    {
        CircleImg.fillAmount = progress;
    }
}
