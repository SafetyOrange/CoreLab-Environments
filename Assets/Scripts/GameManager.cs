using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameManager {

	// Variables for File Input
	public static bool isLoaded = false;

	//Game Variables
	private static string[] variableNames = {
//IMPORTANT You have to add in the name of the variable here in order for the program to find it.
//You also have to add it in the switch statement
		"backgroundScrollSpeed",
		"shipSpeed",
		"shipWrap",
		"shipHealth",
		"redProjectileVelocity",
		"redProjectileGlowSpeed",
		"redProjectileDamage",
		"redProjectileShotByEnemy",
		"blueProjectileVelocity",
		"blueProjectileGlowSpeed",
		"blueProjectileDamage",
		"blueProjectileShotByEnemy"
	};
	public static Vector2 backgroundScrollSpeed;
	public static Vector2 shipSpeed;
	public static bool shipWrap;
	public static float shipHealth;

	// --------------- // --------------- // --------------- Projectile Variables
	public static Vector2 redProjectileVelocity;
	public static float redProjectileGlowSpeed;
	public static float redProjectileDamage;
	public static bool redProjectileShotByEnemy;

	public static Vector2 blueProjectileVelocity;
	public static float blueProjectileGlowSpeed;
	public static float blueProjectileDamage;
	public static bool blueProjectileShotByEnemy;


	public static void init () {
		List<string> fileSplit = new List<string>();

		TextAsset file = Resources.Load("GameValues") as TextAsset;

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
				case "shipSpeed":
					shipSpeed = new Vector2 (float.Parse (fileSplit [index + 1]), float.Parse (fileSplit [index + 2]));
					break;
				case "shipWrap":
					shipWrap = bool.Parse (fileSplit [index + 1]);
					break;
				case "shipHealth":
					shipHealth = float.Parse (fileSplit [index + 1]);
					break;
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
