using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;


	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(Input.GetMouseButtonDown(0))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
			
			} else if (Time.timeScale == 0){

				Time.timeScale = 1;
			
			}
		}
	}




	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;

		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
	
		}
	}





	private void OnGUI(){
		GUI.Button(new Rect(368,5,30,30),"| |");
	}
		
}
