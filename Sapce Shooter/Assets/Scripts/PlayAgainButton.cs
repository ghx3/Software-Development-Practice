using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Pause () {
        if (Time.timeScale == 1)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}