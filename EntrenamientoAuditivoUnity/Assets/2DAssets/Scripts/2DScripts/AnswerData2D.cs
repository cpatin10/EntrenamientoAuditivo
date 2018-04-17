using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerData2D {

	public bool correct;
	public int playedInterval;
	public string answeredInterval;
	public string firstNote;
	public string expectedNote;
	public float time;

	// Constructor
	// This class can not be monobehaviour
	public AnswerData2D(bool correct, int playedInterval, string answeredInterval,
		string firstNote, string expectedNote, float time)
	{
		this.correct = correct;
		this.playedInterval = playedInterval;
		this.answeredInterval = answeredInterval;
		this.firstNote = firstNote;
		this.expectedNote = expectedNote;
		this.time = time;
	}
}
