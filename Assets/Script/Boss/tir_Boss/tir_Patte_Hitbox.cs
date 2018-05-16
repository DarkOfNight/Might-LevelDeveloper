using UnityEngine;
using System.Collections;

public class tir_Patte_Hitbox : MonoBehaviour {

	public GameObject tir;
	public GameObject papa;

	void Start () {
		StartCoroutine (TesterStatus ());
	}

	IEnumerator TesterStatus(){
		while(true){
			yield return new WaitForSeconds ((float)Random.value*2f+2f);
			if ((gameObject.GetComponentInParent<Pattern>().attaque!=1) && papa.name=="PatteDroite" )
				Instantiate (tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
			if ((gameObject.GetComponentInParent<Pattern>().attaque!=2) && (papa.name=="PatteGauche"))
				Instantiate (tir, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y), new Quaternion (0, 0, 0, 0));
			
		}
	}
}
