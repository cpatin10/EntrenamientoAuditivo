using UnityEngine;

namespace _2DAssets.Scripts._2DScripts
{
	public class MotorGame : MonoBehaviour
	{
		public float Speed;
		public bool startGame;
		public bool EndGame;

		public GameObject FinalGameMessage;
		public GameObject StopPlayer;
		public GameObject StopTime;
		public GameObject Question;
		public GameObject Wrong;
		public GameObject Correct;

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
			
			Wrong = GameObject.Find("Wrong");
			Wrong.SetActive(false);
			
			Correct = GameObject.Find("Correct");
			Correct.SetActive(false);
		}

		public void StopGame()
		{
			FinalGameMessage.SetActive(true);
			StopPlayer.SetActive(false);
			StopTime.SetActive(false);
			Question.SetActive(false);
		}

		public void MakeQuestionOn()
		{
			Question.SetActive(true);
		}
	
		public void MakeQuestionOff()
		{
			Question.SetActive(false);
		}

		public void CorrectAnswerOn()
		{
			Correct.SetActive(true);
		}

		public void WrongAnswerOn()
		{
			Wrong.SetActive(true);
		}
		
		public void CorrectAnswerOff()
		{
			Correct.SetActive(false);
		}

		public void WrongAnswerOff()
		{
			Wrong.SetActive(false);
		}


		void SpeedGame()
		{
			Speed = 1;
		}
	
		// Update is called once per frame
		void Update () {
			if (startGame == true && EndGame == false)
			{
				transform.Translate(Vector3.down * Speed * Time.deltaTime);
			}
		}

	
	}
}
