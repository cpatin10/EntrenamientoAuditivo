// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour {

    // Observer pattern. Sets an event for when a key is pressed
    public delegate void PressedKey();
    public static event PressedKey OnPressedKey;
    public delegate void PressedKeyIdentification(string keyName);
    public static event PressedKeyIdentification OnPressedKeyIdentify;

    public string keyName;
    private const float KEY_MOVEMENT = 0.5f;
    private bool pressed = false;

    // Use this for initialization
    void Start () {
        keyName = name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called when object is clicked
    private void OnMouseDown() {
        Press();
        tellAboutPressedKey();
    }

    // Verifies whether there is a subscriber to the OnPressedKey
    // If there is any tells them that a key was pressed
    private void tellAboutPressedKey()
    {
        PressedKey handlerOnPressedKey = OnPressedKey;
        if (handlerOnPressedKey != null)
        {
            handlerOnPressedKey();
        }

        PressedKeyIdentification handlerOnPressedKeyIndentify = OnPressedKeyIdentify;
        if (handlerOnPressedKeyIndentify != null)
        {
            handlerOnPressedKeyIndentify(keyName);
        }
    }

    // Defines the action to take when a key is pressed
    private void Press() {
        if (!pressed) {
            PushDown();
            FindObjectOfType<AudioManager>().Play(keyName);
            Invoke("MoveUp", 1.5f);
        }
    }

    // Moves the key down (-y) according to the movement previously defined to the key
    private void PushDown() {
        disablePress();
        transform.position = new Vector3(transform.position.x, transform.position.y - KEY_MOVEMENT, transform.position.z);
    }

    // Moves the key up (+y) according to the movement previously defined to the key 
    private void MoveUp() {
        transform.position = new Vector3(transform.position.x, transform.position.y + KEY_MOVEMENT, transform.position.z);
        enablePress();
    }

    // Disables the ability of a user to press down a key
    private void disablePress() {
        pressed = true;
    }

    // Enables the ability of a user to press down a key
    private void enablePress() {
        pressed = false;
    }
}
