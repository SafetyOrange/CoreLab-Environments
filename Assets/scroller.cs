using UnityEngine;
using System.Collections;

public class scroller : MonoBehaviour {

	public float scrollspeed = .001f;
	private float yOffset = 0;

	private Renderer renderR;
	// Use this for initialization
	void Start () {
		renderR = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		renderR.material.SetTextureOffset ("_MainTex", new Vector2 (0, yOffset)); 
		yOffset += scrollspeed;
	}
}
