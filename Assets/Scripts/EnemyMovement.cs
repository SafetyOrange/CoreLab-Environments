using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	bool alive = false;
	string type = "advance";
	float xSpeed = 0;
	float ySpeed = 5;
	Vector2 currentSpeed = Vector2.zero;
	GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		switch(type){

		case "advance":
			//Advance Enemy
			transform.position = new Vector2( transform.position.x, (transform.position.y - ySpeed) );
			break;
		case "homing":
			//Homing Enemy
			float xLerp = Mathf.Lerp(transform.position.x, player.transform.position.x, .5f);
			transform.position = new Vector2(xLerp, transform.position.y - ySpeed);
			break;
		case "oscillate":
			//Oscillating Enemy
			float x = xSpeed * Mathf.Sin(Time.time);
			transform.position = new Vector2(x, transform.position.y);
			break;
		case "radial":
			//Static / AOE Enemy
			if(Vector2.Distance(transform.position, new Vector2(transform.position.x, Screen.height*.5f))>=4){
				transform.position = new Vector2(transform.position.x, transform.position.y - ySpeed);
			}
			else{
				fire();
			}
			break;

		}

	}

	void fire(){
	
	}
}
