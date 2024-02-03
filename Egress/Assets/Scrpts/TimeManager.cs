
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.03f;
    public float slowdownLength = 2f;
    float TimeInterval;
    public int val = 5;
    public bool slowmo = false;
    public int reset = 10;
    void Update()
    {

    }
    void LateUpdate()
    {
        // ones per in seconds
        TimeInterval += Time.unscaledDeltaTime;
        if (TimeInterval >= 1)
        {
            TimeInterval = 0;
            Debug.Log("Time Remaining: "+val);
            if (slowmo)
                val--;

            if (val <= 0)
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = .02f;
                val = reset;
                slowmo = false;
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

         
        }

        else if (v == 0)
        {

            Time.timeScale = 0.00001f;
            Time.fixedDeltaTime = .00001f * .02f;
            val = 5;
            slowmo = true;
        }
    }
}
