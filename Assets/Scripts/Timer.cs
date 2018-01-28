using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float fadeRate = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//decrease timer
		if(fadeRate > 0){
			fadeRate -= Time.deltaTime;
		} else {
			Destroy (gameObject);
		}
			
}
}
