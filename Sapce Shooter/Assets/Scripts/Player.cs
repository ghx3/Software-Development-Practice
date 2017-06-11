//<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


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
	private Touch firstTouch;
	private Touch touch;
	private Vector3 firstTouchPosition;
	private Vector3 touchPosition;

	void Start () {
		GameObject gameControllerObject= GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		enableBigLaser = false;
		enableLaser = true;
		InvokeRepeating ("SpawnLaser", 0.1f, 0.5f);
		InvokeRepeating ("SpawnBigLaser", 0, 0.001f);
			


	}

	void SpawnLaser() {

		if (enableLaser) {
			Instantiate (Laser, transform.position, transform.rotation);
			//yield return new WaitForSeconds (laserWait);
		}
	}

	void SpawnBigLaser () {
		if (enableBigLaser) {
			Instantiate (BigLaser, transform.position, transform.rotation);

		}
	}

	IEnumerator BigLaserTimer () {
		yield return new WaitForSeconds (5);
		enableBigLaser = false;
		enableLaser = true;
		gameController.resetEnergyBar ();
	}



	void Update () {
		//Input.GetKeyDown ("space") &&
		enableBigLaser = gameController.getBigLaserBool ();
		if (enableBigLaser) {
			enableLaser = false;



			StartCoroutine (BigLaserTimer ());

		}


		//touch input
		if (Input.touchCount > 0) {
			
		
			firstTouch = Input.GetTouch (0);
			firstTouchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (firstTouch.position.x, firstTouch.position.y, 5));

            
			if ((firstTouch.phase == TouchPhase.Began ||firstTouch.phase ==TouchPhase.Stationary) && Physics.CheckCapsule (firstTouchPosition, firstTouchPosition, 0.20f)) {
				
				touch = Input.GetTouch (0);
				touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 5));
			}
			if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
				touch = Input.GetTouch (0);
				touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 5));
				transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime * speed); //move drag ship
				//GetComponent<Rigidbody>().velocity = touchPosition * speed; //move like joystick
				GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 0.0f, 
					Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));
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

		
	/*/
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