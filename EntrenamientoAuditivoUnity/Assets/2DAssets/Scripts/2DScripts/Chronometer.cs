using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{

	public GameObject PlayerDistance;
	public MotorGame GameDistance;
	public GameObject platform;

	public float time;
	public Text txtTime;
	public float distance;
	
	public GameObject FinalGame;

	// Use this for initialization
	void Start () {
		PlayerDistance = GameObject.Find("Game");
		GameDistance = PlayerDistance.GetComponent<MotorGame>();		

		txtTime.text = "2:00";
		time = 50;
	}
	
	void Update () {
		TimeGame();

		if (time < 0)
		{
			GameDistance.StopGame();
		}
	}

	void TimeGame()
	{
		distance += Time.deltaTime * GameDistance.Speed;
		
		time -= Time.deltaTime;
		int minutes = (int) time / 60;
		int seconds = (int) time % 60;
		txtTime.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
	}
}
