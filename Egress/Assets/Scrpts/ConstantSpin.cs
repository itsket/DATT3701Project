using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, .5f, 0 * Time.deltaTime);
    }
}
