
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.03f;
    public float slowdownLength = 2f;
    float TimeInterval;
    public int val = 5;
    public bool slowmo = false;
    public int reset = 10;

    //public float StopTimeCurrentCD = 0.0f;
    public Slider StopTimeSlider;
    public float StopTimeCooldown = 10f;
    public bool StopTimeOn = false;
    public int incval = 0;
    public int stopincval = 0;

    public Slider SlowTimeSlider;
    public float SlowTimeDuration = 5f;

    private void Start()
    {
        StopTimeSlider.minValue = 0;
        StopTimeSlider.maxValue = 1;
        SlowTimeSlider.minValue = 0;
        SlowTimeSlider.maxValue = 1;
        

    }

    void Update()
    {

        StopTimeSlider.value = stopincval / StopTimeCooldown;
        SlowTimeSlider.value = incval / SlowTimeDuration;



    }
    void LateUpdate()
    {
        // ones per in seconds
        TimeInterval += Time.unscaledDeltaTime;
        if (TimeInterval >= 1)
        {
            TimeInterval = 0;
            Debug.Log("Time Remaining: " + val);
            if (slowmo)
            {
                val--;
                incval++;
            }
            if (StopTimeOn)
            {
                stopincval++;
            }


            if (val <= 0)
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = .02f;
                val = reset;
                slowmo = false;
                StopTimeOn = false;
                incval = 0;
                stopincval = 0;


            }
        }
    }
    public void SlowMotion(int v)
    {
       
        if (!slowmo)
        {
            if (v == 0)
            {
                Time.timeScale = 0.00001f;
                Time.fixedDeltaTime = .00001f * .02f;
                StopTimeOn = true;



            }

            else {
                Time.timeScale = slowdownFactor;
                Time.fixedDeltaTime = Time.timeScale * .02f;
                val = 5;


           

            }
         
               
            
           
            
            slowmo = true;
            Debug.Log("SlowMotion");
        }

        else if(v == 1)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = .02f;
            val = reset;
            slowmo = false;
            StopTimeOn=false;
            incval = 0;
            stopincval = 0;

        }

        else if (v == 0)//time is stopped
        {

            Time.timeScale = 0.00001f;
            Time.fixedDeltaTime = .00001f * .02f;
            val = 5;
            slowmo = true;
            StopTimeOn = true;



        }
    }
}
