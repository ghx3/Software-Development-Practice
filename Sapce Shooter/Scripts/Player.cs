using System.Collections;
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
	//set the ship moving speed
	void Start () {
		speed = 3;
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
