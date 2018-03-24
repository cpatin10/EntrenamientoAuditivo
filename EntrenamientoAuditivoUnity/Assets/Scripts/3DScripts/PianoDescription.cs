using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoDescription : MonoBehaviour {
    [SerializeField] private GameObject piano;
    [SerializeField] private GameObject whiteKey;
    [SerializeField] private GameObject blackKey;

    // Dictionary for storing the position (x, y, z) of each key (identified by name) in the piano
    private static Dictionary<string, Vector3> pianoKeys;
    // Hashsets for storing the blackKeys and WhiteKeys names separately
    private static HashSet<string> blackKeys;
    private static HashSet<string> whiteKeys;

    // Piano position in space
    private static float pianoPositionX;
    private static float pianoPositionY;
    private static float pianoPositionZ;

    // White key scale
    //private static float whiteKeyScaleX;
    private static float whiteKeyScaleY;
    private static float whiteKeyScaleZ;

    // Black key scale
    //private static float blackKeyScaleX;
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
        whiteKeys = new HashSet<string>();
        blackKeys = new HashSet<string>();
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

    // Initialize white keys variables
    private void initializeWhiteKeyVariables()
    {
        //whiteKeyScaleX = whiteKey.transform.localScale.x;
        whiteKeyScaleY = whiteKey.transform.localScale.y;
        whiteKeyScaleZ = whiteKey.transform.localScale.z;
    }

    //Returns the local scale z of a whiteKey
    public static float getWhiteKeyScaleZ()
    {
        return whiteKeyScaleZ;
    }

    // Initialize black keys variables
    private void initializeBlackKeyVariables()
    {
        //blackKeyScaleX = blackKey.transform.localScale.x;
        blackKeyScaleY = blackKey.transform.localScale.y;
        blackKeyScaleZ = blackKey.transform.localScale.z;
    }

    // Returns the y local scale of a given key
    public static float getKeyScaleY(string keyName)
    {
        if (whiteKeys.Contains(keyName))
        {
            return whiteKeyScaleY;
        }
        else if (blackKeys.Contains(keyName))
        {
            return blackKeyScaleY;
        }
        else
        {
            Debug.LogWarning("Key is not black or white key");
            return 0;
        }
    }

    // Returns the z local scale of a given key
    public static float getKeyScaleZ(string keyName)
    {

        if (whiteKeys.Contains(keyName))
        {
            return whiteKeyScaleZ;
        }
        else if (blackKeys.Contains(keyName))
        {
            return blackKeyScaleZ;
        }
        else
        {
            Debug.LogWarning("Key is not black or white key");
            return 0;
        }
    }

    // Filling data structures wiht keys information
    private static void fillKeys()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("WhiteKey");
        addWhiteKeys(keys);
        keys = GameObject.FindGameObjectsWithTag("BlackKey");
        addBlackeKeys(keys);
    }

    private static void addWhiteKeys(GameObject[] keys)
    {
        foreach (GameObject key in keys)
        {
            whiteKeys.Add(key.name);
            pianoKeys.Add(key.name, new Vector3(key.transform.position.x, key.transform.position.y, key.transform.position.z));
        }
    }

    private static void addBlackeKeys(GameObject[] keys)
    {
        foreach (GameObject key in keys)
        {
            blackKeys.Add(key.name);
            pianoKeys.Add(key.name, new Vector3(key.transform.position.x, key.transform.position.y, key.transform.position.z));
        }
    }

    // Returns the position x, y, z in a Vector3 of the specified key
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
