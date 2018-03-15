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
        pushDown();
        FindObjectOfType<AudioManager>().Play(noteName); 
    }

    private void pushDown() {
        transform.Translate(0f, -1f * Time.deltaTime, 0f);
    }
}
