using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour {

	public int hazardScore;
	private GameController gameController;
	public GameObject explosion;

    

    void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
    }		

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Laser") {
			gameController.AddScore (hazardScore);
			gameController.addEnergy ();
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
		if (other.tag == "BigLaser") {
			gameController.AddScore (hazardScore);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
}

