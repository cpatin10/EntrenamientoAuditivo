using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    // Observer pattern. Sets an event for when feedback should be made
    public delegate void GiveFeedback(string keyName);
    public static event GiveFeedback OnProcessedInput;
    public static event GiveFeedback OnIncorrectInput;

    // Instance used for singleton pattern
    private static AnswerManager instance;

    // Determines if there is a question the user needs to answer, that is an interval has been reproduced
    private static bool thereIsQuestion;
    // Correct second note for a given interval, and thus the expected from the user
    private static string expectedNote;

    // Timer for measuring answer time
    private static Timer timer;

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

        // Subscribes to OnSecondNoteChange (from IntervalPlayer script) to receive the second note when a new interval is set
        IntervalPlayer.OnSecondNoteChange += receiveExpectedNote;
        // Subscribes to OnPlayedSecondNote (from IntervalPlayer script) to check when the second note of an interval is being played
        IntervalPlayer.OnPlayedSecondNote += resetTimer;
        // Subscribes to OnPressedKey (from PressKey script) to check when a key is pressed in the piano object
        PressKey.OnPressedKeyIdentify += processAnswer;
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
    private static void receiveExpectedNote(string note)
    {
        expectedNote = note;
        thereIsQuestion = true;
    }

    // *****************PENDIENTE: asignar puntos, almacenar info,
    // Process a given answer by the user when a key is pressed
    private static void processAnswer(string inputNote)
    {
        if (thereIsQuestion)
        {
            float timeToAnswer = timer.getTimeSinceStartTime();
            if (answerMatchs(inputNote))
            {

                // **************PENDIENTE: asignar puntos
                
            }
            else
            {
                tellAboutIncorrectInput(inputNote);
            }
            tellAboutProcessedInput();

            Debug.Log(timeToAnswer);

            // ******************PENDIENTE: almacenar información de tiempo y respuesta

            thereIsQuestion = false;
        }            
    }    

    //Checks whether the given note is equal to the expected one.
    private static bool answerMatchs(string inputNote)
    {
        if (string.Equals(expectedNote, inputNote))
        {
            return true;
        }
        return false;
    }

    // Verifies whether there is a subscriber to the OnProcessedInput
    // If there is any tells them to show the correct answer
    private static void tellAboutProcessedInput()
    {
        if (OnProcessedInput != null)
        {
            OnProcessedInput(expectedNote);
        }
    }

    // Verifies whether there is a subscriber to the OnIncorrectInput
    // If there is any tells them to show that the input was incorrect
    private static void tellAboutIncorrectInput(string inputNote)
    {
        if (OnIncorrectInput != null)
        {
            OnIncorrectInput(inputNote);
        }
    }

    // Resets the timer, in order to measure the time a player takes to answer a question
    private static void resetTimer()
    {
        timer.resetQuestionStartTime();
    }
}
