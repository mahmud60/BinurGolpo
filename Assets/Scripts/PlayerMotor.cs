using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour 
{

	// Bool for flip face
	private bool facingleft = false;

	public float xVel;

	// Player Movement speed
	public float moveSpeed; 

	// Player climb speed
	public float moveVertical;
	private float moveVer;

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

	private bool isGrounded;
	private bool playerJumped;
	public float floatSpeed;
	public bool onFloat = false;
	public bool climbRope = false;
	public bool bondho = false;


	private Vector3 initial;

	Roll ball;

	float moveHor;

	void Start ()
	{
		initial = transform.position;
		player = GetComponent<Rigidbody>();
		anim = gameObject.GetComponentInChildren<Animator>();
		ball = GameObject.FindObjectOfType<Roll>();





	}
	

	void Update () 
	{
		xVel = Mathf.Abs (player.velocity.x);
		anim.SetFloat ("Speed", xVel);
		moveHor = Input.GetAxis("Horizontal");
		PlayerJump ();
	}

	void FixedUpdate()
	{

		player.useGravity = true;
		PlayerGrounded ();

		if(climbRope)
		{
			player.useGravity = false;
			//climb();
		}

		if (onFloat) 
		{
			player.AddForce (0f,floatSpeed,0f);
		}

		if(isGrounded)
		{
			onFloat = false;
		}
		if (moveHor > 0) {
			moveRight ();
		} else if (moveHor < 0) {
			moveLeft ();
		}

		
	}

	void move()
	{
		player.velocity = new Vector3 (moveSpeed*moveHor*Time.deltaTime, player.velocity.y,  0f);
	}

	void climb()
	{
		player.velocity = new Vector3 (player.velocity.x, moveVer*moveVertical*Time.deltaTime, 0f);
		//player.AddForce(0f,moveVer*moveVertical*Time.deltaTime,0f);
	}

	public void moveRight()
	{
		player.velocity = new Vector3(moveSpeed  *moveHor* Time.deltaTime, player.velocity.y, 0f);
		if(facingleft)
		{
			FlipFacing();
		}
	}

	public void moveLeft()
	{
		
		if(!facingleft)
		{
			FlipFacing();
		}
		player.velocity = new Vector3 (moveSpeed *moveHor* Time.deltaTime, player.velocity.y, 0f);
	}

	public void idle()
	{
		player.velocity = new Vector3(0f,player.velocity.y,0f);
	}

	void PlayerGrounded()
	{
		isGrounded = Physics.OverlapSphere (groundCheckPosition.position, radius, layerGround).Length > 0;
		print (isGrounded);

	}


	void PlayerJump() {

		 if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			print ("Jump");
			anim.Play (Tags.Jump_animation);
			player.AddForce (new Vector3(0, jumpPower, 0));
		} 

	}

	void FlipFacing(){
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

		if(other.gameObject.tag == "float")
		{
			onFloat = true;
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
