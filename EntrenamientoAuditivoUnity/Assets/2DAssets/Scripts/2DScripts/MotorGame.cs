using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorGame : MonoBehaviour
{
	public float Speed;
	public bool startGame;
	public bool endGame;

	public GameObject FinalGameMessage;
	public GameObject StopPlayer;
	public GameObject StopTime;
	public GameObject Question;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame()
	{
		SpeedGame();
		
		FinalGameMessage = GameObject.Find("PanelGameOver");
		FinalGameMessage.SetActive(false);

		StopPlayer = GameObject.Find("Player");
		StopTime = GameObject.Find("TimePlaying");
		
		Question = GameObject.Find("PanelQuestion");
		Question.SetActive(false);
	}

	public void StopGame()
	{
		FinalGameMessage.SetActive(true);
		StopPlayer.SetActive(false);
		StopTime.SetActive(false);
	}

	public void MakeQuestionOn()
	{
		Question.SetActive(true);
	}
	
	public void MakeQuestionOff()
	{
		Question.SetActive(false);
	}

	void SpeedGame()
	{
		Speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (startGame == true && endGame == false)
		{
			transform.Translate(Vector3.down * Speed * Time.deltaTime);
		}
	}

	
}
