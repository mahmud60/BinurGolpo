using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {

	[SerializeField]
	private bool moveX = false; 
	[SerializeField]
	private bool moveY= false;
	[SerializeField]
	private bool moveZ = false;
	[SerializeField]
	private float speed = 5f;

	public GameObject playerObj;
	//private Player_motor jump;

		
	void FixedUpdate () 
	{
		moveBox();
	}

	void moveBox()
	{

		if (moveX) 
		{
			Vector3 tempP = transform.position;
			tempP.x += speed * Time.deltaTime;
			transform.position = tempP;		
		}
		
		if (moveY) 
		{
			Vector3 tempP = transform.position;
			tempP.y += speed * Time.deltaTime;
			transform.position = tempP;
		}
		
		if (moveZ) 
		{
			Vector3 tempP = transform.position;
			tempP.z += speed * Time.deltaTime;
			transform.position = tempP;
		}
	}

	void OnTriggerEnter(Collider target)
	{
		if(target.tag == "floor")
		{

			speed *= -1;
		}
		if(target.tag == "Player"){
			playerObj.transform.parent = this.gameObject.transform;

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				//jump.jumpPlayer();
			}
		}

	}

	void OnTriggerExit(Collider target)
	{
		if (target.tag == "Player") {
			target.transform.parent = null;

		}
	}

}
