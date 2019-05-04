using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour 
{
	
	Player_motor pMove;

	void Start()
	{
		pMove = GameObject.FindObjectOfType<Player_motor>();
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")	
		{
			pMove.climbRope = true;
			//pMove.climb = 100f;
			pMove.climbRope = true;
		}
	}

	void OnCollisionExit(Collision other)
	{
		pMove.climbRope = false;
		//pMove.climb = 0f;
		pMove.climbRope = false;
	}

}
