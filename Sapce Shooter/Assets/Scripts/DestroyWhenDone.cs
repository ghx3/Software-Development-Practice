using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class DestroyWhenDone : MonoBehaviour
{
	public float timePassed;

	void Start ()
	{
		Destroy (gameObject, timePassed);
	}
}