using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
	public int count;

	public GameObject AnswerTrue;
	public GameObject AnswerFalse;

	public void Button_Click_True()
	{
		count++;
		Debug.Log("Bien" + count);
		AnswerTrue.SetActive(false);
		AnswerFalse.SetActive(false);
	}

	public void Button_Click_False()
	{
		count--;
		Debug.Log("Mal" + count);
		AnswerTrue.SetActive(true);
	}

}
