using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBinu : MonoBehaviour {


	public float moveSpeed = 5f;

	public Button playBtn;
	public Button pauseBtn;
	private Rigidbody player;
	private bool pauseM = true;


	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
		//playBtn = GameObject.Find("Play Button").GetComponent<Button>();
		pauseBtn = GameObject.Find("Pause Button").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MoveLeft()
	{
		player.velocity = new Vector3 (-moveSpeed * Time.deltaTime, player.velocity.y, 0f);

	}
	public void MoveRight()
	{
		player.velocity = new Vector3 (moveSpeed * Time.deltaTime, player.velocity.y, 0f);

	}
	public void Idle()
	{
		player.velocity = new Vector3 (0f , 0f , 0f);

	}

	public void Pause()
	{
		if (pauseM == true) {
			Time.timeScale = 0f;
			pauseM = false;

		} else if(pauseM==false){
			Time.timeScale = 1f;
			pauseM = true;
		}

	}


}
