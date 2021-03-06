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
    public GUIText restartText;
    public GUIText gameOverText;
    private bool gameOver;
    private bool restart;
    private int score;
 
	void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
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
                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
            }
         
            yield return new WaitForSeconds (waveWait);
		}
	}
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void AddScore (int scoreAdded) {
		score += scoreAdded;
		UpdateScore ();
	}
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void UpdateScore () {
		scoreText.text = "Score: " + score;
	}
}
