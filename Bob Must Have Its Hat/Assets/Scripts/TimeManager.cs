using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public float slowdownLengthCounter;
    public bool paused;

    void Start()
    {
        slowdownLengthCounter = slowdownLength;
        paused = false;
    }

    void Update()
    {
        
        if (!paused)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.fixedDeltaTime += (0.01f / slowdownLength) * Time.unscaledDeltaTime;
            slowdownLengthCounter -= (0.01f / slowdownLength);


            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
        }

        if (paused)
        {
            Time.fixedDeltaTime = 1;
        }
        
    }

    public void DoSlowmo()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    /*

    public float slowMoFactor;// = 0.05f;
    public float slowMoDuration;// = 10f;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time.timeScale 1: " + Time.timeScale);
        // Add 1 to timescale in slowMoDuration time
        Time.timeScale += (1f / slowMoDuration) * Time.unscaledDeltaTime;
        Time.fixedDeltaTime += (0.01f / slowMoDuration) * Time.unscaledDeltaTime;
        // Prevent the timeScale for going above 1
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
        Debug.Log("Time.timeScale 2: " + Time.timeScale);
    }

    public void DoSlowMo(float slowMoFactorRecived, float slowMoDurationRecived)
    {
        Debug.Log("Inside SlowMo");
        slowMoFactor = slowMoFactorRecived;
        slowMoDuration = slowMoDurationRecived;

        Time.timeScale = slowMoFactor;
        // Update the frames every 0.2 seconds, so the game doesnt look laggy when in slowMo
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    */
}
