using UnityEngine;
using System.Collections;

public class Tir_Allie : MonoBehaviour {

	public GameObject TirCentralMight, TirTrueMight ;

	public AudioClip SonMight;
	private AudioSource src;

	public int passifmight = 0;

	private float TirLatenceMight = 0.25f;

	void Awake () {

		src = GetComponent<AudioSource>();

	}

	public IEnumerator GestionTir() { // Defaut : Might
		while (true) {
			#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
			if (Input.GetKey ("space")) {
			#elif UNITY_ANDROID
			if (!gameObject.GetComponent<movement_base> ().isDashed){
			#endif
				if (passifmight > 0) {
					Instantiate (TirTrueMight, new Vector3 (gameObject.transform.position.x - .2f, gameObject.transform.position.y + .7f), new Quaternion (0, 0, 0, 0));
					Instantiate (TirTrueMight, new Vector3 (gameObject.transform.position.x + .2f, gameObject.transform.position.y + .7f), new Quaternion (0, 0, 0, 0));
					src.PlayOneShot (SonMight, 0.5f);
					passifmight -= 1;
					yield return new WaitForSeconds (TirLatenceMight);
				}
				else {
					Instantiate (TirCentralMight, new Vector3 (gameObject.transform.position.x - .2f, gameObject.transform.position.y + .7f), new Quaternion (0, 0, 0, 0));
					Instantiate (TirCentralMight, new Vector3 (gameObject.transform.position.x + .2f, gameObject.transform.position.y + .7f), new Quaternion (0, 0, 0, 0));
					src.PlayOneShot (SonMight, 0.3f);
					yield return new WaitForSeconds (TirLatenceMight);
				}
			}
			else
				yield return 0;

		}
	}

}
