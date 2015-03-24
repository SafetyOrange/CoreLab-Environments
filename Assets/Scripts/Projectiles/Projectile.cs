using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;
	public float glowSpeed = 1;
	public float damage = 1;
	public bool shotByEnemy = true; //used to determine whether the player shoots it or the enemies shoot it

	SpriteRenderer SpriteRenderR;

	void Start () {
		SpriteRenderR = GetComponent<SpriteRenderer> ();
		StartCoroutine ("loadValues");
	}

	void Update () {
		if (GameManager.isLoaded) {
			transform.position = new Vector3 (transform.position.x + velocity.x * Time.deltaTime, transform.position.y + velocity.y * Time.deltaTime, transform.position.z);
			SpriteRenderR.color = new Color (
				SpriteRenderR.color.r,
				SpriteRenderR.color.g,
				SpriteRenderR.color.b,
				(float) Math.Sin (Time.deltaTime) * 128 + 128);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (shotByEnemy) {
			if (coll.gameObject.tag == "Player") {
				coll.gameObject.SendMessage ("hit");
				Destroy (this.gameObject);
			}
		} else {
			if (coll.gameObject.tag == "Enemy") {
				coll.gameObject.SendMessage ("hit");
				Destroy (this.gameObject);
			}
		}
	}
}
