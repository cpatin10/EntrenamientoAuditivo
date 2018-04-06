using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMusic : MonoBehaviour
{

	public GameObject Music;
	
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "Player")
		{
			Music.SetActive(false);
			Debug.Log("Tocando");
		}
	}
}


//Quest = GameObject.Find("Game");
//ShowQuestion = Quest.GetComponentInParent<MotorGame>();
//public MotorGame ShowQuestion;
//public GameObject Quest;