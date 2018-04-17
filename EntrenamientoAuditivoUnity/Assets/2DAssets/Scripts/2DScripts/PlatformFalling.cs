//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;

	public float fallDelay = 2f;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Fall()
	{
		Invoke("FallingPlatform", fallDelay);
	}

	public void FallingPlatform()
	{
		_rigidbody2D.isKinematic = false; 
	}

}
