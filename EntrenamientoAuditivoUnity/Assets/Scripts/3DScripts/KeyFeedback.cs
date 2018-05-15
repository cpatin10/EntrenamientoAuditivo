// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedback : MonoBehaviour
{

    // Time for showing feedback in seconds
    private static readonly float FEEDBACK_TIME = 1.5f;

    // Sets the colors used for feedback
    private static readonly Color CORRECT_COLOR = new Color(0.416f, 0.722f, 0.373f);
    private static readonly Color INCORRECT_COLOR = new Color(1f, 0.553f, 0.373f);

    // Original GameObject color
    private Color originalColor;

    // Use this for initialization
    void Start ()
    {
        originalColor = GetComponent<Renderer>().material.color;

        //Subscribes to OnProcessedInput (from AnswerManager script) method to know when to show correct answer
        AnswerManager.OnProcessedInput += showCorrect;
        TestAnswerManager.OnProcessedInput += showCorrect;
        //Subscribes to OnIncorrectInput (from AnswerManager script) method to know when to show incorrect answer
        AnswerManager.OnIncorrectInput += showInCorrect;
        TestAnswerManager.OnIncorrectInput += showInCorrect;
    }

    // Called when behaviour becomes inactive
    private void OnDisable()
    {
        // Unsubscribes to events
        AnswerManager.OnProcessedInput -= showCorrect;
        AnswerManager.OnIncorrectInput -= showInCorrect;

        TestAnswerManager.OnProcessedInput -= showCorrect;
        TestAnswerManager.OnIncorrectInput -= showInCorrect;
    }

    // Renders the material of the object to use the CORRECT_COLOR to show which was the correct answer
    public void showCorrect(string correctKey)
    {
        if (string.Equals(name, correctKey))
        {
            GetComponent<Renderer>().material.color = CORRECT_COLOR;
            Invoke("returnToOriginalColor", FEEDBACK_TIME);
        }
    }

    // Renders the material of the object to use the INCORRECT_COLOR to show that the input was incorrect answer
    public void showInCorrect(string inputKey)
    {
        if (string.Equals(name, inputKey))
        {
            GetComponent<Renderer>().material.color = INCORRECT_COLOR;
            Invoke("returnToOriginalColor", FEEDBACK_TIME);
        }
    }

    // Renders the material of the object to use the originalColor
    private void returnToOriginalColor()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
}
