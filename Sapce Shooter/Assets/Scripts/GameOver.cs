using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public GUIText finalScore;
	private GameController gameController;
	public GameObject gameControllerObject;

	void Start () {

		gameController = gameControllerObject.GetComponent<GameController> ();

		finalScore.text = "Final Score\n" + gameController.getFinalScore ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void playAgain () {
		SceneManager.LoadScene ("Gameplay");
	}
}
