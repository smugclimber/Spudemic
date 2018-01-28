using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Transform firePoint;
	public GameObject purell;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			Instantiate(purell, firePoint.position, firePoint.rotation);
		}
	}
}
