﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameManager {

	// Variables for File Input
	public static bool isLoaded = false;

	//Game Variables


/* 
 * IMPORTANT!!! You have to add in each variable name three times!
 * 
 *	1. The name of the variable in variableNames[] in order for the program to asssign it from the spreadsheet
 *	2. The variable name as public static <Type> so scripts can access it
 *	3. The switch statement to hook up the variableNames[] with the Spreadsheet 
 *	
 */
	private static string[] variableNames = {
		"backgroundScrollSpeed",

		"shipSpeed",
		"shipWrap",
		"shipFireCooldown",
		"shipHealth",
		"shipShotDamage",
		"shipShotVelocity",
		"shipShotGlowSpeed",
		"shipRammingDamage",

		"redProjectileVelocity",
		"redProjectileGlowSpeed",
		"redProjectileDamage",
		"redProjectileVariance",

		"blueProjectileVelocity",
		"blueProjectileGlowSpeed",
		"blueProjectileDamage",
		"blueProjectileVariance",

		"yellowProjectileVelocity",
		"yellowProjectileGlowSpeed",
		"yellowProjectileDamage",
		"yellowProjectileVariance",

		"greenProjectileVelocity",
		"greenProjectileGlowSpeed",
		"greenProjectileDamage",
		"greenProjectileVariance",

		"billEnemySpeed",
		"billEnemyFireCooldownTime",
		"billEnemyHealth",
		"billEnemyWrapScreen",
		"billEnemyRammingDamage",

		"keshaEnemySpeed",
		"keshaEnemyHealth",
		"keshaEnemyFireCooldownTime",
		"keshaEnemyWrapScreen",
		"keshaEnemyRammingDamage",

		"aeroflotEnemySpeed",
		"aeroflotEnemyHealth",
		"aeroflotEnemyFireCooldownTime",
		"aeroflotEnemyWrapScreen",
		"aeroflotEnemyRammingDamage"
	};
	public static Vector2 backgroundScrollSpeed;
	public static Vector2 shipSpeed;
	public static bool shipWrap;
	public static float shipHealth;
	public static float shipFireCooldown;
	public static float shipShotDamage;
	public static Vector2 shipShotVelocity;
	public static float shipShotGlowSpeed;
	public static float shipRammingDamage;

	// --------------- // --------------- // --------------- Projectile Variables
	public static Vector2 redProjectileVelocity;
	public static float redProjectileGlowSpeed;
	public static float redProjectileDamage;
	public static Vector2 redProjectileVariance;

	public static Vector2 blueProjectileVelocity;
	public static float blueProjectileGlowSpeed;
	public static float blueProjectileDamage;
	public static Vector2 blueProjectileVariance;

	public static Vector2 yellowProjectileVelocity;
	public static float yellowProjectileGlowSpeed;
	public static float yellowProjectileDamage;
	public static Vector2 yellowProjectileVariance;

	public static Vector2 greenProjectileVelocity;
	public static float greenProjectileGlowSpeed;
	public static float greenProjectileDamage;
	public static Vector2 greenProjectileVariance;

	// --------------- // --------------- // --------------- Enemy Variables
	public static float billEnemyHealth;
	public static Vector2 billEnemySpeed;
	public static float billEnemyFireCooldownTime;
	public static bool billEnemyWrapScreen;
	public static float billEnemyRammingDamage;

	public static Vector2 keshaEnemySpeed;
	public static float keshaEnemyHealth;
	public static float keshaEnemyFireCooldownTime;
	public static bool keshaEnemyWrapScreen;
	public static float keshaEnemyRammingDamage;

	public static Vector2 aeroflotEnemySpeed;
	public static float aeroflotEnemyHealth;
	public static float aeroflotEnemyFireCooldownTime;
	public static bool aeroflotEnemyWrapScreen;
	public static float aeroflotEnemyRammingDamage;


	// --------------- // --------------- // --------------- Other Game State Variables
	public static bool restartRequired = false;

	public static void init () {
		List<string> fileSplit = new List<string> ();

		TextAsset file = Resources.Load ("GameValues") as TextAsset;

		string[] commaSeperatedArray = file.text.Split (',');

		foreach (string temp in commaSeperatedArray) { // go through each value split by commas
			if (temp.IndexOf ('\n') != -1) {
				string[] sSplit = temp.Split ('\n');
				if (sSplit [0] != "") { //don't add the blank line if there is one
					fileSplit.Add (sSplit [0]);
				}
				if (sSplit [1] != "") { //don't add the blank line if there is one
					fileSplit.Add (sSplit [1]);
				}
			} else {
				fileSplit.Add (temp);
			}
		}
		/*foreach (string theS in fileSplit) {
			Debug.Log (theS + " fileSplit value (40)");
		}*/

		foreach (string key in variableNames) { //this is the line that assigns all values. If something is messing up, it's probably here. 
			int index = fileSplit.IndexOf (key); //find index of a variable name
			if (index != -1) {
				switch (key) {
				case "backgroundScrollSpeed":
					backgroundScrollSpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
					// --------------- // --------------- // --------------- // --------------- // --------------- Ship Variables
				case "shipSpeed":
					shipSpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "shipWrap":
					shipWrap = bool.Parse (fileSplit [index + 1]);
					break;
				case "shipHealth":
					shipHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "shipFireCooldown":
					shipFireCooldown = float.Parse (fileSplit [index + 1]);
					break;
				case "shipShotDamage":
					shipShotDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "shipShotVelocity":
					shipShotVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "shipShotGlowSpeed":
					shipShotGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "shipRammingDamage":
					shipRammingDamage = float.Parse (fileSplit [index + 1]);
					break;
					// --------------- // --------------- // --------------- // --------------- // --------------- Projectile Variables
				case "redProjectileVelocity":
					redProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "redProjectileGlowSpeed":
					redProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "redProjectileDamage":
					redProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "redProjectileVariance":
					redProjectileVariance  = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;

				case "blueProjectileVelocity":
					blueProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "blueProjectileGlowSpeed":
					blueProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "blueProjectileDamage":
					blueProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "blueProjectileVariance":
					blueProjectileVariance  = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;

				case "yellowProjectileVelocity":
					yellowProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "yellowProjectileGlowSpeed":
					yellowProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "yellowProjectileDamage":
					yellowProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "yellowProjectileVariance":
					yellowProjectileVariance = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;

				case "greenProjectileVelocity":
					greenProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "greenProjectileGlowSpeed":
					greenProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "greenProjectileDamage":
					greenProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "greenProjectileVariance":
					greenProjectileVariance = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
					// --------------- // --------------- // --------------- // --------------- // --------------- Enemy Variables
				case "billEnemyHealth":
					billEnemyHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "billEnemySpeed":
					billEnemySpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "billEnemyFireCooldownTime":
					billEnemyFireCooldownTime = float.Parse (fileSplit [index + 1]);
					break;
				case "billEnemyWrapScreen":
					billEnemyWrapScreen = bool.Parse (fileSplit [index + 1]);
					break;
				case "billEnemyRammingDamage":
					billEnemyRammingDamage = float.Parse (fileSplit [index + 1]);
					break;

				case "keshaEnemySpeed":
					keshaEnemySpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "keshaEnemyHealth":
					keshaEnemyHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "keshaEnemyFireCooldownTime":
					keshaEnemyFireCooldownTime = float.Parse (fileSplit [index + 1]);
					break;
				case "keshaEnemyWrapScreen":
					keshaEnemyWrapScreen = bool.Parse (fileSplit [index + 1]);
					break;
				case "keshaEnemyRammingDamage":
					billEnemyRammingDamage = float.Parse (fileSplit [index + 1]);
					break;

				case "aeroflotEnemySpeed":
					aeroflotEnemySpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "aeroflotEnemyHealth":
					aeroflotEnemyHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "aeroflotEnemyFireCooldownTime":
					aeroflotEnemyFireCooldownTime = float.Parse (fileSplit [index + 1]);
					break;
				case "aeroflotEnemyWrapScreen":
					aeroflotEnemyWrapScreen = bool.Parse (fileSplit [index + 1]);
					break;
				case "aeroflotEnemyRammingDamage":
					billEnemyRammingDamage = float.Parse (fileSplit [index + 1]);
					break;
					// --------------- // --------------- // --------------- // --------------- // --------------- Error Catching
				default:
					Debug.Log (key + " didn't find this case in switch, <3 B Gamemanager.cs");
					break;
				}
			} else {
				Debug.Log ("Didn't find " + key + " in the file. Did a row of the spreadsheet get renamed?");
				//foreach (string st in fileSplit) { Debug.Log (st); }
			}
				
		}

		//this should be the last name of the file
		isLoaded = true;
	}
}
