using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject select, list;

	private int index = 0;

	private void Start()
	{
		DrawSelector();
	}

	private void Update()
	{
		bool up = Input.GetKeyDown("up");
		bool down = Input.GetKeyDown("down");

		if (up) index--;
		if (down) index++;

		if (index > list.transform.childCount - 1) index = 0;
		else if (index < 0) index = list.transform.childCount - 1;
		
		if (up || down) DrawSelector();

		if (Input.GetKeyDown("return")) action();
	}

	void DrawSelector()
	{
		Transform option = list.transform.GetChild(index);
		select.transform.position = option.position;
	}

	void action()
	{
		Transform option = list.transform.GetChild(index);
		if (option.gameObject.name == "Exit")
		{
			Application.Quit();
		}
		else
		{
			SceneManager.LoadScene(option.gameObject.name);
		}
	}
}
