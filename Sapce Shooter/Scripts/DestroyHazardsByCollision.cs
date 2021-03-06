using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHazardsByCollision : MonoBehaviour {

	public int asteroidScore;
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}		

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Hazard") {
			gameController.AddScore (asteroidScore);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}

