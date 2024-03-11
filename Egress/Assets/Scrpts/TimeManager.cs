
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
    
    public int stopCDval = 0;

    public float startValue = 1.0f;
    public float endValue = 0.0f;
    public float lerpDuration = 8.0f;
   
    private float currentTime = 0.0f;
    public GameObject Fill; 
    public Slider SlowTimeDurationSlider;
    public Slider SlowTimeSlider;
    public Canvas slider;
    public float SlowTimeDuration = 10;
    public int uses = 3;

    private bool depleted = false;

    float t;
    float lerpedValue;
    private void Start()
    {
        StopTimeDurationSlider.minValue = 0;
        StopTimeDurationSlider.maxValue = 1;
     

    }

    void Update()
    {

        StopTimeDurationSlider.value = stopincval / StopTimeDuration;
 


    }
    void LateUpdate()
    
    {
        Debug.Log(val + "OVER HERE" + "\n Slowmo: " + slowmo);
        Debug.Log("USES: " + uses);
        // ones per in seconds
        TimeInterval += Time.unscaledDeltaTime;
        if (depleted && !slowmo)
        {
        
            currentTime += Time.unscaledDeltaTime;
            t = Mathf.Clamp01(currentTime / lerpDuration);
            lerpedValue = Mathf.Lerp(endValue, startValue, t * 1.2f);
            SlowTimeSlider.value = lerpedValue;
        
            if (SlowTimeSlider.value ==1)
           
            {
                // Reset timer
                currentTime = 0.0f;
                uses = 3;
                depleted = false;
                Debug.Log("Replenished finished!");
                Fill.GetComponent<Image>().color = Color.green;
              
            }
        }
        if (slowmo) {
            currentTime += Time.unscaledDeltaTime;
             t = Mathf.Clamp01(currentTime / lerpDuration);
             lerpedValue = Mathf.Lerp(startValue, endValue, t);
            SlowTimeSlider.value = lerpedValue;
            
            if (currentTime >= lerpDuration)
            {
                // Reset timer
                currentTime = 0.0f;
             
              
               SlowMotion(99);
                Debug.Log("Lerp finished!");
                if (uses <= 0)
                {
                    depleted = true;
                    Fill.GetComponent<Image>().color = Color.red;
                }
                // Optionally, you might want to perform some action when the lerp is finished.
                // For example:
                // Debug.Log("Lerp finished!");
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
                   
                   
                 

                    Debug.Log("FRom Start");
                    if (uses > 0)
                    {
                        Time.timeScale = slowdownFactor;
                        Time.fixedDeltaTime = Time.timeScale * .02f;


                        currentTime = 0.0f;
                        slowmo = true;
                        uses--;
                        Debug.Log("USES: " + uses);
                    }
                    else
                    {
                        depleted = true;
                        Fill.GetComponent<Image>().color = Color.red;
                    }
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
                  
                    val = reset;
                   
                   
                    Debug.Log("ADDITIONAL");
                    if (uses > 0)
                    {
                        Time.timeScale = slowdownFactor;
                        Time.fixedDeltaTime = Time.timeScale * .02f;

                        currentTime = 0.0f;
                        slowmo = true;
                        uses--;
                        Debug.Log("USES: " + uses);
                    }
                    else {
                        depleted = true;
                        Fill.GetComponent<Image>().color = Color.red;
                    }


                }
                else if (v == 99)
                {
                    Debug.Log("REGULAR TIME");
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = .02f;
                    val = reset;
                    slowmo = false;
                    StopTimeOn = false;
                    SlowTimeSlider.value = 1f;
                }
            }
           
        }
    }
}
