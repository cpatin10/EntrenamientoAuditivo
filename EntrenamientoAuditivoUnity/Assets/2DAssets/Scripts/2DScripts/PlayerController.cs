//using System.Collections;
//using System.Collections.Generic;

using NUnit.Framework.Internal.Execution;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class PlayerController : MonoBehaviour
{

	//Velocidad de movimiento del personaje
	public float MaxSpeed = 7f;
	public float Speed = 9f;
	public bool Grounded;
	public float JumpPower = 5f;
	public bool _jump;
	
	private Rigidbody2D _rigidbody;
	private Animator _animator;

	public GameObject PlayerGame;
	public GameObject Restart;
	public GameObject Point;
	public int countPoint;
	
	// Use this for initialization
	void Start ()
	{
		//FinalGame = GameObject.Find("PanelGameOver");
				
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		Restart = GameObject.Find("Water");
		Point = GameObject.Find("Platform");
		
		if (Point)
		{
			countPoint++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		_animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
		_animator.SetBool("Grounded", Grounded);

		//Detecta cuando la tecla de salto es presionada 
		if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
		{
			_jump = true;
		}
	}

	void FixedUpdate()
	{
		//Reduce la velocidad del personaje de forma gradual 
		Vector3 fixedVelocity = _rigidbody.velocity;
		fixedVelocity.x *= 1f;
		if (Grounded)
		{
			_rigidbody.velocity = fixedVelocity;
		}
		
		//Detecta el movimiento horizontal y guarda en h los valores negativos(izquierda) o positivos(derecha)
		float h = Input.GetAxis("Horizontal");
		
		_rigidbody.AddForce(Vector2.right * Speed * h);
		
		//Limita la velocidad por derecha e izquierda para que sean las mismas
		float limitedSpeed = Mathf.Clamp(_rigidbody.velocity.x, -MaxSpeed, MaxSpeed);
		_rigidbody.velocity = new Vector2(limitedSpeed, _rigidbody.velocity.y);

		//Estos dos metodos cambian la direccion del personaje segun la tecla presionada (derecha o izquierda)
		if (h > 0.1f)
		{
			transform.localScale = new Vector3(1.122854f, 1.122854f, 1.122854f);
		}

		if (h < -0.1f)
		{
			transform.localScale = new Vector3(-1.122854f, 1.122854f, 1.122854f);
		}

		//Genera el salto para el personaje
		if (_jump)
		{
			_rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
			_jump = false;
		}
	}
	
	//Detecta cuando el personaje ha desaparecido de la escena y lo reubica 
	private void OnBecameInvisible()
	{	
		if (Restart)
		{
			transform.position = new Vector3(0, 0, 0);
		}
	}

}
