using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
	//Esta clase de encarga de pausar e iniciar el juego
	private bool Active;
	private Canvas _canvas;

	private void Start()
	{
		_canvas = GetComponent<Canvas>();
		_canvas.enabled = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Active = !Active;
			_canvas.enabled = Active;
			Time.timeScale = (Active) ? 0 : 1f;
		}
	}
}
