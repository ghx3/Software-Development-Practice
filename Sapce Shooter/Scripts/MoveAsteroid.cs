using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour {

	public float speed;

	void Start () {
		GetComponent<Rigidbody>().velocity = -transform.up * speed;
	}
}
