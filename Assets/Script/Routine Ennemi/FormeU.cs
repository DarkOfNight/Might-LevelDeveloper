using UnityEngine;
using System.Collections;

public class FormeU : MonoBehaviour {

	public float vitesse = 50f;
	public float rotatation = 2f;
	public int nb_rotatation = 90;
	public float seuil = 40f;
	public int hauteur = 200;

	public float ttl = 3f;

	private int choix = 0;
	private int nb=0;

	void Update(){
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate (new Vector3 (0, -vitesse) * Time.deltaTime);
		switch (choix){
		case 0:
			if (gameObject.transform.position.y <= (seuil/100*hauteur-hauteur/2))
				choix=1;
			break;
		case 1:
			if (nb < nb_rotatation){
				gameObject.transform.Rotate(new Vector3(0,0,rotatation)); 
				nb+=1;
			}
			else 
			{
				choix=2;
				// TTL
				StartCoroutine (TimeToLive(ttl));
			}
				
			break;
		case 2: 
			break;
		}
	}



	private IEnumerator TimeToLive(float sec){
		yield return new WaitForSeconds (sec);
		Destroy (gameObject);
	}
}
