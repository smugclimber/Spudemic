using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;	public bool autoPlay = false;

    public float shipSpeed = 15.0f;
	public float padding = 1f;
	public int shield = 500;

    public AudioClip fireSound;

    private ShieldController shieldControl;
	private float xMin, xMax;

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D collidingProj)
    {
        Projectile missile = collidingProj.gameObject.GetComponent<Projectile>(); //creates new object within Enemy upon collision of gameObjects with Projectile components
        if (missile)
        { //If misille is true and exists because it has Projectile components
            Debug.Log("Player collided with missile");
            shield -= missile.GetDamage();
            missile.Evaporate();
            shieldControl.ShieldLevel(shield);
            if (shield <= 0)
            {
                Die();
            }
        }
    }

    void Die(){
        Destroy(gameObject);
        shieldControl.GameOver();
    }

    void Start(){
		// Below we use the Camera to obtain the gamespaces left and most right deminsions
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
        shieldControl = GameObject.FindObjectOfType<ShieldController>();
    }


    void FireProjectile()
    {
        Vector3 safeDist = transform.position + new Vector3(0, 0.6f, 0); //Creates laser that doesn't immediately damage player
        GameObject beam = Instantiate(projectile, safeDist, Quaternion.identity) as GameObject; //Instatiate normally produces Objects and we want a GameObject
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){ //turns on firing rate when shooting
			InvokeRepeating ("FireProjectile", 0.00001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("FireProjectile");
		}
		MoveWithKeyboard();
	}
	
	void MoveWithKeyboard (){
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * shipSpeed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * shipSpeed * Time.deltaTime;
		}
		// restict player to the gamespace
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, 0f);
	}
}
