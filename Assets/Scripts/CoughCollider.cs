using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughCollider : MonoBehaviour {

	public int damage = 100;

	public int GetDamage(){
		return damage;
	}

	void OnTriggerEnter2D(Collider2D coughCollider){
		
	}

	public void Evaporate(){
		Destroy(gameObject);
	}
		
}
