using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HealthSystem healthSystem = new HealthSystem(100);

        Debug.Log("Health: " + healthSystem.GetHealth());


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
