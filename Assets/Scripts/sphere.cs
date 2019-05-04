using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sphere : MonoBehaviour 
{
	public float radius = 0.3f;
	public LayerMask layerGround;
	public Transform groundCheckPosition;

	private bool isGrounded;
	Rigidbody sphereBall;

	private float time;

	public float moveForce;

	Player_motor player;
	Roll ball;

	void Start()
	{
		player = GameObject.FindObjectOfType<Player_motor>();
		ball = GameObject.FindObjectOfType<Roll>();
		sphereBall = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
		PlayerGrounded ();
		moveBall();

		time += Time.deltaTime;

		if(time>8f)
		{
			Destroy(gameObject);
		}

	}

	void moveBall()
	{	
		if(isGrounded)
		{
			sphereBall.AddForce(moveForce,0f,0f);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			//ball.create = true;
			// Load game over scene
			//StartCoroutine(gameOver());
			SceneManager.LoadScene("GameOver");
		}
	}
	void PlayerGrounded()
	{
		isGrounded = Physics.OverlapSphere (groundCheckPosition.position, radius, layerGround).Length > 0;
	}

	IEnumerator gameOver()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(2);
	}
}
