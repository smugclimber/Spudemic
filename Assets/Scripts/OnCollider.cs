using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On : MonoBehaviour {
	public bool characterInQuicksand;
	void OnTriggerEnter2D(Collider2D other) {
		characterInQuicksand = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
