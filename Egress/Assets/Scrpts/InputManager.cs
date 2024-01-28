using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    public TimeManager timeManager;
    private PlayerMotor motor;
    private PlayerLook look;
    

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
      
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Starplat.performed += ctx => timeManager.SlowMotion();
        //onFoot.Jump.performed += ctx => motor.Jump();
        look = GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //tell the player motor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
       
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
