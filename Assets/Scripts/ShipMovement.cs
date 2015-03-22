using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	Vector2 speed = new Vector2(5,0);
	bool firing = false;
	
	void Start () {
		StartCoroutine ("loadValues");
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
			Debug.Log ("not loaded");
			yield return null;
		}
		speed = new Vector2 (GameManager.shipSpeed.x, GameManager.shipSpeed.y);
	}

	void Update () {
		checkInput();
	
	}

	void checkInput(){

		//Check Movement
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
			transform.position = new Vector3(transform.position.x - speed.x, transform.position.y, transform.position.z);
		}else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
			transform.position = new Vector3(transform.position.x + speed.x, transform.position.y, transform.position.z);
		}

		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) {
			fire();
		}
	}

	void fire(){

	}

}
