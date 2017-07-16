using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	public void ToMain(){
		SceneManager.LoadScene (0);
	}

	public void ToQuit(){
		Application.Quit();
	}

	public void ToLevel(){
		SceneManager.LoadScene (1);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (SceneManager.GetSceneAt (0).path == "Assets/Scene/Main.unity")
				ToQuit ();
			else
				ToMain ();
		}
	}

}
