using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float speed = 5;
	Vector2 velocity = -Vector2.up;

	void Start () {
		Vector2 velocity = -Vector2.up * speed;
	}

	void Update () {
		transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.SendMessage("hit");
			Destroy(this.gameObject);
		}

	}
}
