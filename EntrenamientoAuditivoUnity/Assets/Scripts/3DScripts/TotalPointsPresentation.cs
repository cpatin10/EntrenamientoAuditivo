using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPointsPresentation : MonoBehaviour {

    public static uint totalPoints;
    public Text totalPointsText;

    // Use this for initialization
    void Start () {
        setTotalPointsText();
    }

    // Sets the totalPointsText to show points obtained in the game
    private void setTotalPointsText()
    {
        totalPointsText.text = totalPoints.ToString();
    }
}
