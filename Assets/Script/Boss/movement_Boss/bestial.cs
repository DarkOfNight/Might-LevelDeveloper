using UnityEngine;
using System.Collections;

public class bestial : MonoBehaviour {

	public Vector3 PlacePapatte=new Vector3 (0,0,0);
	public Vector3 RotatePapatte=new Vector3 (0,0,0);
	public GameObject PatteGauche;
	public GameObject PatteDroite;

	// Use this for initialization
	void Start () {
		StartCoroutine (PatteQuiBouge ());
		StartCoroutine (BossQuiBouge ());
	}

	IEnumerator PatteQuiBouge(){
		int compteur=0;
		while(true){
			if (compteur < 190) {
				PlacePapatte +=new Vector3 (0.04f,0,0);
				RotatePapatte += new Vector3 (0, 0, 0.1f);
				if (gameObject.GetComponent<Pattern> ().attaque != 1 && PatteDroite) {
					PatteDroite.transform.Translate (new Vector3 (0.04f, 0));
					PatteDroite.transform.Rotate(new Vector3 (0,0,0.1f));
				}
				if (gameObject.GetComponent<Pattern> ().attaque != 2 && PatteGauche) {
					PatteGauche.transform.Translate (new Vector3 (-0.04f, 0));
					PatteGauche.transform.Rotate (new Vector3 (0, 0, -0.1f));
				}
				compteur += 1;
			} 
			else {
				PlacePapatte -=new Vector3 (0.04f,0,0);
				RotatePapatte -= new Vector3 (0, 0, 0.1f);
				if (gameObject.GetComponent<Pattern> ().attaque != 1 && PatteDroite) {
					PatteDroite.transform.Translate (new Vector3 (-0.04f, 0));
					PatteDroite.transform.Rotate(new Vector3 (0,0,-0.1f));
				}
				if (gameObject.GetComponent<Pattern> ().attaque != 2 && PatteGauche ){
					PatteGauche.transform.Translate (new Vector3 (0.04f, 0));
					PatteGauche.transform.Rotate (new Vector3 (0, 0, 0.1f));
				}			
				compteur += 1;
				if (compteur == 379)
					compteur = 0;
			}
			yield return new WaitForSeconds(0.01666f);

		}
	}

	IEnumerator BossQuiBouge(){
		int compteur = 0, etat=0;
		bool debut = true;
		float arc = -0.6f;
		const float VitX=0.6f, VitY=0.3f;

		while (true) {
			switch (etat){
			case 0 :
				gameObject.transform.Translate(new Vector3 (-VitX,-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position = (new Vector3 (PatteDroite.transform.position.x+VitX,PatteDroite.transform.position.y+VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position = (new Vector3 (PatteGauche.transform.position.x+VitX,PatteGauche.transform.position.y+VitY));
				compteur+=1;
				if (((compteur==40)&&(debut==false)) || ((compteur==20)&&(debut==true))){
					compteur=0;
					etat=1;
				}
				break;
			case 1 :
				gameObject.transform.Translate(new Vector3 (-VitX*(1-arc),+VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position = (new Vector3 (PatteDroite.transform.position.x+VitX*(1-arc),PatteDroite.transform.position.y-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position = (new Vector3 (PatteGauche.transform.position.x+VitX*(1-arc),PatteGauche.transform.position.y-VitY));
				compteur+=1;
				arc += 0.06f;
				if (compteur == 20){
					compteur=0;
					etat = 2;
					arc = -0.6f;
				}
				break;
			case 2:
				gameObject.transform.Translate (new Vector3 (+VitX*(1+arc), +VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position =(new Vector3 (PatteDroite.transform.position.x-VitX*(1+arc),PatteDroite.transform.position.y-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position =(new Vector3 (PatteGauche.transform.position.x-VitX*(1+arc),PatteGauche.transform.position.y-VitY));
				compteur += 1;
				arc += 0.06f;
				if (compteur == 20){
					compteur=0;
					etat=3;
					arc = -0.6f;
				}
				break;
			case 3 :
				gameObject.transform.Translate(new Vector3 (+VitX,-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position = (new Vector3 (PatteDroite.transform.position.x-VitX,PatteDroite.transform.position.y+VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position = (new Vector3 (PatteGauche.transform.position.x-VitX,PatteGauche.transform.position.y+VitY));
				compteur+=1;
				if (compteur == 40){
					compteur=0;
					etat=4;
				}
				break;
			case 4 :
				gameObject.transform.Translate(new Vector3 (+VitX*(1-arc),+VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position = (new Vector3 (PatteDroite.transform.position.x-VitX*(1-arc),PatteDroite.transform.position.y-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position = (new Vector3 (PatteGauche.transform.position.x-VitX*(1-arc),PatteGauche.transform.position.y-VitY));
				compteur+=1;
				arc += 0.06f;
				if (compteur == 20){
					compteur=0;
					etat=5;
					arc = -0.6f;
				}
				break;
			case 5 :
				gameObject.transform.Translate(new Vector3 (-VitX*(1+arc),+VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==1 && PatteDroite==true) 
					PatteDroite.transform.position= (new Vector3 (PatteDroite.transform.position.x+VitX*(1+arc),PatteDroite.transform.position.y-VitY));
				if (gameObject.GetComponent<Pattern> ().attaque==2 && PatteGauche==true) 
					PatteGauche.transform.position= (new Vector3 (PatteGauche.transform.position.x+VitX*(1+arc),PatteGauche.transform.position.y-VitY));
				compteur+=1;
				arc += 0.06f;
				if (compteur == 20){
					compteur=0;
					etat=0;
					arc = -0.6f;
				}
				if (debut == true)
					debut = false;
				break;
			}
			yield return new WaitForSeconds (0.016666f);
		}
	}
}