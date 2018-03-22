using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private GameObject piano;
    [SerializeField] private GameObject whiteKey;
    [SerializeField] private GameObject blackKey;

    // Use this for initialization
    void Start () {

        // Sets the position of the character right in front of the Complete Piano object
        float initialX = piano.transform.position.x;
        float initialY = piano.transform.position.y;
        float initialZ = piano.transform.position.z - whiteKey.transform.localScale.z;
        transform.position = new Vector3(initialX, initialY, initialZ);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void moveToFirstNote() {

    }
}
