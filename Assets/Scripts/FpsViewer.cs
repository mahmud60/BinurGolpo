using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsViewer : MonoBehaviour {
	public GUIText fps;
	float fpsval = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fpsval = 1 / Time.deltaTime;
		fps.text = "FPS : " + fpsval;
		
	}
}
