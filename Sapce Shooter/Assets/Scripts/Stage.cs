using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	private GameController gameController;
	public GameObject asteroidS;
	public GameObject asteroidM;
	public GameObject asteroidL;
	public GameObject enemy;
	public Vector3 positionValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int enemyMovement;
	private int score;
	private bool nextWave;
	private bool nextStage;
	private int stage;
	public GUIText stageText;

	void Start () {
		GameObject gameControllerObject= GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		nextWave = false; 
		nextStage = false;
		stage = 1;
		StartCoroutine (Stages ()); //starts stages
		stageText.text = "Stage " + stage;
		}

	void Update () {
		stageText.text = "Stage " + stage; //updates stage text to current stage
	}

	IEnumerator Stages () { //stage status change
		StartCoroutine (Stage1 ());
		yield return new WaitUntil (() => nextStage);
		StartCoroutine (Stage2 ());
		yield return new WaitUntil (() => nextStage);
		StartCoroutine (Stage3 ());
		yield return new WaitUntil (() => nextStage);
	}

	public int GetEnemyMovement() { //to pass assigned enemy movement to instantiated enemy
		return enemyMovement;
	}

	IEnumerator Stage1 () { 
		nextStage = false;
		stageText.enabled = true;
		yield return new WaitForSeconds (startWait);
		stageText.enabled = false;
		StartCoroutine (SpawnHazard (10,0,5));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (10,6,8));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (10,9,10));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (15,0,8));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (20,0,10));
		yield return new WaitUntil (()=> nextWave);
		nextStage = true;
		stage = stage + 1;
	}

	IEnumerator Stage2 () {
		nextStage = false;
		stageText.enabled = true;
		yield return new WaitForSeconds (startWait);
		stageText.enabled = false;
		StartCoroutine (SpawnHazard (10,0,10));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (10,0,13));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (10,9,12));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (15,11,13));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (20,3,13));
		yield return new WaitUntil (()=> nextWave);
		nextStage = true;
		stage = stage + 1;
	}

	IEnumerator Stage3 () {
		nextStage = false;
		stageText.enabled = true;
		yield return new WaitForSeconds (startWait);
		stageText.enabled = false;
		StartCoroutine (SpawnHazard (10,0,13));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnEnemyFormation1 (4));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnHazard (10,0,13));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnEnemyFormation2 (4));
		yield return new WaitUntil (()=> nextWave);
		StartCoroutine (SpawnEnemyFormation3 (4));
		yield return new WaitUntil (()=> nextWave);
		nextStage = true;
		stage = stage + 1;
	}

	IEnumerator SpawnHazard (int hazardCount, int min, int max) { //spawns asteroids and enemies in random positions
		enemyMovement = 1;
		nextWave = false;
		for (int i=0;i<hazardCount;i++) {
			int range = Random.Range(min, max);
			Vector3 spawnPosition = new Vector3 (Random.Range (-positionValues.x, positionValues.x), positionValues.y, positionValues.z);
			Quaternion spawnRotation = Quaternion.Euler (90, 0, 180);
			if (range <= 5) {
				Instantiate (asteroidM, spawnPosition, spawnRotation);
			} else if (range > 5 && range <= 8) {
				Instantiate (asteroidS, spawnPosition, spawnRotation);
			} else if (range > 8 && range <= 10) {
				Instantiate (asteroidL, spawnPosition, spawnRotation);
			} else if (range > 10 && range <= 13) {
				Instantiate (enemy, spawnPosition, spawnRotation);
			}
			yield return new WaitForSeconds(spawnWait);
		}
		yield return new WaitForSeconds (waveWait);
		nextWave = true;
	}

	IEnumerator SpawnEnemyFormation1 (int enemyCount) { //spawn enemies form the side moving inward
		nextWave = false;
		for (int j = 0; j < 3; j++) {
			yield return new WaitForSeconds (2);
			for (int i = 0; i < enemyCount; ++i) {
				enemyMovement = 2;
				Instantiate (enemy, new Vector3 (2, 0, 3), Quaternion.Euler (90, 0, 180));
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (2);
			for (int i = 0; i < enemyCount; ++i) {
				enemyMovement = 3;
				Instantiate (enemy, new Vector3 (-2, 0, 3), Quaternion.Euler (90, 0, 180));
				yield return new WaitForSeconds (spawnWait);
			}
		}
		yield return new WaitForSeconds (waveWait);
		nextWave = true;
	}

	IEnumerator SpawnEnemyFormation2 (int enemyCount) { //spawn enemies from the side moieng downward
		nextWave = false;
		for (int j = 0; j < 3; j++) {
			yield return new WaitForSeconds (2);
			for (int i = 0; i < enemyCount; ++i) {
				enemyMovement = 4;
				Instantiate (enemy, new Vector3 (2, 0, 3), Quaternion.Euler (90, 0, 180));
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (2);
			for (int i = 0; i < enemyCount; ++i) {
				enemyMovement = 5;
				Instantiate (enemy, new Vector3 (-2, 0, 3), Quaternion.Euler (90, 0, 180));
				yield return new WaitForSeconds (spawnWait);
			}
		}
		yield return new WaitForSeconds (waveWait);
		nextWave = true;
	}

	IEnumerator SpawnEnemyFormation3 (int rows) { //spawns rows of enemies
		nextWave = false;
		for (int i = 0; i < rows; ++i) {
			int x = -1;
			enemyMovement = 1;
			for (int j = 0; j < 3;++j) {
				Instantiate (enemy, new Vector3 (x, 0, 4), Quaternion.Euler (90, 0, 180));
				x =(int) ( x+1);
			}
			yield return new WaitForSeconds (spawnWait);
		}
		yield return new WaitForSeconds (waveWait);
		nextWave = true;
	}
}