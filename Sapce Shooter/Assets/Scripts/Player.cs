using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin,xMax, zMin, zMax;
}

public class Player : MonoBehaviour {
	public float speed;
    // Use this for initialization

	public GameObject Laser;
	public GameObject LaserPosition;

    public Boundary boundary;
    void Start () {
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown("space")){
			
				GameObject bullet = (GameObject)Instantiate (Laser);
				bullet.transform.position = LaserPosition.transform.position;

		}*/
		Instantiate (Laser, transform.position, transform.rotation);

		float axisX= Input.GetAxis ("Horizontal");
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
