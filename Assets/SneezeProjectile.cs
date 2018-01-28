using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeProjectile : MonoBehaviour {

    public int damage = 1;
    private Vector2 currPos;
    private Rigidbody2D rb2d;
    public float moveSpeed;
    public int direction;  // up - 1,
                           // down - 2,
                           // left - 3,
                           // right - 4

    public float timer;

    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed * Time.deltaTime);
        } else if (direction == 2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -moveSpeed * Time.deltaTime);
        } else if (direction == 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("HERE");
            col.gameObject.GetComponent<PlayerController>().health -= this.damage;
            Destroy(this.gameObject);
        }
    }
}
