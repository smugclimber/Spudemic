using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughAttack : MonoBehaviour {

    public GameObject coughPrefab;
    public float rateOfFire = 0.0f;
    private float originalRateOfFire;

	// Use this for initialization
	void Start () {
        originalRateOfFire = rateOfFire;
	}
	
	// Update is called once per frame
	void Update () {
        rateOfFire -= Time.deltaTime;
		if (rateOfFire <= 0.0f)
        {
            Vector3 pos = new Vector3(this.transform.position.x - 1.0f, this.transform.position.y, 0.2f);
            Instantiate(coughPrefab, pos, Quaternion.identity);
            rateOfFire = originalRateOfFire;
        }
	}
}
