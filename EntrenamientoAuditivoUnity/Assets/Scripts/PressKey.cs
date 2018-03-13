using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour {

    public string noteName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        FindObjectOfType<AudioManager>().Play(noteName); 
    }
}
