using UnityEngine;
using System.Collections;

public class loadTirZone : MonoBehaviour {

	public GameObject Tir;

	void Start () {
		StartCoroutine (Loading ());	
	}
	
	private IEnumerator Loading(){
		yield return new WaitForSeconds (2f);
		Instantiate (Tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
		Destroy (gameObject);
	}
}
