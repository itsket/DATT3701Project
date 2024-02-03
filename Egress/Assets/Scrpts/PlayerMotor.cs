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
    public TimeManager timeManager;
    public bool inLimitless = false;
 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded= characterController.isGrounded;
        if (isGrounded && inLimitless)
        {
            speed = 1f;
        }
        else if (isGrounded ) { 
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "triggered");
        if (other.gameObject.tag == "platform" && timeManager.slowmo)
        {
            Debug.Log(other.gameObject.name + "triggered");
            
            transform.SetParent(other.transform);
           other.GetComponent<Walkable>().onplat = true;
            // Debug.Log("Entered " + other.name + " parent is " + other.transform.parent.name);


        }

        else if (other.gameObject.tag == "limitless")
        {
            Debug.Log("Limitless");
            inLimitless = true;
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;
            Debug.Log("Left");
            other.GetComponent<Walkable>().onplat = false;
        }
        else if (other.gameObject.tag == "limitless")
        {
            inLimitless = false;
        }
        }
}
