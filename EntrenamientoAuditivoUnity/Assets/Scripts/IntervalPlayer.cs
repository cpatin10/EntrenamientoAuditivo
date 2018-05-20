// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalPlayer : MonoBehaviour
{
    // Total time given to play the complete interval
    private static readonly float TOTAL_INTERVAL_TIME = 2.5f;

    // Observer pattern. Sets an event for when a new interval is set
    public delegate void SetInterval(string noteName);
    public static event SetInterval OnFirstNoteChange;
    public static event SetInterval OnSecondNoteChange;

    // Observer pattern. Sets an event for when an interval plays something
    public delegate void PlayedInterval();
    public static event PlayedInterval OnPlayedSecondNote;

    // Instance used for singleton pattern
    private static IntervalPlayer instance;

    // AudioManager instance needed for reproducing the notes
    private static AudioManager audioManager;
    // Defines how many sounds (notes) the game currently has
    private static int totalSounds;
    // Defines when the second note should be reproduced so that it does not interfere with the first note
    private static readonly float SECOND_NOTE_STARTING_TIME = 0.8f;

    // Information about the interval that is being played
    private static string firstNoteName, secondNoteName;

    // Determines whether a new interval should be defined or to continue with the current one
    private static bool keepInterval = false;
    // Determines if an interval is currently being played
    private static bool reproducing;
    
    
    // Determines whether the interval was reproduced one time already
    private static bool intervalPlayedFirstTime = false;

    // Determines object colors
    private static readonly Color NO_REPRODUCING_COLOR = new Color(0.490f, 0.765f, 0.925f);
    private static readonly Color REPRODUCING_COLOR = new Color(1f, 0.302f, 0.302f);
    // Object renderer
    private Renderer renderer; 

    // Determines the maximum and minimum interval that should be used in the game, by default is minor second and major seventh
    [SerializeField] private Interval greatestInterval = Interval.MajorSeventh;
    [SerializeField] private Interval leastInterval = Interval.MinorSecond;

    // For handling the probability of each interval
    [SerializeField] private bool dynamicProbability;
    private Dictionary<Interval, float> intervalProbability;
    private static readonly float MAX_PROBABILITY = 100f;

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

        audioManager = FindObjectOfType<AudioManager>();
        totalSounds = audioManager.sounds.Length;
        reproducing = false;

        setIntervalsProbabilities();

        renderer = GetComponent<Renderer>();

        // Subscribes to OnPressedKey (from PressKey script) method to check when a key is pressed in the piano object
        PressKey.OnPressedKey += changeInterval;
        // Subscribes to OnQuestionFinished (from AnswerManager script) method to check when a question is answered by the user
        AnswerManager.OnQuestionFinished += waitAndplayNextInterval;
        TestAnswerManager.OnQuestionFinished += waitAndplayNextInterval;

    }

    // Called when behaviour becomes inactive
    void OnDisable()
    {
        // Unsubscribes to events 
        PressKey.OnPressedKey -= changeInterval;
        AnswerManager.OnQuestionFinished -= waitAndplayNextInterval;
        TestAnswerManager.OnQuestionFinished -= waitAndplayNextInterval;
    }

    // Called when object is clicked
    private void OnMouseDown()
    {
        playInterval();
    }

    // Waits some time before calling the playInterval function
    private void waitAndplayNextInterval()
    {
        keepInterval = false;
        Invoke("playInterval", TOTAL_INTERVAL_TIME);
    }

    // Plays the corresponding interval, and defines a new one if necessary
    private void playInterval()
    {
        if (!reproducing)
        {
            reproducing = true;
            if (!keepInterval)
            {
                defineInterval();
                intervalPlayedFirstTime = false;
            }
            playFirstNote();
            Invoke("playSecondNote", SECOND_NOTE_STARTING_TIME);
            Invoke("enablePlayer", TOTAL_INTERVAL_TIME);
        }
    }

    // Sets to false the reproducing varible letting the code to reproduce sound once more
    private void enablePlayer()
    {
        reproducing = false;
        renderer.material.color = NO_REPRODUCING_COLOR;
    }

    // Reproduce the sound corresponding to the previously set firstNote
    private void playFirstNote()
    {
        renderer.material.color = REPRODUCING_COLOR;
        audioManager.Play(firstNoteName);
    }

    // Reproduce the sound corresponding to the previously set secondNote
    private void playSecondNote()
    {
        audioManager.Play(secondNoteName);
        if (!intervalPlayedFirstTime)
        {
            tellAboutPlayedSecondNote();
            intervalPlayedFirstTime = true;
        }
    }

    // Verifies whether there is a subscriber to the tellAboutPlayedSecondNote
    // If there is any tells them that the second note was played
    private void tellAboutPlayedSecondNote()
    {
        PlayedInterval handler = OnPlayedSecondNote;
        if (handler != null)
        {
            handler();
        }
    }

    //*********PENDIENTE: la generación de intervalo debe cambiar de acuerdo a los datos recolectados

    // Defines the interval to reproduce
    // Sets the type of interval and the first and second note id (in sounds array) that defines the interval
    private void defineInterval()
    {
        keepInterval = true;

        int firstNote = Random.Range(0, totalSounds); // between 0 and totalSounds-1
        firstNoteName = audioManager.GetSoundByID(firstNote).name;

        // ************************************ BORRAR
        //int interval = Random.Range((int)leastInterval, (int)greatestInterval + 1); // between leastInterval and greatestInterval
        //

        int interval = determineIntervalToUse();
        generateSecondNote(firstNote, interval);

        tellAboutNewInterval();
    }

    // Verifies whether there is a subscriber to the OnFirstNoteChange and OnSecondNoteChange
    // If there is any tells them about the new defined interval
    private void tellAboutNewInterval()
    {
        SetInterval handler = OnFirstNoteChange;
        if (handler != null)
        {
            //*****************PENDIENTE: borrar
            Debug.Log("1ra nota: " + firstNoteName);

            handler(firstNoteName);
        }

        handler = OnSecondNoteChange;
        if (handler != null)
        {
            //*****************PENDIENTE: borrar
            Debug.Log("2da nota: " + secondNoteName);

            handler(secondNoteName);
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
        int pitch = Random.Range(0, 2);
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

    // Defines probability for each interval and stores it in the intervalProbability dictionary
    private void setIntervalsProbabilities()
    {
        int numberOfIntervals = (int)greatestInterval - (int)leastInterval + 1;

        intervalProbability = new Dictionary<Interval, float>();

        if (dynamicProbability)
        {
            // implements interval probabilities when they are to change 
        }
        else
        {
            // All intervals are given the same probability
            float probability = MAX_PROBABILITY / numberOfIntervals;
            float startingProbabilityPoint = probability;

            for (int i = (int)leastInterval; i < (int)greatestInterval; ++i)
            {
                intervalProbability.Add((Interval)i, startingProbabilityPoint);
                startingProbabilityPoint += probability;
            }

            intervalProbability.Add(greatestInterval, MAX_PROBABILITY);

            //foreach (KeyValuePair<Interval, float> kvp in intervalProbability)
            //{
            //    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            //    Debug.Log("" + kvp.Key + " " + kvp.Value);
            //}
        }
    }

    // Determines which interval to use according to the probabilities stored in the intervalProbability dictionary
    // if interval cannot be determined returns -1
    private int determineIntervalToUse()
    {
        float random = Random.Range(0f, MAX_PROBABILITY);

        if (intervalProbability.ContainsKey(Interval.MinorSecond) && random <= intervalProbability[Interval.MinorSecond])
        {
            return (int)Interval.MinorSecond;
        } 
        else if (intervalProbability.ContainsKey(Interval.MajorSecond) && random <= intervalProbability[Interval.MajorSecond])
        {
            return (int)Interval.MajorSecond;
        }
        else if (intervalProbability.ContainsKey(Interval.MinorThird) && random <= intervalProbability[Interval.MinorThird])
        {
            return (int)Interval.MinorThird;
        }
        else if (intervalProbability.ContainsKey(Interval.MajorThird) && random <= intervalProbability[Interval.MajorThird])
        {
            return (int)Interval.MajorThird;
        }
        else if (intervalProbability.ContainsKey(Interval.PerfectFourth) && random <= intervalProbability[Interval.PerfectFourth])
        {
            return (int)Interval.PerfectFourth;
        }
        else if (intervalProbability.ContainsKey(Interval.AugmentedFourth) && random <= intervalProbability[Interval.AugmentedFourth])
        {
            return (int)Interval.AugmentedFourth;
        }
        else if (intervalProbability.ContainsKey(Interval.PerfectFifth) && random <= intervalProbability[Interval.PerfectFifth])
        {
            return (int)Interval.PerfectFifth;
        }
        else if (intervalProbability.ContainsKey(Interval.MinorSixth) && random <= intervalProbability[Interval.MinorSixth])
        {
            return (int)Interval.MinorSixth;
        }
        else if (intervalProbability.ContainsKey(Interval.MajorSixth) && random <= intervalProbability[Interval.MajorSixth])
        {
            return (int)Interval.MajorSixth;
        }
        else if (intervalProbability.ContainsKey(Interval.MinorSeventh) && random <= intervalProbability[Interval.MinorSeventh])
        {
            return (int)Interval.MinorSeventh;
        }
        else if (intervalProbability.ContainsKey(Interval.MajorSeventh) && random <= intervalProbability[Interval.MajorSeventh])
        {
            return (int)Interval.MajorSeventh;
        }
        return -1;
    }
}

