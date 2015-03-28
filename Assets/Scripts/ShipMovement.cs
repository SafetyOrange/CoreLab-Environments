using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	Vector2 speed = new Vector2(5,0);
	bool firing = false;
	float fireCooldownTime = 1;
	float lastFireTime = 0;
	bool wrapScreen = false;
	float health = 1;

	public Transform shipShot;
	public Transform explosion;
	
	void Start () {
		StartCoroutine ("loadValues");
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
		//	Debug.Log ("not loaded; Ship Movement 16");
			yield return null;
		}
		speed = new Vector2 (GameManager.shipSpeed.x, GameManager.shipSpeed.y);
		wrapScreen = GameManager.shipWrap;
		health = GameManager.shipHealth;
		fireCooldownTime = GameManager.shipFireCooldown;
	}

	void Update () {
		checkInput();
		
	}

	void checkInput(){

		Vector3 movement = transform.position;

		//Check Movement
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
			movement.x -= speed.x * Time.deltaTime;
		}else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
			movement.x += speed.x * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			movement.y += speed.y * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			movement.y -= speed.y * Time.deltaTime;
		}
		if (wrapScreen) {
			//need this here
		}
		transform.position = movement;

		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) {
			fire();
		}
	}

	void fire(){
		if (!firing) {
			firing = true;
			lastFireTime = Time.time;
			Instantiate (shipShot, transform.position, transform.rotation);
		} else {
			if (Time.time - lastFireTime > fireCooldownTime) {
				firing = false;
			}
		}
	}
	void hit( float damage ) {
		health -= damage;
		Debug.Log ("SHIP HIT! Health Left: " + health);
		if (health < 0) {
			explode ();
		}
	}
	void explode() {
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		GameManager.restartRequired = true;
	}
}
