using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy pacing up and down
public class EnemyMovement : MonoBehaviour {

    public float timeToChangeDirection = 0.0f;
    private float originalTimeToChangeDirection;

    public GameObject startingPt;
    public GameObject endingPt;
    private GameObject currentPosition;
    private GameObject currentDestination;

    public float movementSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        originalTimeToChangeDirection = timeToChangeDirection;
        currentDestination = startingPt;
        this.transform.position = this.startingPt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToChangeDirection <= 0.0f)
        {
            this.toggleDirection();
            timeToChangeDirection = originalTimeToChangeDirection;
        } else
        {
            this.moveTowardsPosition(this.currentDestination);
        }
        timeToChangeDirection -= Time.deltaTime;
	}

    void moveTowardsPosition(GameObject destination)
    {
        Transform currPos = this.transform;
        currPos.position = Vector3.MoveTowards(currPos.position, destination.transform.position, movementSpeed * Time.deltaTime);
    }

    void toggleDirection()
    {
        if (this.currentDestination == startingPt)
        {
            this.currentDestination = endingPt;
        } else
        {
            this.currentDestination = startingPt;
        }
    }
}
