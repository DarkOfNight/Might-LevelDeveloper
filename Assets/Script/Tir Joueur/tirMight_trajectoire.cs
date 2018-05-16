using UnityEngine;
using System.Collections;

public class tirMight_trajectoire : MonoBehaviour {

	float accel = 20f;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ennemi_base" || col.gameObject.tag == "hitbox_boss") {
			Destroy (gameObject);
		}
	}
	void Update () {
		if(Time.timeScale == 0)return;

		gameObject.transform.Translate (new Vector3 (0,accel)*Time.deltaTime);
		accel = accel * 1.02f;
			
		}
}
