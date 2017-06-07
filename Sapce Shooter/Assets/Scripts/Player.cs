//<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin,xMax, zMin, zMax;
}

public class Player : MonoBehaviour {
	public float speed;
    public GameObject Laser;
	public Boundary boundary;
	public float laserWait;
	private Vector3 currentPosition;
	public GameObject BigLaser;
	private bool enableBigLaser;
	private bool enableLaser;
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject= GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		enableBigLaser = false;
		enableLaser = true;
		StartCoroutine (SpawnLaser ());

	}
	//shoot laser automaticially 
	IEnumerator SpawnLaser () {
		while (enableLaser) {
			Instantiate (Laser, transform.position, transform.rotation);
			yield return new WaitForSeconds (laserWait);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
	}

	IEnumerator SpawnBigLaser () {
		while (enableBigLaser) {
			Instantiate (BigLaser, transform.position, transform.rotation);
			yield return new WaitForSeconds (0);
		}
	}

	IEnumerator BigLaserTimer () {
		yield return new WaitForSeconds (5);
		enableBigLaser = false;
		enableLaser = true;
		StartCoroutine (SpawnLaser ());
		gameController.resetEnergyBar ();
	}



	void Update () {
		enableBigLaser = gameController.getBigLaserBool();
		if (Input.GetKeyDown("space") && enableBigLaser == true) {
			enableLaser = false;
		
			
			StartCoroutine (SpawnBigLaser ());
			StartCoroutine (BigLaserTimer());
		}
		//BigLaser.transform.position = transform.position;
		//touch input
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, 4));
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime*speed); //move drag ship
				//GetComponent<Rigidbody>().velocity = touchPosition * speed; //move like joystick
				GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, 
					Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
            }


		}
		//keyboard input 
		
		//get horizontal length
		float axisX= Input.GetAxis ("Horizontal");
		//get vertical length
		float axisY = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3(axisX, 0.0f, axisY);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3
           (
               Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
           );

    }
}
/*====== 
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin,xMax, zMin, zMax;
}

public class Player : MonoBehaviour {
	public float speed;
    public GameObject Laser;
	public Boundary boundary;
	public float laserWait;

	void Start () {
		StartCoroutine (SpawnLaser ());
	}
	//shoot laser automaticially 
	IEnumerator SpawnLaser () {
		while (true) {
			Instantiate (Laser, transform.position, transform.rotation);
			yield return new WaitForSeconds (laserWait);
		}
	}

	void Update () {
		//touch input
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, 4));
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime*speed); //move drag ship
				//GetComponent<Rigidbody>().velocity = touchPosition * speed; //move like joystick
				GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, 
					Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
            }
		}
		//keyboard input 
		
		//get horizontal length
		float axisX= Input.GetAxis ("Horizontal");
		//get vertical length
		float axisY = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3(axisX, 0.0f, axisY);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3
           (
               Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
           );

    }
}
>>>>>>> origin/master
*/