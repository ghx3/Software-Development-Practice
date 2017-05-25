using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLaserMove : MonoBehaviour {

	public GameObject Player;

	void Start () {
		StartCoroutine (SpawnBigLaser ());
	}
	

	void Update () {
		
	}

	IEnumerator SpawnBigLaser () {
		while (true) {
			transform.position = Player.transform.position;
		}
		yield return new WaitForSeconds (0);
	}
}
