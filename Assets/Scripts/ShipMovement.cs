using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	float xSpeed;
	float ySpeed;
	bool firing;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		checkInput();
	
	}

	void checkInput(){
		//Check Movement
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
			transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);
		}

		else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
			transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y);
		}

		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) {
			fire();
		}
	}

	void fire(){

	}

}
