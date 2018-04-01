using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
	
	//Cambia entre escena y escena en un menu
	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
