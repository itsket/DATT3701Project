
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
                slowmo = false;
                Time.timeScale = 1f;
                val = reset;
            }
        }
    }
    public void SlowMotion()
    {
       
        if (!slowmo)
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            slowmo = true;
            Debug.Log("SlowMotion");
        }

        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.unscaledDeltaTime;
            val = reset;
            slowmo = false;
        }
    }
}
