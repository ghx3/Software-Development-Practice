using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour {

	public int asteroidScore;
	private GameController gameController;
	public GameObject explosion;
	//public Vector3 spawnRotation;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}		

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Laser") {
			gameController.AddScore (asteroidScore);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
            gameController.GameOver();
		}
	}
}

