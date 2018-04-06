using System.Security.Cryptography;
using UnityEngine;

namespace _2DAssets.Scripts._2DScripts
{
	public class CheckPlatform : MonoBehaviour {

		public PlayerController _playerController;

		// Use this for initialization
		void Start ()
		{
			_playerController = GetComponentInParent<PlayerController>();
		}

		//Comprueba si nuestro personaje esta tocando alguna superficie u objeto
		public void OnCollisionStay2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Platform"))
			{
				DetectedEnterPlatform();
			}

			//Destroy(this.gameObject);
		}

		//Comprueba si nuestro personaje no esta tocando alguna superfice u objeto
		public void OnCollisionExit2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Platform"))
			{
				DetectedExitPlatform();
			}
		}

		public void DetectedEnterPlatform()
		{
			//Debug.Log("Probando el detector de pltaformas");
			//_playerController.Speed = 0f;
		}

		public void DetectedExitPlatform()
		{
			//Debug.Log("Detectando que salimos de la plataforma");
			//_playerController.Speed = 9f;
		}

	}
}
