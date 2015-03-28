using UnityEngine;
using System.Collections;

public class blueProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.blueProjectileVelocity;
		glowSpeed = GameManager.blueProjectileGlowSpeed;
		damage = GameManager.blueProjectileDamage;
		//shotByEnemy = GameManager.blueProjectileShotByEnemy;
	}
}
