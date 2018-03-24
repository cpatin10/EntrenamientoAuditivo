using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoDescription : MonoBehaviour {
    [SerializeField] private GameObject piano;
    [SerializeField] private GameObject whiteKey;
    [SerializeField] private GameObject blackKey;

    // Dictionary for storing the position (x, y, z) of each key (identified by name) in the piano
    private static Dictionary<string, Vector3> pianoKeys;

    // Piano position in space
    private static float pianoPositionX;
    private static float pianoPositionY;
    private static float pianoPositionZ;

    // White key scale
    private static float whiteKeyScaleX;
    private static float whiteKeyScaleY;
    private static float whiteKeyScaleZ;

    // Black key scale
    private static float blackKeyScaleX;
    private static float blackKeyScaleY;
    private static float blackKeyScaleZ;

    // Use this for initialization
    void Start ()
    {        
        initializePianoVariables();
        initializeWhiteKeyVariables();
        initializeBlackKeyVariables();
        int expectedPianoSize = FindObjectOfType<AudioManager>().sounds.Length;
        pianoKeys = new Dictionary<string, Vector3>(expectedPianoSize);
        fillKeys();
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

    // Methods for handling pianoKeys dictionary
    private static void fillKeys()
    {
        GameObject[] whiteKeys = GameObject.FindGameObjectsWithTag("WhiteKey");
        addListToKeys(whiteKeys);
        GameObject[] blackKeys = GameObject.FindGameObjectsWithTag("BlackKey");
        addListToKeys(blackKeys);
    }

    private static void addListToKeys(GameObject[] keys)
    {
        float x;
        float y;
        float z;
        foreach (GameObject key in keys)
        {
            x = key.transform.position.x;
            y = key.transform.position.y;
            z = key.transform.position.z;
            pianoKeys.Add(key.name, new Vector3(x, y, z));
        }
    }

    public static Vector3 getKeyPosition(string keyName)
    {
        if (!pianoKeys.ContainsKey(keyName))
        {
            Debug.LogWarning("KeyName does not exist on pianoKeysDictionary");
            return new Vector3();
        }
        return pianoKeys[keyName];
    }

}
