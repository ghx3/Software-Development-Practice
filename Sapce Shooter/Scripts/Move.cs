﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed;

	void Start () {
		GetComponent<Rigidbody>().velocity = -transform.up * speed;
	}
}
