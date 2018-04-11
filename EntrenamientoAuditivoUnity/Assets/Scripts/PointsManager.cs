// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    // Limit for possible points obtained in one question
    private static readonly uint MINIMUM_POINTS_TO_OBTAIN = 0;
    private static readonly uint MAXIMUM_POINTS_TO_OBTAIN = 100;

    // Instance used for singleton pattern
    private static PointsManager instance;

    // Total acumulated points
    private uint totalPoints;

    // Texts for displaying points
    public Text totalPointsText;
    public Text obtainedPointsText;

    // Use this for initialization
    void Start()
    {
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

        DontDestroyOnLoad(gameObject);

        totalPoints = 0;
        setTotalPointsText();
        disableObtaindePointsText();
        
        // Subscribes to OnPointsAssignmentNeed (from AnswerManager script) to check when points should be assigned
        AnswerManager.OnPointsAssignmentNeed += assignUserPoints;
    }

    private void OnDisable()
    {
        // Unsubscribes to events
        AnswerManager.OnPointsAssignmentNeed -= assignUserPoints;
    }

    // Assign points to the user according to a given time
    public void assignUserPoints(float time, float minAnswerTime, float maxAnswerTime)
    {
        uint points = caulculatePointsByTime(time, minAnswerTime, maxAnswerTime);
        showObtainedPointsText(points);
        addPointsToTotal(points);
        setTotalPointsText();
    }

    // Calculates corresponding points given a time
    private uint caulculatePointsByTime(float time, float minAnswerTime, float maxAnswerTime)
    {
        if (time <= minAnswerTime)
        {
            return MAXIMUM_POINTS_TO_OBTAIN;
        } 
        else if (time >= maxAnswerTime)
        {
            return MINIMUM_POINTS_TO_OBTAIN;
        }
        else
        {
            
            float points = MAXIMUM_POINTS_TO_OBTAIN / maxAnswerTime * (maxAnswerTime - time);
            return (uint)points;
        }
    }

    // Shows text with obtained points for a limited time
    private void showObtainedPointsText(uint points)
    {
        obtainedPointsText.text = "+" + points.ToString();
        obtainedPointsText.enabled = true;
        Invoke("disableObtaindePointsText", 2f);
    }

    // Hides obtainedPointsText
    private void disableObtaindePointsText()
    {
        obtainedPointsText.enabled = false;
    }

    // Adds the given points to totalPoints
    private void addPointsToTotal(uint points)
    {
        totalPoints += points;
    }

    // Sets the totalPointsText to show current totalPoints
    private void setTotalPointsText()
    {
        totalPointsText.text = "Puntaje: " + totalPoints.ToString();
    }
}
