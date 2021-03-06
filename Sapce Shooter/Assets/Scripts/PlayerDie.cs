﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDie : MonoBehaviour {

	private GameController gameController;
	public GameObject explosion;

	public Slider healthBar;
	public float CurrentHealth { get; set; }
	public float MaxHealth { get; set; }

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
		//initial health for the spaceship
		MaxHealth =100f;
		CurrentHealth = MaxHealth;
		//parameter for health bar display
		healthBar.value = MaxHealth;
	}	


	//damage value
	void Damage(float damageValue){
		CurrentHealth -= damageValue;
		healthBar.value = CalculateHealth ();
		if(CurrentHealth <= 0){
			CurrentHealth = 0;
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.GameOver();
		}
	}
	//get current health for the spaceship
	float CalculateHealth(){
		return CurrentHealth / MaxHealth;
	}
	//destory trigger event
	void OnTriggerEnter (Collider other) {
		if (other.tag == "AsteroidS" || other.tag == "AsteroidM" || other.tag == "AsteroidL" || other.tag == "Enemy" || other.tag == "EnemyLaser") {

			Destroy (other.gameObject);
			Damage(10f);
		}

	}
}


