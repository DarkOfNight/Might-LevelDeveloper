using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dash_vaisseau : MonoBehaviour {

	public bool invu=false;

	public bool gauche = false, droite = false;
	public Button buttonGauche, buttonDroit;

	void Start(){

		GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		for (int i = 0; i < buttons.Length; i++) {
			if (buttons [i].name == "DashGauche")
				buttonGauche = buttons [i].GetComponent<Button>();
			if (buttons [i].name == "DashDroit")
				buttonDroit = buttons [i].GetComponent<Button>();
		}
		StartCoroutine ("Dash"+PlayerPrefs.GetString("Play.gameObjectID", "0"));
	}


	IEnumerator Dash0() { //Might
		while (true) {
			if ((Input.GetKey ("left ctrl") || gauche) && (gameObject.GetComponent<movement_base>().wall!=2)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x > -1.26f)
				{
					gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 1.5f, gameObject.transform.position.y);
					gameObject.transform.GetComponent<movement_base> ().wall = 0;
				}
				else
				{
					gameObject.transform.position = new Vector3(-2.76f, gameObject.transform.position.y);
					gameObject.transform.GetComponent<movement_base> ().wall = 2;
				}
				gameObject.transform.GetComponent<Tir_Allie>().passifmight = 5;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				gauche = false;
			}

			if ((Input.GetKey ("right ctrl") || droite) && (gameObject.GetComponent<movement_base>().wall!=1)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x < -1.24f)
				{
					gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 1.5f, gameObject.transform.position.y);
					gameObject.transform.GetComponent<movement_base> ().wall = 0;
				}
				else
				{
					gameObject.transform.position = new Vector3(2.74f, gameObject.transform.position.y);
					gameObject.transform.GetComponent<movement_base> ().wall = 1;
				}
				gameObject.transform.GetComponent<Tir_Allie>().passifmight = 5;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				droite = false;
			}
			yield return new WaitForSeconds (0.0001f);
		}
	}

}