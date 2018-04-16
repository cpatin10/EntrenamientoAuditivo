using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	
	//Cambia entre escena y escena en un menu
	public void ChangeScene(string sceneName)
	{	
		SceneManager.LoadScene(sceneName);
	}
}
