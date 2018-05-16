using UnityEngine;
using System.Collections;

public class tirEnnemi_base : MonoBehaviour {

	public GameObject tir;

	void Start () {
		StartCoroutine (TesterStatus ());
		StartCoroutine (fade ());
	}

	IEnumerator TesterStatus(){
		while(true){
			yield return new WaitForSeconds ((float)Random.value*4f+1f);
			Instantiate (tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
		}
	}
	private IEnumerator fade(){
		for (int i = 1; i < 11; i++) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, i / 10f);
			yield return new WaitForSeconds (0.055f);
		}
	}
}