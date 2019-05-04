using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour 
{

	public Transform player;
	public GameObject ball;
	private float distance;
	public bool create = true;

	float distanceY;

	
	void Update () 
	{
		if(player!=null)
		{
			distance = transform.position.x - player.position.x;
			distanceY = transform.position.y - player.position.y;
		}
		
		if(ball.tag != "negativeRoll")
		{

			if(distance > 2f && distance < 5f && create == true && distanceY>0)
			{
				Instantiate(ball, transform.position, Quaternion.identity);
				create = false;
			}
		}

		if(ball.tag == "negativeRoll")
		{
			if(distance < -0.1f && distance <-5f && create == true && distanceY>0)
			{
				Instantiate(ball, transform.position, Quaternion.identity);
				create = false;
			}
			
		}
	}
}
