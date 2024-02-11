
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.03f;
    public float slowdownLength = 2f;
    float TimeInterval;
    public int val;
    public bool slowmo = false;
    public int reset = 10;
    public bool canSlowDownTime = false;

    //public float StopTimeCurrentCD = 0.0f;
    // These are for the duration of the time effects if we want it change the names later
    public Slider StopTimeDurationSlider;
    public float StopTimeDuration = 10f;
    public bool StopTimeOn = false;
    public int incval = 0;
    public int stopincval = 0;

    //these two numbers are for the inputmanager to have their own values
    public int slowCDval = 0;
    public int stopCDval = 0;


    public Slider SlowTimeDurationSlider;
    public Canvas slider;
    public float SlowTimeDuration = 10;

    private void Start()
    {
        StopTimeDurationSlider.minValue = 0;
        StopTimeDurationSlider.maxValue = 1;
        SlowTimeDurationSlider.minValue = 0;
        SlowTimeDurationSlider.maxValue = 1;


    }

    void Update()
    {

        StopTimeDurationSlider.value = stopincval / StopTimeDuration;
        SlowTimeDurationSlider.value = incval / SlowTimeDuration;


    }
    void LateUpdate()
    {
        // ones per in seconds
        TimeInterval += Time.unscaledDeltaTime;
        if (TimeInterval >= 1)
        {
            TimeInterval = 0;
            //Debug.Log("Time Remaining: " + val);
            if (slowmo)
            {
               // SlowTimeDurationSlider.gameObject.SetActive(true);
                val--;
                incval++;
                slowCDval++;
            }

            if (StopTimeOn)
            {
               // StopTimeDurationSlider.gameObject.SetActive(true);
                stopincval++;
                stopCDval++;
            }

            if (stopCDval >= 10)
            {
                stopCDval = 0;
            }
            else if (slowCDval >= 8)
            {
                slowCDval = 0;
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
                StopTimeDurationSlider.gameObject.SetActive(false);
                SlowTimeDurationSlider.gameObject.SetActive(false);

            }


        }
    }
    public void SlowMotion(int v)
    {
        if (canSlowDownTime)
        {
            slider.GetComponent<Canvas>().enabled = true;
            if (!slowmo)
            {
                if (v == 0)
                {
                    Time.timeScale = 0.00001f;
                    Time.fixedDeltaTime = .00001f * .02f;
                    StopTimeOn = true;

                    slowmo = true;
                }

                else if (v==1)
                {
                    Time.timeScale = slowdownFactor;
                    Time.fixedDeltaTime = Time.timeScale * .02f;

                    val = reset;
                    slowmo = true;



                }

            }

            else
            {
                if (v == 0)//time is stopped
                {

                    Time.timeScale = 0.00001f;
                    Time.fixedDeltaTime = .00001f * .02f;
                    val = reset;
                    slowmo = true;//comment slowmo out later 
                    StopTimeOn = true;



                }
                else if (v == 1)
                {
                    Time.timeScale = slowdownFactor;
                    Time.fixedDeltaTime = Time.timeScale * .02f;

                    val = reset;
                    slowmo = true;



                }
                else if (v == 99)
                {
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = .02f;
                    val = reset;
                    slowmo = false;
                    StopTimeOn = false;
                }
            }
           
        }
    }
}
