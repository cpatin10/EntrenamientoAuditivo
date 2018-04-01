// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer{

    private static float startTime = -1f;

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

    // Restores timer to -1
    public void restoreTimer()
    {
        startTime = -1f;
    }

    // Getter for startTime
    public float getStartTime()
    {
        return startTime;
    }
}
