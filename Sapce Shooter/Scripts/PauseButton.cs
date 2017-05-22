using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour{
	

	void Update (){
		
	}

	public void Pause (){
		 
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}

}


