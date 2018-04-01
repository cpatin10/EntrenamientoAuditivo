//u(sing System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

	private PlayerController _playerController;

	// Use this for initialization
	void Start ()
	{
		_playerController = GetComponentInParent<PlayerController>();
	}

	//Comprueba si nuestro personaje esta tocando alguna superficie u objeto
	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			_playerController.Grounded = true;
		}
		
		if (other.gameObject.CompareTag("Platform"))
		{
			_playerController.Grounded = true;
		}
	}

	//Comprueba si nuestro personaje no esta tocando alguna superfice u objeto
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			_playerController.Grounded = false;
		}
		
		if (other.gameObject.CompareTag("Platform"))
		{
			_playerController.Grounded = false;
		}
	}	
}
