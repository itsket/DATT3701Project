using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;


 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded= characterController.isGrounded;
        if (isGrounded )
        {
            speed = 5f;
        }
        else
        {
            speed = 4.5f;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero; 
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection)*speed * Time.unscaledDeltaTime);
        playerVelocity.y += gravity * Time.unscaledDeltaTime;
        
        characterController.Move(playerVelocity * Time.unscaledDeltaTime);
       // Debug.Log(playerVelocity.y);

    }

    public void Jump()
    {
        Debug.Log("Jumped");
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -(jumpHeight) * gravity);
        }
        
    }


}
