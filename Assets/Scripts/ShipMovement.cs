using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	Vector2 speed = new Vector2(5,0);
	bool firing = false;
	bool wrapScreen = false;
	
	void Start () {
		StartCoroutine ("loadValues");
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
			Debug.Log ("not loaded");
			yield return null;
		}
		speed = new Vector2 (GameManager.shipSpeed.x, GameManager.shipSpeed.y);
		wrapScreen = GameManager.shipWrap;
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
		 
		transform.position = movement;


		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) {
			fire();
		}
	}

	void fire(){

	}

}
