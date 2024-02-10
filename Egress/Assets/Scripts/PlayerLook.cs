using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Camera camera1;
    private float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
 
    }
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        ;
           //calc camera rotation for looking up and down
           xRotation -=(mouseY * Time.unscaledDeltaTime)* ySensitivity;
        xRotation = Mathf.Clamp(xRotation,-80f, 80f);
        // apply to camera transform
        camera1.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate player to look left and right
        transform.Rotate((mouseX * Time.unscaledDeltaTime) * xSensitivity * Vector3.up);
       
       
    }
}
