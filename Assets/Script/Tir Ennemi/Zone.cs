using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour {

	private float grossissement = 1.3f; 
	void Start (){
		StartCoroutine (TimeToLive(4f));
	}

	private IEnumerator TimeToLive(float sec){
		yield return new WaitForSeconds (sec);
		Destroy (gameObject);
	}

	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.localScale += new Vector3 (grossissement, grossissement, 0);
		grossissement = 0.995f*grossissement;
	}
}
