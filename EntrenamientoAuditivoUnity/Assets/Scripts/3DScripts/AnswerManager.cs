using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour {

    // Instance used for singleton pattern
    private static AnswerManager instance;

    // Determines if there is a question the user needs to answer, that is an interval has been reproduced
    private static bool thereIsQuestion;
    // Correct second note for a given interval, and thus the expected from the user
    private static string expectedNote;

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

        // Subscribes to OnSecondNoteChange (from IntervalPlayer script) to receive the second note when a new interval is set
        IntervalPlayer.OnSecondNoteChange += receiveExpectedNote;
        // Subscribes to OnPressedKey (from PressKey script) to check when a key is pressed in the piano object
        PressKey.OnPressedKeyIdentify += processAnswer;
    }

    // Update is called once per frame
    void Update() {

    }

    // Called when behaviour becomes inactive
    private void OnDisable()
    {
        // Unsubscribes to events
        IntervalPlayer.OnSecondNoteChange -= receiveExpectedNote;
        PressKey.OnPressedKeyIdentify -= processAnswer;
    }

    // Setter for expectedNote variable
    private static void receiveExpectedNote(string note)
    {
        expectedNote = note;
        thereIsQuestion = true;
    }

    // *****************PENDIENTE: asignar puntos, medir tiempo, almacenar info, retroalimentar
    // Process a given answer by the user when a key is pressed
    private static void processAnswer(string inputNote)
    {
        if (thereIsQuestion)
        {
            if (answerMatchs(inputNote))
            {
                // **************PENDIENTE: asignar puntos

                Debug.Log("Match");
            }
            else
            {
                // **************PENDIENTE: dar retroalimentación

                Debug.Log("No match");
            }
            thereIsQuestion = false;
        }            
    }    

    private static bool answerMatchs(string inputNote)
    {
        if (string.Equals(expectedNote, inputNote))
        {
            return true;
        }
        return false;
    }
}
