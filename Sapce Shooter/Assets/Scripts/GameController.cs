using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public GUIText scoreText;
    private bool gameOver;
    private int score;
	private int stage;
	private float maxEnergy=100f;
	private float currentEnergy=0f;
	public GameObject Energybar;
	private bool enableBigLaser;
	public GameObject bigLaserButton;
	private static int finalScore;


 
	void Start () {
		
		enableBigLaser = false;
		currentEnergy = 0f;
        
        
        
        
        score = 0;
		UpdateScore ();

		bigLaserButton.SetActive(false);

	}


    void Update()
    {
		if (currentEnergy == 100f) {
			
			bigLaserButton.SetActive(true);

		}
        
    }
	public void addEnergy()
	{
		currentEnergy += 10f;
		float calEnergy = currentEnergy/maxEnergy;
		setEnergyBar(calEnergy);
	}

	public void setEnergyBar(float myEnergy)
	{
		Energybar.transform.localScale = new Vector3(0.5f, Mathf.Clamp(myEnergy, 0f, 1f)/*Energybar.transform.localScale.x*/, Energybar.transform.localScale.z);
	}

	public bool getBigLaserBool() {
		return enableBigLaser;
	}

	public void triggerBigLaser () {
		enableBigLaser = true;
	}

	public float resetEnergyBar(){
		enableBigLaser = false;
		bigLaserButton.SetActive(false);

		return currentEnergy = 0;

	}


    public void AddScore (int scoreAdded) {
		score += scoreAdded;
		UpdateScore ();
	}
    public void GameOver()
    {	
		finalScore = score;
		Invoke ("CallGameOverScreen", 3);
    }

	void CallGameOverScreen () {
		SceneManager.LoadScene ("GameOver");
	}

	public int getFinalScore() {
		return finalScore;
	}

    void UpdateScore () {
		scoreText.text = "Score: " + score;

	}

	public void Pause (){

		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}




}