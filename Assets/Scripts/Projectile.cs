using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float speed = 5;
	Vector2 velocity = -Vector2.up;

	void Start () {

	}

	void Update () {
		transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y + velocity.y * Time.deltaTime, transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.SendMessage("hit");
			Destroy(this.gameObject);
		}

	}
}
