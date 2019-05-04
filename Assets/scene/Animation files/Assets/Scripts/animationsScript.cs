using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsScript : MonoBehaviour {

	private Animation anim;
	void Awake () {
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	public void PlayerRun () {
		anim.Play(TagsScript.Animation_Run);
	}
}
