//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject Follow;
	public Vector2 MinCamPos, MaxCamPos;
	public float SmoothTime;

	private Vector2 velocity; 
	
	// Update is called once per frame
	private void FixedUpdate()
	{
		//Suaviza el contenido de la pantalla
		float posX = Mathf.SmoothDamp(transform.position.x, Follow.transform.position.x, ref velocity.x, SmoothTime);
		float posY = Mathf.SmoothDamp(transform.position.y, Follow.transform.position.y, ref velocity.y, SmoothTime);
		
		//Posiciona la camara sobre el personaje
		transform.position = new Vector3(Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x), Mathf.Clamp(posY, MinCamPos.x, MaxCamPos.y), transform.position.z);
	}
}
