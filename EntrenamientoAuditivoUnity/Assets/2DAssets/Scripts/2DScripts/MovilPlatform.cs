//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MovilPlatform : MonoBehaviour
{
	public Transform Target;
	public float Speed;

	private Vector3 _start, _end;

	void Start()
	{
		//Almacena la posicion actual y futura de la plataforma en movimiento
		if (Target != null)
		{
			Target.parent = null;
			_start = transform.position;
			_end = Target.position;
		}
	}

	private void FixedUpdate()
	{
		//Mueve la plataforma al punto indicado
		if (Target != null)
		{
			float fixedSpeed = Speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target.position, fixedSpeed);
		}

		//Mueve la plataforma del inicio al final y del final al inicio
		if (Target != null && transform.position == Target.position)
		{
			Target.position = (Target.position == _start) ? _end : _start;
		}
	}
}
