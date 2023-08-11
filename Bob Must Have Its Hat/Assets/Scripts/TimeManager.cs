using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Group of variables that set the slow down factor properties for time managment
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public float slowdownLengthCounter;
    public bool paused;

    void Start()
    {
        // Initializing the folowing variables
        slowdownLengthCounter = slowdownLength;
        paused = false;
    }

    void Update()
    {
        // If the game isn't paused
        if (!paused)
        {
            // Change the time scale values so we create a slow down efect, after som time the time scale return to 1 (normal)
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.fixedDeltaTime += (0.01f / slowdownLength) * Time.unscaledDeltaTime;
            slowdownLengthCounter -= (0.01f / slowdownLength);

            // Clamp the time scale of the game to 1 or 0 so it doesn't go any further
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
        }

        if (paused)
        {
            Time.fixedDeltaTime = 1;
        }

    }

    // Function that sets the variables for the Slowmotion efect
    public void DoSlowmo()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
