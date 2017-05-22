using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour {

	private GameController gameController;
	public GameObject explosion;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}		

	void OnTriggerEnter (Collider other) {
		if (other.tag == "AsteroidS" || other.tag == "AsteroidM" || other.tag == "AsteroidL" || other.tag == "Enemy" || other.tag == "EnemyLaser") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.GameOver();
		}
	}
}

