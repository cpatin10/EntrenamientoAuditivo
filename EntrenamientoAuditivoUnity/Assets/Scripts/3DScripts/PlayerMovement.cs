using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // Sets the position of the character right in front of the Complete Piano object
        float initialX = PianoDescription.getPianoPositionX();
        float initialY = PianoDescription.getPianoPositionY();
        float initialZ = PianoDescription.getPianoPositionZ() - PianoDescription.getWhiteKeyScaleZ();        
        transform.position = new Vector3(initialX, initialY, initialZ);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void moveToNote(string noteName) {

    }
}
