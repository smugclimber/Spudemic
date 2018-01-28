﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurellController : MonoBehaviour {
	public float speed;
	public PlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();

		if(player.transform.localScale.x < 0) speed = -speed;
	}

	void FixedUpdate () {
		transform.Rotate (Vector3.forward * -45);
	}

	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (gameObject);
	}
}
