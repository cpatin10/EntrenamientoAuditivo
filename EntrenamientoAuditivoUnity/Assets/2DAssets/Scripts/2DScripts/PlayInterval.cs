using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _2DAssets.Scripts._2DScripts;

public class PlayInterval : MonoBehaviour {
	
	public PlayerController Player;
	public AudioManager Audio;
    
	public MotorGame ShowQuestion;
	public GameObject Quest;

	public GameObject ButtonMinus;
	public GameObject ButttonMayor;

    public IntervalPlayer2D Intervals;

    public PlatformFalling Platform;

	public Points Point;
	public Answer respuesta;

    public string interval1;
    public string interval2;

    public bool Correct;

	public float timer = 0.0f;

	// Use this for initialization
	void Start () {
		Player = GetComponentInParent<PlayerController>();
        
		Quest = GameObject.Find("Game");
		ShowQuestion = Quest.GetComponentInParent<MotorGame>();
	}

    public void IntervalsPlay()
    {
        Intervals.playInterval();
        interval1 = Intervals.firstNoteName;
        interval2 = Intervals.secondNoteName;
    }
	 
	 private void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Platform"))
         {
             DetectedEnterPlatform();
         }
            
         if (other.gameObject.CompareTag("PlatformFinal"))
         {
             EndGame();
         }
     }

     private void OnCollisionExit2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Platform"))
         {
             DetectedExitPlatform();
         }
     }
    
    public void DetectedEnterPlatform()
    {
        ButtonRepeatInterval();
        ShowQuestion.MakeQuestionOn();
        Player.JumpPower = 0f;
        Player.Speed = 0f;
        if (respuesta.Answers() == "MinorSecond")
        {
            Debug.Log("Es MinorSecond");
        }
        else
        {
            Debug.Log("Es MajorSecond");
        }
        Debug.Log(respuesta.Answers());
    }

    public void DetectedExitPlatform()
    {
        Intervals.changeInterval();
        ShowQuestion.WrongAnswerOff();
        ShowQuestion.CorrectAnswerOff();
        SaveData();
    }

    public void ButtonClickMinus()
    {
        if (respuesta.Answers() == "MinorSecond")
        {
            Debug.Log("Esta bien");
            CorrectAnswer();
            Correct = true;
        } 
        else
        {
            Debug.Log("Esta mal");
            WrongAnswer();
            Correct = false;
        }
    }
    
    public void ButttonClickMayor()
    {
        if (respuesta.Answers() == "MajorSecond")
        {
            Debug.Log("Esta bien");
            CorrectAnswer();
            Correct = true;
        }
        else
        {
            Debug.Log("Esta mal");
            WrongAnswer();
            Correct = false;
        }
    }

    public void ButtonRepeatInterval()
    {
        IntervalsPlay();
    }
    
    public void CorrectAnswer()
    {
        ShowQuestion.CorrectAnswerOn();
        ShowQuestion.MakeQuestionOff();
        Player.JumpPower = 10f;
        Player.Speed = 10f;
        Point.UpdateScore();
        //Platform.Fall();
    }

    public void WrongAnswer()
    {
        ShowQuestion.MakeQuestionOff();
        Player.JumpPower = 10f;
        Player.Speed = 10f;
        ShowQuestion.WrongAnswerOn();
        //Platform.Fall();
    }

    public void EndGame()
    {
        ShowQuestion.StopGame();
    }

    public void SaveData()
    {
        //Correct = Correct;
        Debug.Log(Correct);
    }
}
