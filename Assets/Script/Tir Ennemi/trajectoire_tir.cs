using UnityEngine;
using System.Collections;

public class trajectoire_tir : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate(new Vector3 (0, -70f)*Time.deltaTime);
	}
}
