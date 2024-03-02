
using UnityEngine;

public class TimeManager1 : MonoBehaviour
{
    public float slowdownFactor = 0.03f;
    public float slowdownLength = 2f;
    float TimeInterval;
    public int val = 10;
    public bool slowmo = false;
    public bool canSlowDownTime = false;
    public int reset = 10;
    public float defaultTimeScale;
    public float defaultDeltaTime;
   
    void Update()
    {

    }
    private void Start()
    {
        defaultTimeScale = Time.timeScale;
        defaultDeltaTime = Time.deltaTime;
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
                Time.timeScale = defaultTimeScale;
                Time.fixedDeltaTime = defaultDeltaTime;
                val = reset;
                slowmo = false;
            }
        }
    }
    public void SlowMotion(int v)
    {

        if (canSlowDownTime)
        {

            if (!slowmo)
            {
                if (v == 0)
                {
                    Time.timeScale = 0.00001f;
                    Time.fixedDeltaTime = .00001f * .02f;
                    val = reset / 2;
                    slowmo = true;
                }

                else if (v == 1)
                {
                    Time.timeScale = slowdownFactor;
                    Time.fixedDeltaTime = Time.timeScale * .02f;
                    val = reset;
                    slowmo = true;
                }







            }
            else
            {
                if (v == 0)
                {
                    Time.timeScale = 0.00001f;
                    Time.fixedDeltaTime = .00001f * .02f;
                    val = reset / 2;
                    slowmo = true;
                }

                else if (v == 99)
                {
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = .02f;
                    val = reset;
                    slowmo = false;
                }
            }

            Debug.Log("SlowMotion");
        }
    }
}
