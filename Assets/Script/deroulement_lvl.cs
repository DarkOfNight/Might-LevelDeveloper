using UnityEngine;
using System.Collections;

public class deroulement_lvl : MonoBehaviour {
	public GameObject EnnemiBase, EnnemiZone, Boss;

	// Use this for initialization
	void Start () {
		StartCoroutine (Deroulement());
	}

	IEnumerator Deroulement() {
		Debug.Log ("Début Vague 1");

		var x = (GameObject)Instantiate (EnnemiBase, new Vector3 (-38, 100), new Quaternion (0, 0, 0, 0));
		x.AddComponent<FormeU>();
		yield return new WaitForSeconds(0.5f);
		x.GetComponent<FormeU> ().rotatation = 4.0f;
		x.GetComponent<FormeU> ().nb_rotatation = 45;

		x = (GameObject)Instantiate (EnnemiBase, new Vector3 (38, 100), new Quaternion (0, 0, 0, 0));
		x.AddComponent<FormeU>();
		x.GetComponent<FormeU> ().rotatation = -2.0f;
		yield return new WaitForSeconds(0.5f);
		x= (GameObject) Instantiate (EnnemiBase, new Vector3 (-55, 80), new Quaternion (0, 0, 0, 0));
		x.AddComponent<fromSideSnaking>();
		yield return new WaitForSeconds(0.5f);
		x= (GameObject)Instantiate (EnnemiBase, new Vector3 (-50, 100), new Quaternion (0, 0, 0, 0));
		x.transform.Rotate(new Vector3 (0,0,15));
		x.AddComponent<FormeU> ();
		x.GetComponent<FormeU> ().rotatation = 2f;
		x.GetComponent<FormeU> ().nb_rotatation = 60;
		yield return new WaitForSeconds(2f);
		
		Instantiate (EnnemiBase, new Vector3 (-0, 52), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiBase, new Vector3 (12, 70), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiBase, new Vector3 (-17, 27), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiZone, new Vector3 (42, -20), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiBase, new Vector3 (-38, 43), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiBase, new Vector3 (20, 37), new Quaternion (0, 0, 0, 0));
		yield return new WaitForSeconds(0.5f);
		Instantiate (EnnemiBase, new Vector3 (30, 60), new Quaternion (0, 0, 0, 0));


		Debug.Log ("Ennemis Vague 1 Instanciés");

		bool ennemiDetected = true;
		while (ennemiDetected) {
			ennemiDetected = false;
			GameObject[] ennemis = GameObject.FindGameObjectsWithTag ("Ennemi_base");
			for (int i = 0; i < ennemis.Length; i++){
				if (ennemis [i] != null)
					ennemiDetected = true;
			}
			yield return new WaitForSeconds (0.3f);
		}
		Debug.Log ("Fin Vague 1");

		Debug.Log ("Début Boss");
		Instantiate (Boss, new Vector3 (0, 70), new Quaternion (0, 0, 0, 0));




	}
}
