// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    // ************* PENDIENTE: los limites de tiempo deben cambiar de acuerdo a la analítica

    // Limit in time for assigning dynamic points
    public static readonly float MINIMUM_ANSWER_TIME = 1f;
    public static readonly float MAXIMUM_ANSWER_TIME = 10f;

    // Observer pattern. Sets an event for when feedback should be made
    public delegate void GiveFeedback(string keyName);
    public static event GiveFeedback OnProcessedInput;
    public static event GiveFeedback OnIncorrectInput;
    // Observer pattern. Sets an event for when points should be assigned to the user
    public delegate void AssignPoints(float time, float minTime, float maxTime);
    public static event AssignPoints OnPointsAssignmentNeed;

    // Instance used for singleton pattern
    private static AnswerManager instance;

    // Determines if there is a question the user needs to answer, that is an interval has been reproduced
    private bool thereIsQuestion;
    // Correct second note for a given interval, and thus the expected from the user
    private string expectedNote;

    // Timer for measuring answer time
    private Timer timer;

    public Text timerText;

    // Use this for initialization
    void Start() {

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

        thereIsQuestion = false;
        timer = new Timer();
        disableTimerText();

        // Subscribes to OnSecondNoteChange (from IntervalPlayer script) to receive the second note when a new interval is set
        IntervalPlayer.OnSecondNoteChange += receiveExpectedNote;
        // Subscribes to OnPlayedSecondNote (from IntervalPlayer script) to check when the second note of an interval is being played
        IntervalPlayer.OnPlayedSecondNote += resetTimer;
        IntervalPlayer.OnPlayedSecondNote += enableTimerText;
        // Subscribes to OnPressedKey (from PressKey script) to check when a key is pressed in the piano object
        PressKey.OnPressedKeyIdentify += processAnswer;
    }

    private void Update()
    {
        setTimerText();
    }

    // Called when behaviour becomes inactive
    private void OnDisable()
    {
        // Unsubscribes to events
        IntervalPlayer.OnSecondNoteChange -= receiveExpectedNote;
        IntervalPlayer.OnPlayedSecondNote -= resetTimer;
        PressKey.OnPressedKeyIdentify -= processAnswer;
    }

    // Setter for expectedNote variable
    private void receiveExpectedNote(string note)
    {
        expectedNote = note;
        thereIsQuestion = true;
    }

    // *****************PENDIENTE: asignar puntos, almacenar info,
    // Process a given answer by the user when a key is pressed
    private void processAnswer(string inputNote)
    {
        if (thereIsQuestion)
        {
            disableTimerText();
            float timeToAnswer = timer.getTimeSinceStartTime();

            if (answerMatchs(inputNote))
            {
                tellAboutPointsAssignment(timeToAnswer);
            }
            else
            {
                tellAboutIncorrectInput(inputNote);
            }
            tellAboutProcessedInput();

            // ******************PENDIENTE: almacenar información de tiempo y respuesta

            thereIsQuestion = false;
        }            
    }    

    //Checks whether the given note is equal to the expected one.
    private bool answerMatchs(string inputNote)
    {
        if (string.Equals(expectedNote, inputNote))
        {
            return true;
        }
        return false;
    }

    // Verifies whether there is a subscriber to the OnProcessedInput
    // If there is any tells them to show the correct answer
    private void tellAboutProcessedInput()
    {
        GiveFeedback handler = OnProcessedInput;
        if (handler != null)
        {
            handler(expectedNote);
        }
    }

    // Verifies whether there is a subscriber to the OnIncorrectInput
    // If there is any tells them to show that the input was incorrect
    private void tellAboutIncorrectInput(string inputNote)
    {
        GiveFeedback handler = OnIncorrectInput;
        if (handler != null)
        {
            handler(inputNote);
        }
    }

    // Verifies whether there is a subscriber to the OnPointsAssignment
    // If there is any tells them to assign points
    private void tellAboutPointsAssignment(float time)
    {
        AssignPoints handler = OnPointsAssignmentNeed;
        if (handler != null)
        {
            handler(time, MINIMUM_ANSWER_TIME, MAXIMUM_ANSWER_TIME);
        } 
    }

    // Resets the timer, in order to measure the time a player takes to answer a question
    private void resetTimer()
    {
        timer.resetQuestionStartTime();
    }

    // Shows timerText in screen
    private void enableTimerText()
    {
        timerText.enabled = true;
    }

    // Hides timerText from screen
    private void disableTimerText()
    {
        timerText.enabled = false;
    }

    // Sets the text of timerText to show remaining time to answer
    private void setTimerText()
    {
        int remainingTime = (int)(MAXIMUM_ANSWER_TIME - timer.getTimeSinceStartTime());
        timerText.text = "" + remainingTime;
    }
}
