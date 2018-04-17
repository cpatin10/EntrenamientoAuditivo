using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _2DAssets.Scripts._2DScripts;

public class Answer : MonoBehaviour {

	public AudioManager Audio;
	public PlayInterval Interval;

	public GUIText message;
	public float timer = 0.0f;

	public string playedInterval;

	public string Answers()
	{
		Interval play;
		int audio1 = Audio.GetSoundIDByName(Interval.interval1);
		int audio2 = Audio.GetSoundIDByName(Interval.interval2);
		play = EnumInterval.determineInterval(audio1, audio2);
		playedInterval = play.ToString();
		return playedInterval;
	}
}
