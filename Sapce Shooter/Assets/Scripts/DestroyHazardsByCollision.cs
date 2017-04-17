using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHazardsByCollision : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Hazard") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}

