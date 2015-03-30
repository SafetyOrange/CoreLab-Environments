using UnityEngine;
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
		"redProjectileVelocity",
		"redProjectileGlowSpeed",
		"redProjectileDamage",
		"redEnemyHealth",
		//"redProjectileShotByEnemy",
		"blueProjectileVelocity",
		"blueProjectileGlowSpeed",
		"blueProjectileDamage",
		"blueEnemyHealth",
		//"blueProjectileShotByEnemy"
		"yellowProjectileVelocity",
		"yellowProjectileGlowSpeed",
		"yellowProjectileDamage",
		"yellowEnemyHealth",
		"greenProjectileVelocity",
		"greenProjectileGlowSpeed",
		"greenProjectileDamage",
		"greenEnemyHealth"
	};
	public static Vector2 backgroundScrollSpeed;
	public static Vector2 shipSpeed;
	public static bool shipWrap;
	public static float shipHealth;
	public static float shipFireCooldown;
	public static float shipShotDamage;
	public static Vector2 shipShotVelocity;
	public static float shipShotGlowSpeed;
	public static Vector3 minScreenBounds;
	public static Vector3 maxScreenBounds;

	// --------------- // --------------- // --------------- Projectile Variables
	public static Vector2 redProjectileVelocity;
	public static float redProjectileGlowSpeed;
	public static float redProjectileDamage;
	public static bool redProjectileShotByEnemy; // this one isn't used

	public static Vector2 blueProjectileVelocity;
	public static float blueProjectileGlowSpeed;
	public static float blueProjectileDamage;
	public static bool blueProjectileShotByEnemy; // this one isn't used

	public static Vector2 yellowProjectileVelocity;
	public static float yellowProjectileGlowSpeed;
	public static float yellowProjectileDamage;
	public static bool yellowProjectileShotByEnemy; // this one isn't used

	public static Vector2 greenProjectileVelocity;
	public static float greenProjectileGlowSpeed;
	public static float greenProjectileDamage;
	public static bool greenProjectileShotByEnemy; // this one isn't used

	// --------------- // --------------- // --------------- Enemy Variables
	public static float redEnemyHealth;
	public static float blueEnemyHealth;
	public static float greenEnemyHealth;
	public static float yellowEnemyHealth;



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
				case "redProjectileShotByEnemy":
					redProjectileShotByEnemy = bool.Parse (fileSplit [index + 1]);
					break;
				case "redEnemyHealth":
					redEnemyHealth = float.Parse (fileSplit [index + 1]);
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
				case "blueProjectileShotByEnemy":
					blueProjectileShotByEnemy = bool.Parse (fileSplit [index + 1]);
					break;
				case "blueEnemyHealth":
					blueEnemyHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "yellowProjectileVelocity":
					blueProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "yellowProjectileGlowSpeed":
					blueProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "yellowProjectileDamage":
					blueProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "yellowProjectileShotByEnemy":
					blueProjectileShotByEnemy = bool.Parse (fileSplit [index + 1]);
					break;
				case "yellowEnemyHealth":
					blueEnemyHealth = float.Parse (fileSplit [index + 1]);
					break;
				case "greenProjectileVelocity":
					blueProjectileVelocity = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "greenProjectileGlowSpeed":
					blueProjectileGlowSpeed = float.Parse (fileSplit [index + 1]);
					break;
				case "greenProjectileDamage":
					blueProjectileDamage = float.Parse (fileSplit [index + 1]);
					break;
				case "greenProjectileShotByEnemy":
					blueProjectileShotByEnemy = bool.Parse (fileSplit [index + 1]);
					break;
				case "greenEnemyHealth":
					blueEnemyHealth = float.Parse (fileSplit [index + 1]);
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

			minScreenBounds = GameObject.Find("Controller").GetComponent<BoxCollider2D>().bounds.min;
			maxScreenBounds = GameObject.Find("Controller").GetComponent<BoxCollider2D>().bounds.max;

		}

		//this should be the last name of the file
		isLoaded = true;
	}

	public static void dub(GameObject target, string tag){

		if(tag == "red"){
			target.GetComponent<EnemyMovement>().health = redEnemyHealth;
			target.GetComponent<EnemyMovement>().proectileSpeed = redProjectileVelocity;
			target.GetComponent<EnemyMovement>().projectileGlowSpeed = redProjectileGlowSpeed;
			target.GetComponent<EnemyMovement>().projectileDamage = redProjectileDamage;
			target.GetComponent<EnemyMovement>().projectileShotByEnemy = redProjectileShotByEnemy;
		}
		else if (tag == "blue"){
			target.GetComponent<EnemyMovement>().health = blueEnemyHealth;
			target.GetComponent<EnemyMovement>().proectileSpeed = blueProjectileVelocity;
			target.GetComponent<EnemyMovement>().projectileGlowSpeed = blueProjectileGlowSpeed;
			target.GetComponent<EnemyMovement>().projectileDamage = blueProjectileDamage;
			target.GetComponent<EnemyMovement>().projectileShotByEnemy = blueProjectileShotByEnemy;
		}
		else if (tag == "yellow"){
			target.GetComponent<EnemyMovement>().health = yellowEnemyHealth;
			target.GetComponent<EnemyMovement>().proectileSpeed = yellowProjectileVelocity;
			target.GetComponent<EnemyMovement>().projectileGlowSpeed = yellowProjectileGlowSpeed;
			target.GetComponent<EnemyMovement>().projectileDamage = yellowProjectileDamage;
			target.GetComponent<EnemyMovement>().projectileShotByEnemy = yellowProjectileShotByEnemy;
		}
		else if (tag == "green"){
			target.GetComponent<EnemyMovement>().health = greenEnemyHealth;
			target.GetComponent<EnemyMovement>().proectileSpeed = greenProjectileVelocity;
			target.GetComponent<EnemyMovement>().projectileGlowSpeed = greenProjectileGlowSpeed;
			target.GetComponent<EnemyMovement>().projectileDamage = greenProjectileDamage;
			target.GetComponent<EnemyMovement>().projectileShotByEnemy = greenProjectileShotByEnemy;
		}
		else{
			Debug.Log("ERROR! MAKE SURE YOUR SHIP'S TAG(COLOR) IS A LOWER-CASE STRING");
			Debug.Log("ALSO DON'T CHANGE THE PUBLIC VARIABLE NAMES IN ENEMYMOVEMENT.CS");
		}
	}

}
