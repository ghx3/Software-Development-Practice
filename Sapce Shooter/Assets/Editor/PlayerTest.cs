using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class GameControllerTest {
	private int score;
	public GUIText scoreText;
	[Test]

	public void Start (){
		score = 0;
		UpdateScore ();

	}
	public void AddScore(int scoreAdded) {
		//Arrange
		score += scoreAdded;
		UpdateScore ();
	}
	public void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
		//Assert.AreEqual(score, "Score");
		

	}

