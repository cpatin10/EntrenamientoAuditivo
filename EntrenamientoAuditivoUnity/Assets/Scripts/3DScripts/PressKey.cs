using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour {

    public string noteName;
    private const float KEY_MOVEMENT = 0.5f;
    private bool pressed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        Press();
        IntervalPlayer.setKeepInterval(false);
    }

    // Defines the action to take when a key is pressed
    private void Press() {
        if (!pressed) {
            PushDown();
            FindObjectOfType<AudioManager>().Play(noteName);
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
