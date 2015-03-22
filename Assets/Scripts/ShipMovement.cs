using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	float xSpeed = 5;
	float ySpeed = 0;
	bool firing = false;
	
	void Start () {
		StartCoroutine ("loadValues");
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
			Debug.Log ("not loaded");
			yield return null;
		}
		xSpeed = GameManager.shipSpeed.x;
		ySpeed = GameManager.shipSpeed.y;
		Debug.Log (xSpeed);
	}

	void Update () {
		checkInput();
	
	}

	void checkInput(){

		//Check Movement
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
			transform.position = new Vector3(transform.position.x - xSpeed, transform.position.y, transform.position.z);
		}

		else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
			transform.position = new Vector3(transform.position.x + xSpeed, transform.position.y, transform.position.z);
		}

		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) {
			fire();
		}
	}

	void fire(){

	}

}
