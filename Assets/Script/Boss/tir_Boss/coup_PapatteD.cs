using UnityEngine;
using System.Collections;

public class coup_PapatteD : MonoBehaviour {


	public GameObject Corp;

	// Use this for initialization



	public IEnumerator CrochetDroit() {
		int etat = 0;
		int compteur = 0;
		while (Corp.GetComponent<Pattern>().attaque==1 ) {
			switch (etat) {
			case 0:
					gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
					gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (0, 0, 0), 2f);
					compteur += 1;

					if (compteur == 30) {
						compteur = 0;
						etat = 1;
					}
					break;
			case 1:
					gameObject.transform.Rotate (new Vector3 (0, 0, 1.5f));
					gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.3f, 0);
					compteur += 1;

					if (compteur == 84) {
						compteur = 0;
						etat = 2;
					}
					break;
			case 2:
					gameObject.transform.Rotate (new Vector3 (0, 0, -9f));
					gameObject.transform.Translate (new Vector3 (-3.6f, 0, 0));
					compteur += 1;

					if (compteur == 30) {
						compteur = 0;
						etat = 3;
					}
					break;			
			case 3:
					gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
					gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (Corp.transform.position.x + 17f, Corp.transform.position.y, 0), 20f);
					compteur += 1;

				if (compteur == 5 ) {
						gameObject.transform.Rotate (gameObject.GetComponentInParent<bestial> ().RotatePapatte);
						gameObject.transform.Translate (gameObject.GetComponentInParent<bestial> ().PlacePapatte);
						gameObject.GetComponentInParent<Pattern> ().attaque = 0;
					}
					break;
				}
			yield return new WaitForSeconds(0.01666f);
		}
	}
}