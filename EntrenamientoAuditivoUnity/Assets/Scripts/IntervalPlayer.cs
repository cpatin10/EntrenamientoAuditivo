using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalPlayer : MonoBehaviour
{
    // Observer pattern. Sets an event for when a new interval is set
    public delegate void setInterval(string noteName);
    public static event setInterval OnIntervalChange;

    // Instance used for singleton pattern
    private static IntervalPlayer instance;

    // AudioManager instance needed for reproducing the notes
    private static AudioManager audioManager;
    // Defines how many sounds (notes) the game currently has
    private static int totalSounds;
    // Defines when the second note should be reproduced so that it does not interfere with the first note
    private static readonly float SECOND_NOTE_STARTING_TIME = 0.8f;

    // Determines the maximum interval that should be used in the game, by default is the major seventh
    private static Interval greatestInterval = Interval.MajorSeventh;

    // Information about the interval that is being played
    private static string firstNoteName, secondNoteName;
    private static Interval playedInterval;

    // Determines whether a new interval should be defined or to continue with the current one
    private static bool keepInterval = false;
    // Determines if an interval is currently being played
    private static bool reproducing;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioManager = FindObjectOfType<AudioManager>();
        totalSounds = audioManager.sounds.Length;
        reproducing = false;

        //Subscribes to OnPressedKey method to check when a key is pressed in the piano object
        PressKey.OnPressedKey += changeInterval;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when behaviour becomes inactive
    private void OnDisable()
    {
        PressKey.OnPressedKey -= changeInterval;
    }

    // Called when object is clicked
    private void OnMouseDown()
    {
        if (!reproducing)
        {
            reproducing = true;
            if (!keepInterval)
            {
                defineInterval();
            }
            playFirstNote();
            Invoke("playSecondNote", SECOND_NOTE_STARTING_TIME);

            //****************PENDIENTE: Cambiar color en momentos que se puede y no reproducir
            Invoke("enablePlayer", Mathf.Min(2.5f));
        }
    }

    // Sets to false the reproducing varible letting the code to reproduce sound once more
    private void enablePlayer()
    {
        reproducing = false;
    }

    // Reproduce the sound corresponding to the previously set firstNote
    private void playFirstNote()
    {
        audioManager.Play(firstNoteName);
    }

    // Reproduce the sound corresponding to the previously set secondNote
    private void playSecondNote()
    {
        audioManager.Play(secondNoteName);
    }

    //*********PENDIENTE: la generación de intervalo debe cambiar de acuerdo a los datos recolectados

    // Defines the interval to reproduce
    // Sets the type of interval and the first and second note id (in sounds array) that defines the interval
    private void defineInterval()
    {
        keepInterval = true;

        int firstNote = Random.Range(0, totalSounds); // between 0 and totalSounds-1
        firstNoteName = audioManager.GetSoundByID(firstNote).name;
        int interval = Random.Range((int)Interval.MinorSecond, (int)greatestInterval);
        generateSecondNote(firstNote, interval);

        tellAboutNewInterval();

        playedInterval = (Interval)interval;
    }

    // Verifies whether there is a subscriber to the OnIntervalChange
    // If there is any tells them about the new defined interval
    private void tellAboutNewInterval()
    {
        if (OnIntervalChange != null)
        {
            //*****************PENDIENTE: borrar
            Debug.Log(firstNoteName);

            OnIntervalChange(firstNoteName);
        }
    }

    // Sets the second note according to the given interval starting at the given firstNote
    private void generateSecondNote(int firstNote, int interval)
    {
        int secondNote;

        if (firstNote + interval >= totalSounds)
        {
            secondNote = firstNote - interval;
        }
        else if (firstNote - interval < 0)
        {
            secondNote = firstNote + interval;
        }
        else
        {
            secondNote = randomizePitch(firstNote, interval);
        }

        secondNoteName = audioManager.GetSoundByID(secondNote).name;
    }

    // Determines wether the interval goes higher or lower in pitch for the second note
    // This is determined randomly
    private int randomizePitch(int firstNote, int interval)
    {
        int secondNote;
        int pitch = Random.Range(0, 1);
        if (pitch == 0)
        {
            secondNote = firstNote - interval;
        }
        else
        {
            secondNote = firstNote + interval;
        }
        return secondNote;
    }

    // Sets keepInterval to false, so that next interval is a new one
    private static void changeInterval()
    {
        keepInterval = false;
    }

}

