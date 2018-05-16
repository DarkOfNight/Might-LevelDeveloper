using UnityEngine;
using System.Collections;

public class detecteur_mouvement : MonoBehaviour {

	GameObject vaisseau;

	// Use this for initialization
	void Start () {
		vaisseau = GameObject.FindGameObjectWithTag ("Player");
	}



	public void DashButton(bool i){
		if (i) {
			vaisseau.GetComponent<dash_vaisseau>().gauche = false;
			vaisseau.GetComponent<dash_vaisseau>().droite = true;
		} else {
			vaisseau.GetComponent<dash_vaisseau>().gauche = true;
			vaisseau.GetComponent<dash_vaisseau>().droite = false;
		}
	}
}
