using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _2DAssets.Scripts._2DScripts;

public class Answers : MonoBehaviour
{
	//public int count;

	public GameObject AnswerTrue;
	public GameObject AnswerFalse;

	public delegate void InputAnswer();

	public static event InputAnswer OnClickedButton;
	public IntervalPlayer2D interval;

	private void Start()
	{
		interval = GetComponent<IntervalPlayer2D>();
	}

	public void Button_Click_True()
	{
		counter();
		//Debug.Log("Bien" + count);
		AnswerTrue.SetActive(false);
		AnswerFalse.SetActive(false);
	}

	//Eliminar la opcion de responder de nuevo y dejar las teclas en rojo, desabilitar el movimiento del usuario hasta que responda
	
	
	public void Button_Click_False()
	{
		Debug.Log("Mal" );
		AnswerTrue.SetActive(true);
	}

	public void counter()
	{
		int count = 0;
		count += 1;
		Debug.Log(count);
	}
}
