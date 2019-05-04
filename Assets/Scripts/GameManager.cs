using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public Button playBtn;
	public Button pauseBtn;
	private bool pauseM = true;


	void Start () 
	{
		//playBtn = GameObject.Find("Play Button").GetComponent<Button>();
		pauseBtn = GameObject.Find("Pause Button").GetComponent<Button>();
	}

	public void Pause()
	{
		if (pauseM == true) 
		{
			Time.timeScale = 0f;
			pauseM = false;
		} 
		else if(pauseM==false)
		{
			Time.timeScale = 1f;
			pauseM = true;
		}
	}
}
