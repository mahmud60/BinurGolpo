using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(){
		
		SceneManager.LoadScene("New_Level_NewBinu");
	}

	public void QuitRequest(){
		Application.Quit ();
	}

}
