using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject asteroid;
	public Vector3 positionValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	private int score;

	void Start () {
		//GUIText scoreText = GameObject.Find ("Score").GetComponent<GUIText> ();
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnAsteroid ());		
	}

	IEnumerator SpawnAsteroid () {
		yield return new WaitForSeconds (startWait);
		while (true) { //can change later when there is a set number of waves 
			for (int i=0;i<asteroidCount;i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-positionValues.x, positionValues.x), positionValues.y, positionValues.z);
				Quaternion spawnRotation = Quaternion.Euler (90, 0, 0);
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore (int scoreAdded) {
		score += scoreAdded;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}
}
