using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_motor : MonoBehaviour 
{

	// Bool for flip face
	private bool facingleft = false;

	public float xVel;

	// Player Movement speed
	public float moveSpeed; 

	// Player climb speed
	public float climb;

	// Player jump speed
	public float jumpPower;

	// Check if player is on ground
	public Transform groundCheckPosition;
	public float radius = 0.3f;

	// Layer Mask for ground
	public LayerMask layerGround;

	// Buttons for player control
	private Button jumpBtn;
	private Button moveLeftBtn;
	private Button moveRightBtn;

	// Rigidbody of player
	private Rigidbody player;

	//  Player movement animator
	private Animator anim;

	// Check if the player is grounded
	private bool isGrounded;

	// Movement speed
	public float floatSpeed;

	//Check if rope is true
	public bool climbRope = false;

	// Rope movement
	public float ropeJumpX = 0f;
	public float ropeJumpY = 0f;

	public bool fall= false;

	private Vector3 initial;

	Roll ball;

	// Boolean for move and stuffs
	private bool left = false;
	private bool right = false;

	void Start ()
	{
		initial = transform.position; 
		player = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		ball = GameObject.FindObjectOfType<Roll>();
		jumpBtn = GameObject.Find ("Jump Button").GetComponent<Button> ();

		jumpBtn.onClick.AddListener (() => Jump());


	}
	

	void Update () 
	{
		xVel = Mathf.Abs (player.velocity.x);
		anim.SetFloat ("Speed", xVel);
	}

	void FixedUpdate()
	{

		player.useGravity = true;
		PlayerGrounded ();
		if(climbRope)
		{
			player.useGravity = false;
		}

		if(right)
		{
			player.velocity = new Vector3(moveSpeed  * Time.deltaTime, player.velocity.y, 0f);
		}

		if(left)
		{
			player.velocity = new Vector3(-moveSpeed  * Time.deltaTime, player.velocity.y, 0f);
		}
	}

		
	public void moveRight()
	{
		anim.Play (Tags.Run_animation);
		if(!climbRope)
		{
			right = true;

			if(facingleft)
			{
				FlipFacing();
			}

		}

		if(climbRope)
		{
			player.velocity = new Vector3 (player.velocity.x, climb*Time.deltaTime, 0f);
		}
	}

	public void moveLeft()
	{
		anim.Play (Tags.Run_animation);
		
		if(!climbRope)
		{
			left = true;
			if(!facingleft)
			{
				FlipFacing();
			}
		}

		if(climbRope)
		{
			if(facingleft)
			{
				player.velocity = new Vector3 (player.velocity.x, -climb*Time.deltaTime, 0f);
			}
		}
	}

	public void idle()
	{
		player.velocity = new Vector3(0f,0f,0f);
		right = false;
		left = false;
	}

	void PlayerGrounded()
	{
		isGrounded = Physics.OverlapSphere (groundCheckPosition.position, radius, layerGround).Length > 0;
	}


	public void Jump()
	{
		//player.useGravity = true;
		if (isGrounded && !climbRope) 
		{
			
			anim.Play (Tags.Jump_animation);
		
			player.AddForce (new Vector3(0f, jumpPower, 0));

		}

		if(climbRope)
		{
			if(facingleft)
			{
				player.AddForce(ropeJumpX,ropeJumpY,0f);
			}

			if(!facingleft)
			{
				player.AddForce(-ropeJumpX,ropeJumpY,0f);
			}
		}

	}

	public void Landing()
	{
		anim.Play (Tags.Jumpland_animation);
	}


	void FlipFacing()
	{
		facingleft = !facingleft;
		Vector3 charScale = transform.localScale;
		charScale.z *= -1;
		transform.localScale = charScale;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "deathTag")
		{
			resetPosition();
			ball.create = true;
		}

		if(other.gameObject.tag == "floor")
		{
			anim.Play (Tags.Jumpland_animation);
		}

		if(other.gameObject.tag=="win")
		{
			SceneManager.LoadScene("WinScene");
		}
	}

	public void resetPosition()
	{
		transform.position = initial;
	}
}
