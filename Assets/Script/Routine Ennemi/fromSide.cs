using UnityEngine;
using System.Collections;

public class fromSideSnaking : MonoBehaviour {

	private float vitesse = 50f;
	public float rotatation = 4f;
	public float marge_1 = 30f;
	public float marge_2 = -30f;
	public float ttl = 3f;

	private bool sortie = false;

	// Use this for initialization
	void Start () {
		gameObject.transform.Rotate (new Vector3 (0, 0, 90f));
	}

	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate (new Vector3 (0, -vitesse) * Time.deltaTime);
		if (gameObject.transform.position.x >= marge_1 && gameObject.transform.rotation.z >= -90 && sortie == false)
			gameObject.transform.Rotate (new Vector3 (0, 0, -rotatation));
		if (gameObject.transform.position.x <= marge_2 && gameObject.transform.rotation.z <= 90 && gameObject.transform.position.y != 80){
			gameObject.transform.Rotate (new Vector3 (0, 0, rotatation));

			//ttl
			sortie = true;
			StartCoroutine (TimeToLive(ttl));
		}
	}



	private IEnumerator TimeToLive(float sec){
		yield return new WaitForSeconds (sec);
		Destroy (gameObject);
	}
}
