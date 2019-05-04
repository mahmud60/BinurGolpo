using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayermOve : MonoBehaviour {

	public float movementSpeed = 5f;
	public float jumpPower = 10f;
	public Transform groundCheckPosition;
	public float radius = 0.3f;
	public LayerMask layerGround;

	private Rigidbody myBody;
	private bool isGrounded;
	private Button jumpbtn;
	//private bool playerJumped = false;

	private animationsScript playerAnim;

	void Awake () {
		myBody = GetComponent<Rigidbody> ();
		playerAnim = GetComponent<animationsScript> ();
		jumpbtn = GameObject.Find (Tags.JUMP_BUTTON_OBJ).GetComponent<Button> ();
		jumpbtn.onClick.AddListener ( () => Jump());
	}
	void Start()
	{
		playerAnim.PlayerRun ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerMove ();
		PlayerGrounded ();
		PlayerJump ();
	}

	void playerMove()
	{

		myBody.velocity = new Vector3 (movementSpeed , myBody.velocity.y ,0f);
	}

	void PlayerGrounded() {
		isGrounded = Physics.OverlapSphere (groundCheckPosition.position, radius, layerGround).Length > 0;
	}

	void PlayerJump() {

		if (Input.GetKeyUp (KeyCode.Space) && isGrounded) {
			
			myBody.AddForce (new Vector3(0, jumpPower, 0));
			//playerJumped = true;

		} 

	}

	public void Jump()
	{
		print ("baire");
		if (isGrounded) {

			myBody.AddForce (new Vector3(0, jumpPower, 0));
			print ("loop");


		} 

	}
}//class
