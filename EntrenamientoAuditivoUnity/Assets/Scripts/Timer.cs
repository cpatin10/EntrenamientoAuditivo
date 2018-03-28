using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private static float questionStartTime;

    // Instance used for singleton pattern
    private static Timer instance;

    // Use this for initialization
    void Start () {

        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        questionStartTime = Time.time;
    }

    // Resets the questionStartTime to current time
    public static void resetQuestionStartTime()
    {
        questionStartTime = Time.time;
    }

    // Gets the time that has passed since questionStartTime
    public static float getTimeSinceIntervalStart()
    {
        return Time.time - questionStartTime;
    }
}
