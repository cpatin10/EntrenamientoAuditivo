using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    // Factor for calculating points by multiplying
    private static readonly float POINTS_FACTOR = 3f;

    // Instance used for singleton pattern
    private static PointsManager instance;

    // Total acumulated points
    private int totalPoints;

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
    public void assignUserPoints(float time)
    {
        int points = caulculatePointsByTime(time);
        showObtainedPointsText(points);
        addPointsToTotal(points);
        setTotalPointsText();
    }

    // Calculates corresponding points given a time
    private int caulculatePointsByTime(float time)
    {
        float points = 1f / time * POINTS_FACTOR;
        return (int)points;
    }

    // Shows text with obtained points for a limited time
    private void showObtainedPointsText(int points)
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
    private void addPointsToTotal(int points)
    {
        totalPoints += points;
    }

    // Sets the totalPointsText to show current totalPoints
    private void setTotalPointsText()
    {
        totalPointsText.text = "Puntaje: " + totalPoints.ToString();
    }
}
