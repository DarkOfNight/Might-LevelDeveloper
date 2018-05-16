using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour {

	public int attaque = 0;
	private bool block=true;
	public GameObject PatteGauche;
	public GameObject PatteDroite;

	void Start(){
		StartCoroutine (blocage ());
	}

	void Update () {
		if(Time.timeScale == 0)return;
		if (PatteGauche == null && PatteDroite == null) {
			gameObject.AddComponent<Pattern2> ();
			Destroy (gameObject.GetComponent<bestial>());
			Destroy (this);
		}
		
		if (attaque == 0 && block == false) {
			attaque = (int)Random.Range (1, 3);
			switch (attaque){
			case 1:
				if (PatteDroite)
					StartCoroutine (PatteDroite.GetComponent<coup_PapatteD>().CrochetDroit());
				else 
					StartCoroutine (PatteGauche.GetComponent<coup_PapatteG>().CrochetGauche());
				break;
			case 2:
				if (PatteGauche)
					StartCoroutine (PatteGauche.GetComponent<coup_PapatteG>().CrochetGauche());
				else 
					StartCoroutine (PatteDroite.GetComponent<coup_PapatteD>().CrochetDroit());
				break;
			}
			block = true;
		}
	}

	IEnumerator blocage(){
		while (true) {
			if (block == true && attaque == 0) {
				yield return new WaitForSeconds (5f);
				block = false;
			}
			yield return 0;
		}
	}
}