using UnityEngine.Audio;
using System;
using UnityEngine;

//The AudioManager was built using the tutorial found at: https://www.youtube.com/watch?v=6OT43pvUyfY
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        //Singleton Pattern
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
	}

    // Looks for the Sound object with the given name, and calls its source to reproduce the sound
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public Sound GetSoundByID(int id) {
        return sounds[id];
    }
}
    