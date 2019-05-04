using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBox : MonoBehaviour {

	Rigidbody box;

    public float dynFriction = 1f;
    public float  statFriction = 1f;
    public Collider coll;


    Player_motor pmotor;
    GameObject player;

    void Start() 
    {
    	player = GameObject.FindGameObjectWithTag("Player");
    	pmotor = GameObject.FindObjectOfType<Player_motor>();
    	box = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        coll.material.dynamicFriction = dynFriction;
        coll.material.staticFriction = statFriction;
    }


	void FixedUpdate() 
	{
		float distance = transform.position.x - player.transform.position.x;
		if(distance>-2f)
		{
			
			if(Input.GetKey(KeyCode.K))
			{
				print("follow");
				//pmotor.bondho = true;
				//pmotor.drag = true;
				gameObject.GetComponent<SpringJoint>().connectedBody = player.GetComponent<Rigidbody>();

			}
			if(Input.GetKeyUp(KeyCode.K))
			{
				//gameObject.GetComponent<FixedJoint>().connectedBody = null;
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			box.drag = 0f;
			//dynFriction = 0f;
			//statFriction = 0f;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			box.drag = 5f;
			//dynFriction = 100f;
			//statFriction = 100f;

		}
	}

}
