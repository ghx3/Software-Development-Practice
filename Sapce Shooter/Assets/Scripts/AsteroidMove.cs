﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {

	public float speed;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}
}