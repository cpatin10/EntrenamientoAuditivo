﻿// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

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

        // Subscribes class to event OnFirstNoteChange (from IntervalPlayer script) in the IntervalPlayer script
        IntervalPlayer.OnFirstNoteChange += moveToNote;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called when behaviour becomes inactive
    private void OnDisable()
    {
        // Unsubscribe to event
        IntervalPlayer.OnFirstNoteChange -= moveToNote;
    }

    // Moves the player to a key in the piano according to its name
    public void moveToNote(string keyName) {
        // Read key position
        Vector3 position = PianoDescription.getKeyPosition(keyName);
        // Set the player to be on top of the key (sets y)
        position[1] += PianoDescription.getKeyScaleY(keyName) / 2f + transform.localScale.y / 2f;
        // Set the player to be a little more near the camera while being on the key (sets z)
        position[2] -= PianoDescription.getKeyScaleZ(keyName) / 2.5f - transform.localScale.z / 2f;

        transform.position = position;
    }
}
