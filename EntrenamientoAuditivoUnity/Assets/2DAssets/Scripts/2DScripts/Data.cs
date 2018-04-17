using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
	public PlayInterval Correct;
	public Answer Interval;

	public AnswerData2D Datas;

	public bool correct;
	public string playedInterval;
	public string answeredInterval;
	public string firstNote;
	public string expectedNote;
	public float time;

	private void Start()
	{
		SaveData();
	}

	public void SaveData()
	{
		playedInterval = Interval.playedInterval;
		
	}
}
