using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoDescription : MonoBehaviour {
    [SerializeField] private GameObject piano;
    [SerializeField] private GameObject whiteKey;
    [SerializeField] private GameObject blackKey;

    // Piano position in space
    private static float pianoPositionX;
    private static float pianoPositionY;
    private static float pianoPositionZ;

    private static float whiteKeyScaleX;
    private static float whiteKeyScaleY;
    private static float whiteKeyScaleZ;

    private static float blackKeyScaleX;
    private static float blackKeyScaleY;
    private static float blackKeyScaleZ;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Hola mundo");
        initializePianoVariables();
        initializeWhiteKeyVariables();
        initializeBlackKeyVariables();
    }

    // Methods for handling piano variables

    private void initializePianoVariables()
    {
        pianoPositionX = piano.transform.position.x;
        pianoPositionY = piano.transform.position.y;
        pianoPositionZ = piano.transform.position.z;
    }

    public static float getPianoPositionX()
    {
        return pianoPositionX;
    }

    public static float getPianoPositionY()
    {
        return pianoPositionY;
    }

    public static float getPianoPositionZ()
    {
        return pianoPositionZ;
    }

    // Methods for handling general white key variables

    public void initializeWhiteKeyVariables()
    {
        whiteKeyScaleX = whiteKey.transform.localScale.x;
        whiteKeyScaleY = whiteKey.transform.localScale.y;
        whiteKeyScaleZ = whiteKey.transform.localScale.z;
    }

    public static float getWhiteKeyScaleX()
    {
        return whiteKeyScaleX;
    }

    public static float getWhiteKeyScaleY()
    {
        return whiteKeyScaleY;
    }

    public static float getWhiteKeyScaleZ()
    {
        return whiteKeyScaleZ;
    }

    // Methods for handling general black key variables

    public void initializeBlackKeyVariables()
    {
        blackKeyScaleX = blackKey.transform.localScale.x;
        blackKeyScaleY = blackKey.transform.localScale.y;
        blackKeyScaleZ = blackKey.transform.localScale.z;
    }

    public static float getBlackeKeyScaleX()
    {
        return blackKeyScaleX;
    }

    public static float getBlackKeyScaleY()
    {
        return blackKeyScaleY;
    }

    public static float getBlackKeyScaleZ()
    {
        return blackKeyScaleZ;
    }

}
