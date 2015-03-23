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
		"shipWrap"
	};
	public static Vector2 backgroundScrollSpeed;
	public static Vector2 shipSpeed;
	public static bool shipWrap;


	public static void init () {
		List<string> fileSplit = new List<string>();

		TextAsset file = Resources.Load("GameValues") as TextAsset;

		string[] s = file.text.Split (',');

		foreach (string temp in s) { // Add in the 
			if (temp.IndexOf ('\n') > 0) {
				string[] sSplit = temp.Split ('\n');
				if (sSplit [0] != "") { //don't add the blank line if there is one
					fileSplit.Add (sSplit [0]);
				}
				if (sSplit [1] != "") { //don't add t	he blank line if there is one
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
			switch (key) {
				case "backgroundScrollSpeed":
					backgroundScrollSpeed = new Vector2 ( float.Parse(fileSplit [index + 1]), float.Parse(fileSplit [index + 2]) );
					break;
				case "shipSpeed":
					shipSpeed = new Vector2 ( float.Parse(fileSplit [index + 1]), float.Parse(fileSplit [index + 2]) );
					break;
				case "shipWrap":
					shipWrap = bool.Parse( fileSplit[index + 1] );
					break;
				default:
					Debug.Log (key + " didn't find this case in switch, <3 B Gamemanager.cs");
					break;
			}
		}

		//this should be the last name of the file
		isLoaded = true;
	}
}
