using UnityEngine;
using System.Collections;

public class FPS_limit : MonoBehaviour {
	void Awake (){
		Application.targetFrameRate = 2;
	}
}
