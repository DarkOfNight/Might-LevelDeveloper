using UnityEngine;
using System.Collections;

public class pv_papatte : MonoBehaviour {


	public int PV_papatte = 3;
	private int GD;

	void Start(){
		if (gameObject.name == "PatteDroite")
			GD = 1;
		else
			GD = 2;
	}

	void Update () {
		if(Time.timeScale == 0)return;
		if (PV_papatte == 0) {
			if (gameObject.GetComponentInParent<Pattern>().attaque==GD){
				gameObject.GetComponentInParent<Pattern>().attaque=0;
				StopCoroutine ("CrochetDroit");
			}
			if (gameObject.GetComponentInParent<Pattern>().attaque == GD) {
				gameObject.GetComponentInParent<Pattern>().attaque = 0;
				StopCoroutine ("CrochetGauche");
			}
			Destroy (gameObject);
		}
	}
}
