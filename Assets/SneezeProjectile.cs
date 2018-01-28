using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeProjectile : MonoBehaviour {

    public float timer;
    private float originalTimerValue;
    public float xSpeed;
 

	// Use this for initialization
	void Start () {
        this.originalTimerValue = this.timer;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hello", other);
    }
}
