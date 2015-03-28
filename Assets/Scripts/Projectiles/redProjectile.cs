﻿using UnityEngine;
using System.Collections;

public class redProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.redProjectileVelocity;
		glowSpeed = GameManager.redProjectileGlowSpeed;
		damage = GameManager.redProjectileDamage;
		//shotByEnemy = GameManager.redProjectileShotByEnemy;
	}
}
