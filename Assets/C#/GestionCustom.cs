using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionCustom : MonoBehaviour {

	public GameObject camera, panel;

	/*
	 * 0 - type			0 normal 1 infini 2 boss
	 * 1 - image		0 ... 1 ... 2 ... ...
	 * 2 - mouvement	0 ... 1 ... 2 ... ...
	 * 3 - attaque		0 ... 1 ... 2 ... ...
	 * 4 - vie			> 0
	 * 5 - Nombre		> 0
	 * 
	 *  -1 = rien
	 */ 

	public Image[] infoVagueImage0 = new Image[7];
	public Image[] infoVagueImage1 = new Image[7];
	public Image[] infoVagueImage2 = new Image[7];
	public Image[] infoVagueImage3 = new Image[7];
	public Image[] infoVagueImage4 = new Image[7];
	public Image[] infoVagueImage5 = new Image[7];
	public Image[] infoVagueImage6 = new Image[7];

	public Image[] ImageListeImage;
	public Image[] ImageListeMouvement;
	public Image[] ImageListeAttaque;
	public Button[] listeImage;
	public Button[] listeMouvement;
	public Button[] listeAttaque;

	public Button ennemi, ennemi_I, boss;

	public InputField inputVie, inputNb;

	public int posImage, posMouvement, posAttaque;
	public int type;
	public int x = 0, y = 0;


	public int Anc_posImage, Anc_posMouvement, Anc_posAttaque;
	public int Anc_vie, Anc_nb, Anc_type;

	public int[,,] infoVague;

	public void InitCustom (){

		panel.SetActive (true);

		x = camera.GetComponent<GestionGrillage> ().x;
		y = camera.GetComponent<GestionGrillage> ().y;
		int[] var3 = camera.GetComponent<GestionGrillage> ().GetInfo (camera.GetComponent<GestionGrillage> ().vague, y, x);

		type = var3 [0];
		posImage = var3 [1];
		posMouvement = var3 [2];
		posAttaque = var3 [ 3];


		Anc_type = var3 [0];
		Anc_posImage = var3 [1];
		Anc_posMouvement = var3 [2];
		Anc_posAttaque = var3 [ 3];
		Anc_vie = var3 [4];
		Anc_nb = var3 [5];

		infoVague = camera.GetComponent<GestionGrillage> ().GetVague(camera.GetComponent<GestionGrillage> ().vague);


		CancelPanel ();
	}

	public void CancelPanel(){
		if (Anc_vie >= 0)
			inputVie.text = Anc_vie.ToString ();
		else
			inputVie.text = string.Empty;

		if (Anc_nb >= 0)
			inputNb.text = Anc_nb.ToString ();
		else
			inputNb.text = string.Empty;

		type = Anc_type;
		posImage = Anc_posImage;
		posMouvement = Anc_posMouvement;
		posAttaque = Anc_posAttaque;

		RefreshPanel ();
	}

	public void EmptyPanel(){
			inputVie.text = string.Empty;
			inputNb.text = string.Empty;

		type = -1;
		posImage = -1;
		posMouvement = -1;
		posAttaque = -1;

		SavePanel ();
	}

	void RefreshPanel(){
		ennemi.GetComponent<Image>().color = Color.white;
		ennemi_I.GetComponent<Image>().color = Color.white;
		boss.GetComponent<Image>().color = Color.white;
		switch (type) {
		case 0:
			ennemi.GetComponent<Image>().color = Color.yellow;
			break;
		case 1:
			ennemi_I.GetComponent<Image>().color = Color.yellow;
			break;
		case 2:
			boss.GetComponent<Image>().color = Color.yellow;
			break;
		}


		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 7; j++) {
				if (infoVague [i, j, 0] >= 0)
					switch (i) {
					case 0:
						infoVagueImage0 [j].color = Color.green;
						break;
					case 1:
						infoVagueImage1 [j].color = Color.green;
						break;
					case 2:
						infoVagueImage2 [j].color = Color.green;
						break;
					case 3:
						infoVagueImage3 [j].color = Color.green;
						break;
					case 4:
						infoVagueImage4 [j].color = Color.green;
						break;
					case 5:
						infoVagueImage5 [j].color = Color.green;
						break;
					case 6:
						infoVagueImage6 [j].color = Color.green;
						break;
				}
				else
					switch (i) {
				case 0:
					infoVagueImage0 [j].color = Color.white;
					break;
				case 1:
					infoVagueImage1 [j].color = Color.white;
					break;
				case 2:
					infoVagueImage2 [j].color = Color.white;
					break;
				case 3:
					infoVagueImage3 [j].color = Color.white;
					break;
				case 4:
					infoVagueImage4 [j].color = Color.white;
					break;
				case 5:
					infoVagueImage5 [j].color = Color.white;
					break;
				case 6:
					infoVagueImage6 [j].color = Color.white;
					break;
				}
			}

		switch (y) {
			case 0:
			infoVagueImage0 [x].color = Color.yellow;
			break;
			case 1:
			infoVagueImage1 [x].color = Color.yellow;
			break;
			case 2:
			infoVagueImage2 [x].color = Color.yellow;
			break;
			case 3:
			infoVagueImage3 [x].color = Color.yellow;
			break;
			case 4:
			infoVagueImage4 [x].color = Color.yellow;
			break;
			case 5:
			infoVagueImage5 [x].color = Color.yellow;
			break;
			case 6:
			infoVagueImage6 [x].color = Color.yellow;
			break;
		}

			

	}

	public void SavePanel(){
		if (inputVie.text == string.Empty || int.Parse(inputVie.text) < 0)
			Anc_vie = 1;
		else
			Anc_vie = int.Parse(inputVie.text);

		if (inputNb.text == string.Empty || int.Parse(inputNb.text) < 0)
			Anc_nb = 1;
		else
				Anc_nb = int.Parse(inputNb.text);

		Anc_type = type;
		Anc_posImage = posImage;
		Anc_posMouvement = posMouvement;
		Anc_posAttaque = posAttaque;

		int[] var1 = { Anc_type, Anc_type, Anc_posMouvement, Anc_posAttaque, Anc_vie, Anc_nb };
		camera.GetComponent<GestionGrillage> ().SetInfo (var1, camera.GetComponent<GestionGrillage>().vague, y, x);

		RefreshPanel ();
	}



	public void Exit(){
		panel.SetActive (false);
	}


	// Update is called once per frame
	public void SwitchType (int var1) {
		type = var1;
		RefreshPanel ();
	}
}
