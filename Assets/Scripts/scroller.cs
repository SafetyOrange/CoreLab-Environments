﻿using UnityEngine;
using System.Collections;

public class scroller : MonoBehaviour {

	public float scrollspeedY = .001f;
	public float scrollspeedX = 0;
	private float yOffset = 0;
	private float xOffset = 0;


	private Renderer renderR;
	// Use this for initialization
	void Start () {	
		renderR = GetComponent<MeshRenderer> ();
		StartCoroutine ("loadValues");
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
			yield return null;
		}
		scrollspeedX = GameManager.backgroundScrollSpeed.x;
		scrollspeedY = GameManager.backgroundScrollSpeed.y;

	}
	
	// Update is called once per frame
	void Update () {
		renderR.material.SetTextureOffset ("_MainTex", new Vector2 (xOffset, yOffset)); 
		yOffset += scrollspeedY;
		xOffset += scrollspeedX;
	}
}
