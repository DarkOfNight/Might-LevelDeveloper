using UnityEngine;
using System.Collections;

public class hero_touch : MonoBehaviour {


	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if((col.gameObject.tag == "Tir")&&(gameObject.GetComponent<dash_vaisseau>().invu==false)){
			Destroy (gameObject);
		}
	}
}