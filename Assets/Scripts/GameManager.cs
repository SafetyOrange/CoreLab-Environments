using UnityEngine;
using System.Collections;

public static class GameManager {

	public static Vector2 backgroundScrollSpeed;
	public static Vector2 shipSpeed;

	public static bool isLoaded = false;

	public static void init () {
		backgroundScrollSpeed = new Vector2 (0, .001f);
		shipSpeed = new Vector2 (0, 0);
		isLoaded = true;
	}

}
