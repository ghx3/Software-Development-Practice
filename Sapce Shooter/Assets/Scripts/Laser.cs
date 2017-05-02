using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {



		Vector3 position = transform.position;

		position = new Vector3 (position.x , position.y,position.z+ speed * Time.deltaTime );

		transform.position = position;

		Vector3 max = (new Vector3 (1, 1,1));

		if(transform.position.y > max.y){
			Destroy (gameObject);
	}
}
}
