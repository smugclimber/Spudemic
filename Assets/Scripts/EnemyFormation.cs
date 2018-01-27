using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyFormation : MonoBehaviour {
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed;
	public float enemyFirRate = 0.5f;
    public int scoreValue = 150;

    public AudioClip fireSound;
    public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;

    void Start(){
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
    }

	void Update () {
		float probability = enemyFirRate*Time.deltaTime;
		if (Random.value < probability){
			FireEnemyproj();
		}
	}
	
	void FireEnemyproj(){
		Vector3 safeDist = transform.position + new Vector3(0,-0.9f,0);
		GameObject enemyBeam = Instantiate(projectile, safeDist, Quaternion.identity) as GameObject; //Instatiate normally produces Objects and we want a GameObject
		enemyBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D collidingProj){
		Projectile missile =  collidingProj.gameObject.GetComponent<Projectile>(); //creates new object within Enemy upon collision of gameObjects with Projectile components
		if(missile){ //If misille is true and exists because it has Projectile components
			health -= missile.GetDamage();
			missile.Evaporate();
			if(health <= 0){
                Die();
			}
		}
	}

    void Die() {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
        scoreKeeper.Achievement();
    }
}
