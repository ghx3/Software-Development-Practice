using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
	public float speed;
	public GameObject EnemyLaser;
	public float laserWait;

	void Start () {
		StartCoroutine (SpawnLaser ());
	}
	//shoot laser automaticially 
	IEnumerator SpawnLaser () {
		while (true) {
			Instantiate (EnemyLaser, transform.position, transform.rotation);
			yield return new WaitForSeconds (laserWait);
		}
	}

	void Update () {
		
	}
}
