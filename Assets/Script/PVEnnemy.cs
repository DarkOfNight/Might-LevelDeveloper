using UnityEngine;
using System.Collections;

public class PVEnnemy : MonoBehaviour {

	public int PV;
	public int x = 0, y = 0;

	void OnTriggerEnter2D(Collider2D col){
		/*switch (col.gameObject.tag) {
		case "TirJoueur1PV":*/
		if (col.gameObject.tag.StartsWith ("TirJoueur") && col.gameObject.tag.EndsWith ("PV") && col.gameObject.tag.Substring (9).Remove (col.gameObject.tag.Substring (9).Length - 2) != "") {
			PV -= int.Parse (col.gameObject.tag.Substring (9).Remove (col.gameObject.tag.Substring (9).Length - 2));
			Destroy (col.gameObject);
		}
	}

	void Update(){
		if(Time.timeScale == 0)return;
		if (PV <= 0) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<GestionNiveau> ().EnnemyDestroyed (y, x);
			Destroy (gameObject);
		}
	
	}
}
