// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

//The AudioManager was built using the tutorial found at: https://www.youtube.com/watch?v=6OT43pvUyfY
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    // Dictionary for storing the audioName (note name) with its id 
    private Dictionary<string, int> notesId;
    public static AudioManager instance;

    // Use this for initialization
    void Awake () {

        //Singleton Pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        notesId = new Dictionary<string, int>(sounds.Length);

        for (int i = 0; i < sounds.Length; ++i)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;

            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.loop = sounds[i].loop;

            notesId.Add(sounds[i].name, i);
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

    // Returns the sound given the int id that it has on the sounds array
    public Sound GetSoundByID(int id) {
        return sounds[id];
    }

    // Returns the sound id given its name
    // If the name is empty, returns -1
    public int GetSoundIDByName(string name)
    {
        if (string.Equals(name, ""))
        {
            return -1;
        }
        return notesId[name];
    }
}
    