using UnityEngine;
using System.Collections;



public class destroyOffscreen : MonoBehaviour {

	private Renderer rend;

	void Start() {
		rend = gameObject.GetComponent<Renderer> ();
	}
	// Update is called once per frame

	void Update() {
		if(Time.timeScale == 0)return;
		if (rend.isVisible == false)
				Destroy(gameObject);
	}
}
