using UnityEngine;
using System.Collections;

public class Pattern2 : MonoBehaviour {

	void Start(){
		StartCoroutine (renversement ());
	}

	void Update () {
	
	}

	public IEnumerator renversement(){
		yield return new WaitForSeconds (2f);
		for(int i=0;i<150; i++){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (0, 65f), 0.1f);
			gameObject.transform.Rotate(new Vector3 (0, 0, 0.6f));
			yield return new WaitForSeconds (0.01666f);
		}
	}
}