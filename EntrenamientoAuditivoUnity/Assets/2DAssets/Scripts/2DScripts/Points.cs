using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _2DAssets.Scripts._2DScripts;

public class Points : MonoBehaviour
{

	public IntervalPlayer2D Updated;

	public Text txtPoints;
	private int puntuacion;
	
	// Use this for initialization
	void Start ()
	{
		txtPoints.text = "0";
		puntuacion = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void UpdateScore()
	{
		puntuacion = puntuacion + 1;
		txtPoints.text = puntuacion.ToString();
	}
}
