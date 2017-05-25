using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject asteroidS;
	public GameObject asteroidM;
	public GameObject asteroidL;
	public GameObject enemy;
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
	private int stage;
	private float maxEnergy=100f;
	private float currentEnergy=0f;
	public GameObject Energybar;

 
	void Start () {
		currentEnergy = 0f;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        //GUIText scoreText = GameObject.Find ("Score").GetComponent<GUIText> ();
        score = 0;
		UpdateScore ();
		//StartCoroutine (SpawnAsteroid ());		
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
	public void addEnergy()
	{
		currentEnergy += 2f;
		float calEnergy = currentEnergy/maxEnergy;
		setEnergyBar(calEnergy);
	}

	public void setEnergyBar(float myEnergy)
	{
		Energybar.transform.localScale = new Vector3(0.5f, Mathf.Clamp(myEnergy, 0f, 1f)/*Energybar.transform.localScale.x*/, Energybar.transform.localScale.z);
	}




    public void AddScore (int scoreAdded) {
		score += scoreAdded;
		UpdateScore ();
	}
    public void GameOver()
    {
        gameOver = true;
		SceneManager.LoadScene ("GameOver");

        
    }

    void UpdateScore () {
		scoreText.text = "Score: " + score;

	}




}