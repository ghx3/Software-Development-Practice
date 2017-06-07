using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour {
    public float maxEnergy=100f;
    public float currentEnergy=0f;
    public GameObject Energybar;
	private bool enableBigLaser;

	// Use this for initialization
	void Start () {
		
        currentEnergy = 0f;
        InvokeRepeating("addEnergy",1f,1f);

	}
	
	// Update is called once per frame
	void Update () {
		if (currentEnergy == 100f) {
			enableBigLaser = true;
		}
	}
    void addEnergy()
    {
        currentEnergy += 2f;
        float calEnergy = currentEnergy/maxEnergy;
        setEnergyBar(calEnergy);
    }
    public void setEnergyBar(float myEnergy)
    {
        Energybar.transform.localScale = new Vector3(Mathf.Clamp(myEnergy, 0f, 1f), Energybar.transform.localScale.x, Energybar.transform.localScale.z);
    }

	public bool getBigLaserStatus() {
		return enableBigLaser;
	}

}

