using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _2DAssets.Scripts._2DScripts
{
    public class IntervalPlayer2D : MonoBehaviour {

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
        public string firstNoteName;
        public string secondNoteName;

        // Determines whether a new interval should be defined or to continue with the current one
        public static bool keepInterval = false;
        // Determines if an interval is currently being played
        private static bool reproducing;

        // Determines the maximum and minimum interval that should be used in the game, by default is minor second and major seventh
        [SerializeField] private Interval greatestInterval = Interval.MajorSeventh;
        [SerializeField] private Interval leastInterval = Interval.MinorSecond;
    
        // Use this for initialization
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            totalSounds = audioManager.sounds.Length;
            reproducing = false;

            // Subscribes to OnPressedKey (from PressKey script) method to check when a key is pressed in the piano object
            PressKey.OnPressedKey += changeInterval;
            // Subscribes to OnQuestionFinished (from AnswerManager script) method to check when a question is answered by the user
            AnswerManager.OnQuestionFinished += waitAndplayNextInterval;
       
        }

        // Called when behaviour becomes inactive
        void OnDisable()
        {
            // Unsubscribes to events 
            PressKey.OnPressedKey -= changeInterval;
            AnswerManager.OnQuestionFinished -= waitAndplayNextInterval;
        }

        // Waits some time before calling the playInterval function
        private void waitAndplayNextInterval()
        {
            keepInterval = false;
            Invoke("playInterval", TOTAL_INTERVAL_TIME);
        }

        // Plays the corresponding interval, and defines a new one if necessary
        public void playInterval()
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

                Invoke("enablePlayer", TOTAL_INTERVAL_TIME);
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
            tellAboutPlayedSecondNote();
        }

        // Verifies whether there is a subscriber to the tellAboutPlayedSecondNote
        // If there is any tells them that the second note was played
        public void tellAboutPlayedSecondNote()
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
            int interval = Random.Range((int)leastInterval, (int)greatestInterval + 1);
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
        public void generateSecondNote(int firstNote, int interval)
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
        public void changeInterval()
        {
            keepInterval = false;
        }
        
    }
}
    
