using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float speed = 5;
	Vector2 velocity = -Vector2.up;

	void Start () {
		Vector2 velocity = -Vector2.up * speed;
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.SendMessage("hit");
			Destroy(this.gameObject);
		}

	}
}
