using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    //name used to identify the sound
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    
    /*
    //for the moment we do not need to set pitch, leaving it here for posible future reference
    [Range(.1f, 3f)]
    public float pitch;*/

    //defines wether the sound should continue in a loop
    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
