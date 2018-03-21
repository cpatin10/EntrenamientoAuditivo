using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalReproductor : MonoBehaviour {
    static IntervalReproductor instance;
    static AudioManager audioManager;
    static int totalSounds;
    static float secondNoteStartingTime = 0.8f;

    public Interval greatestInterval = Interval.MajorSeventh;

    int firstNote, secondNote;
    bool reproducing;
    bool pitchGoesUp;
    Interval reproducedInterval;

    // Use this for initialization
    void Start () {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        audioManager = FindObjectOfType<AudioManager>();
        totalSounds = audioManager.sounds.Length;
        reproducing = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        if (!reproducing) {
            reproducing = true;
            defineInterval();
            reproduceFirstNote();
            Invoke("reproduceSecondtNote", secondNoteStartingTime);

            //****************PENDIENTE: Cambiar color en momentos que se puede y no reproducir
            Invoke("enableReproduction", Mathf.Min(2.5f));
        }
    }

    // Sets to false the reproducing varible letting the code to reproduce sound once more
    private void enableReproduction() {
        reproducing = false;
    }

    // Reproduce the sound corresponding to the previously set firstNote
    private void reproduceFirstNote() {
        Sound sound = audioManager.GetSoundByID(firstNote);
        reproduceSound(sound.name);
    }

    // Reproduce the sound corresponding to the previously set secondNote
    private void reproduceSecondtNote() {
        Sound sound = audioManager.GetSoundByID(secondNote);
        reproduceSound(sound.name);
    }

    // Reproduce the sound corresponding to the given soundName
    private void reproduceSound(string soundName) {
        audioManager.Play(soundName);
    }

    //*********PENDIENTE: la generación de intervalo debe cambiar de acuerdo a los datos recolectados

    // Defines the interval to reproduce
    // Sets the type of interval and the first and second note id (in sounds array) that defines the interval
    private void defineInterval() {
        firstNote = Random.Range(0, totalSounds); // between 0 and totalSounds-1
        int interval = Random.Range((int)Interval.MinorSecond, (int)greatestInterval);
        secondNote = generateSecondNote(firstNote, interval);
        reproducedInterval = (Interval)interval;
    }

    // Sets the second note according to the given interval starting at the given firstNote
    private int generateSecondNote(int firstNote, int interval) {
        int secondNote;

        if (firstNote + interval >= totalSounds) {
            secondNote = firstNote - interval;
            pitchGoesUp = false;
        }
        else if (firstNote - interval < 0) {
            secondNote = firstNote + interval;
            pitchGoesUp = true;
        }
        else {
            secondNote = randomizePitch(firstNote, interval);
        }
        
        return secondNote;
    }

    // Determines wether the interval goes higher or lower in pitch for the second note
    // This is determined randomly
    private int randomizePitch(int firstNote, int interval) {
        int secondNote;
        int pitch = Random.Range(0, 1);
        if (pitch == 0) {
            secondNote = firstNote - interval;
            pitchGoesUp = false;
        }
        else {
            secondNote = firstNote + interval;
            pitchGoesUp = true;
        }
        return secondNote;
    }
}
