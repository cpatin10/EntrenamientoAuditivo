//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class DrawSceneLine : MonoBehaviour
{

	public Transform From;
	public Transform To;

	
	private void OnDrawGizmosSelected()
	{
		if (From != null && To != null)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(From.position, To.position);
			Gizmos.DrawWireSphere(From.position, 0.15f);
			Gizmos.DrawWireSphere(To.position, 0.15f);
		}
	}
}
