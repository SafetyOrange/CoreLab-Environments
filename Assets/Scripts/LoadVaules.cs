﻿using UnityEngine;
using System.Collections;

public class LoadVaules : MonoBehaviour {

	void Awake () {
		Transform lockInit;
		GameManager.init ();
		lockInit = this.transform;
	}

	void Update() {
		if (GameManager.restartRequired) {
			StartCoroutine ("restart");
			GameManager.restartRequired = false;
		}
	}

	IEnumerator restart() {
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Level1");
	}
}
