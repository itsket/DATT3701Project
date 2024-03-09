using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    public TimeManager timeManager;
    private PlayerMotor motor;
    private PlayerLook look;
    


    public Slider StopTimeSlider;
    public Slider SlowTimeSlider;

    public float StoptimeCurrentCd = 0f;
    public float SlowtimeCurrentCd = 0f;
    float TimeInterval;
    float stopincval = 0;
    private bool StoptimePressed = false;
    private bool SlowtimePressed = false;

    public int slowCDval = 0;
    public int stopCDval = 0;

    public float StoptimeCooldown = 10f;
  
    float lerped = 1.00f;
    // Start is called before the first frame update

    public float startValue = 1.0f;
    public float endValue = 0.0f;
    public float lerpDuration = 8.0f;

    private float currentTime = 0.0f;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
      
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Starplat.performed += ctx =>
        {
            timeManager.SlowMotion(1);
           // SlowtimePressed = true;
            //checkStoptimeCooldown();
   
        };


        onFoot.zawordo.performed += ctx =>
        {
            //timeManager.SlowMotion(0);
            StoptimePressed = true;
        };
        onFoot.ResetTime.performed += ctx => timeManager.SlowMotion(99);


        //onFoot.Jump.performed += ctx => motor.Jump();
        look = GetComponent<PlayerLook>();
    }

    public void Start()
    {
        StopTimeSlider.minValue = 0;
        StopTimeSlider.maxValue = StoptimeCooldown;
        SlowTimeSlider.minValue = 0.00f;
        SlowTimeSlider.maxValue = 1.00f;
    }
    private void checkStoptimeCooldown()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //tell the player motor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

       // Debug.Log("Stoptime passed:" + StoptimeCurrentCd);
      //  Debug.Log("SlowTime passed:" + SlowtimeCurrentCd);

        //move slider
        StopTimeSlider.value = StoptimeCurrentCd;
      


        //checks if button pressed and cd is finished
        if (StoptimePressed && StoptimeCurrentCd <= 0)
        {
            timeManager.SlowMotion(0);
            StopTimeSlider.value = 1;
            stopCDval = 0;
            //stopincval++;
            StoptimeCurrentCd = StoptimeCooldown; //resets cd counter

            return;
        }

        //checks if button pressed and cd is finished
        if (SlowtimePressed)
        {
         
        
        
           
           
            return;
        }

        else
        {
            StoptimePressed = false;
            SlowtimePressed = false;
        }

        // unscaled time so you will need exactly 10 or 8 seconds for it to be used again, make sure duration is less than this
       
        StoptimeCurrentCd -= Time.unscaledDeltaTime;


       

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
