using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer{

    private static float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }

    // Resets the startTime to current time
    public void resetQuestionStartTime()
    {
        startTime = Time.time;
    }

    // Gets the time that has passed since startTime
    public float getTimeSinceStartTime()
    {
        return Time.time - startTime;
    }
}
