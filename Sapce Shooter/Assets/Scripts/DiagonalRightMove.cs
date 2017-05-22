using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalRightMove : MonoBehaviour {
	public int enemyCount;
	public Vector3 newPosition;
	private bool updateOn;

	void Start () {
		updateOn = false;
		StartCoroutine (DiagonalTimer ());


	}

	IEnumerator DiagonalTimer() {
		GetComponent<Rigidbody> ().velocity = (transform.right + transform.up) * 1;
		yield return new WaitForSeconds(1);
		updateOn = true;
	}


	void Update() {
		if (updateOn == true) {
		GetComponent<Rigidbody> ().velocity = transform.right * 1;
			}
	
	}
}

