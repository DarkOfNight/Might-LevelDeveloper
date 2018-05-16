using UnityEngine;
using System.Collections;

public class tirEnnemi_Zone : MonoBehaviour {

	public GameObject Tir;

	void Start () {
		StartCoroutine (newZone ());
		StartCoroutine (fade ());

	}
	
	private IEnumerator newZone ()
	{ 
		int i;
		yield return new WaitForSeconds (2f);
		Instantiate (Tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0), gameObject.transform);

		for (i=0; i<80; i++)
		{
			gameObject.transform.Rotate (new Vector3 (0, 0, 9f));
			yield return new WaitForSeconds (0.025f);
		}
		while (true) {
			yield return new WaitForSeconds (6f);
			Instantiate (Tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0), gameObject.transform);
			for (i=0; i<80; i++)
			{
				gameObject.transform.Rotate (new Vector3 (0, 0, 9f));
				yield return new WaitForSeconds (0.025f);
			}
		}
	}
	private IEnumerator fade(){
		for (int i = 1; i < 11; i++) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, i / 10f);
			yield return new WaitForSeconds (0.055f);
		}
	}
}