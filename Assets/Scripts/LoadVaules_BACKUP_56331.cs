using UnityEngine;
using System.Collections;

public class LoadVaules : MonoBehaviour {
<<<<<<< HEAD
	void Awake () {
=======

	Transform lockInit;

	void Start () {
>>>>>>> 972b42e6af2ed45c5c21fd90b1f4d603b4a93eee
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
