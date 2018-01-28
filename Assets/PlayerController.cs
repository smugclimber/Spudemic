using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform firePoint;
	public GameObject purell;
	public int health = 150;

	// Use this for initialization
	void Start () {
		print ("start");
	}

	void OnTriggerEnter2D(Collider2D coughCollider){
		print ("in collider");
		CoughCollider cough =  coughCollider.gameObject.GetComponent<CoughCollider>();
		if(cough){ //Deduct health when collide with cloud)
			health -= 100; 
			print ("in cough method here");
			Destroy(cough);
			if(health <= 0){
				Die();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		// fire purell
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Instantiate(purell, firePoint.position, firePoint.rotation);
		}
	}
		

	void Die() {
		Destroy(gameObject);
	}
}
