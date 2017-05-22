using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	private Stage stage;
	public int enemyCount;
	public Vector3 newPosition;
	private bool updateOn;

	void Start () {
		GameObject gameControllerObject= GameObject.FindWithTag ("GameController");
		stage = gameControllerObject.GetComponent<Stage> ();
		StartCoroutine (DiagonalRight ());


	}

	void Update () {
		if (stage.GetEnemyMovement ()==1) {
			NormalMove ();
		}
		if (stage.GetEnemyMovement ()==2) {
			StartCoroutine (DiagonalRight ());
		}
		if (stage.GetEnemyMovement ()==3) {
			StartCoroutine (DiagonalLeft ());
		}
		if (stage.GetEnemyMovement ()==4) {
			StartCoroutine (DiagonalRightUp ());
		}
		if (stage.GetEnemyMovement ()==5) {
			StartCoroutine (DiagonalLeftUp ());
		}


	}

	void NormalMove() {
		GetComponent<Rigidbody>().velocity = transform.up*1;
	}


	IEnumerator DiagonalRight() {
		GetComponent<Rigidbody>().velocity = (transform.right+transform.up) * 2;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody>().velocity = transform.right*2;
	}

	IEnumerator DiagonalLeft() {
		GetComponent<Rigidbody> ().velocity = (-transform.right+transform.up) * 2;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody> ().velocity = -transform.right*2;
	}

	IEnumerator DiagonalRightUp() {
		GetComponent<Rigidbody> ().velocity = (transform.right + transform.up) * 1;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody> ().velocity = transform.up * 1;
	}

	IEnumerator DiagonalLeftUp() {
		GetComponent<Rigidbody> ().velocity = (-transform.right + transform.up) * 1;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody> ().velocity = transform.up * 1;
	}
}

