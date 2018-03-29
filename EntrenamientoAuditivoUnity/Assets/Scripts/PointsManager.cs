using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    // Factor for calculating points by multiplying
    private static readonly float POINTS_FACTOR = 3f;

    // Instance used for singleton pattern
    private static PointsManager instance;

    // Total acumulated points
    private int totalPoints;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Puntos: " + totalPoints);
    }

    // Calculates corresponding points given a time
    public int caulculatePointsByTime(float time)
    {
        float points = 1f / time * POINTS_FACTOR;
        return (int)points;
    }
}
