﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform firePoint;
    public GameObject purell;
	public int health = 3;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        // Move Ida in the LEFT Direction
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Move Ida in the RIGHT Direction
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        // Move Ida in the UP Direction
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        // Move Ida in the DOWN Direction
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        // fire purell
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(purell, firePoint.position, firePoint.rotation);
        }
        if (this.health <= 0)
        {
            this.Die();
        }
    }

    void OnTriggerEnter2D(Collider2D coughCollider)
    {
        if (coughCollider.CompareTag("WIN"))
        {

        }

        CoughCollider cough = coughCollider.gameObject.GetComponent<CoughCollider>();
        if (cough)
        { //Deduct health when collide with cloud)
            health -= 100;
            print("in cough method here");
            Destroy(cough);
            if (health == 0)
            {
                this.Die();
            }
        }
    }



    void Die()
    {

        Destroy(this.gameObject);
        loadDeathLvl();
    }

    public void loadDeathLvl()
    {
        SceneManager.LoadSceneAsync("04b Lose");
    }
}