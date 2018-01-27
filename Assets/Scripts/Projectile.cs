using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage = 100;
	
	public int GetDamage(){
		return damage;
	}
	
	public void Evaporate(){
		Destroy(gameObject);
	}
}
