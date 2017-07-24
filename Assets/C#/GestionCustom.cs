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
	public GameObject[] listeImage;
	public GameObject[] listeMouvement;
	public GameObject[] listeAttaque;

	public Button ennemi, ennemi_I, boss;

	public InputField inputVie, inputNb;

	int posImage = -1, posMouvement = -1, posAttaque = -1;
	int posListeImage = 1, posListeMouvement = 1, posListeAttaque = 1;
	int type = -1;
	public int x = 0, y = 0;

	public Sprite[] spriteBoss, spriteEnnemi, spriteMouvement, spriteAttaque;
	int nbPageEnnemi, nbPageMouvement, nbPageAttaque;


	int Anc_posImage = -1, Anc_posMouvement = -1, Anc_posAttaque = -1;
	int Anc_vie = -1, Anc_nb = -1, Anc_type = -1;

	public int[,,] infoVague;

	public void RefreshListe(){
		for (int i = 0; i < 5; i++) {
			try {
				listeImage[i].SetActive(true);
			if (type == 2)
				ImageListeImage [i].sprite = spriteBoss [((posListeImage - 1) * 5) + i];
			else
				ImageListeImage [i].sprite = spriteEnnemi [((posListeImage - 1) * 5) + i];
			if( (((posListeImage - 1) * 5) + i) == posImage)
					listeImage[i].GetComponent<Button>().GetComponent<Image>().color  = Color.yellow;
			else
					listeImage[i].GetComponent<Button>().GetComponent<Image>().color  = Color.white;
			}
			catch{
				listeImage [i].SetActive (false);
			}

			if (type == 2){
				listeMouvement [i].SetActive (false);
				listeAttaque [i].SetActive (false);
				}
			else{
			try {
				listeMouvement[i].SetActive(true);
				ImageListeMouvement [i].sprite = spriteMouvement [((posListeMouvement - 1) * 5) + i];
				if( (((posListeMouvement - 1) * 5) + i) == posMouvement)
					listeMouvement[i].GetComponent<Button>().GetComponent<Image>().color  = Color.yellow;
				else
					listeMouvement[i].GetComponent<Button>().GetComponent<Image>().color  = Color.white;
			}
			catch{
					listeMouvement [i].SetActive (false);
			}

			try {
				listeAttaque[i].SetActive(true);
				ImageListeAttaque [i].sprite = spriteAttaque [((posListeAttaque - 1) * 5) + i];
				if( (((posListeAttaque - 1) * 5) + i) == posAttaque)
					listeAttaque[i].GetComponent<Button>().GetComponent<Image>().color  = Color.yellow;
				else
					listeAttaque[i].GetComponent<Button>().GetComponent<Image>().color = Color.white;
			}
			catch{
						listeAttaque [i].SetActive (false);
				}
			}
		}
	}



	public void ChangeListeEnnemi(bool suivant){
		if (suivant)
			posListeImage++;
		else
			posListeImage--;
		if (posListeImage > nbPageEnnemi)
			posListeImage = 1;
		if (posListeImage < 1)
			posListeImage = nbPageEnnemi;
		RefreshListe ();
	}

	public void ChangeListeAttaque(bool suivant){
		if (suivant)
			posListeAttaque++;
		else
			posListeAttaque--;
		if (posListeAttaque > nbPageAttaque)
			posListeAttaque = 1;
		if (posListeAttaque < 1)
			posListeAttaque = nbPageAttaque;
		RefreshListe ();
	}

	public void ChangeListeMouvement(bool suivant){
		if (suivant)
			posListeMouvement++;
		else
			posListeMouvement--;
		if (posListeMouvement > nbPageMouvement)
			posListeMouvement = 1;
		if (posListeMouvement < 1)
			posListeMouvement = nbPageMouvement;
		RefreshListe ();
	}
		

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
		Anc_vie = -1;
		Anc_nb = -1;

		posListeImage = 1;
		posListeMouvement = 1;
		posListeAttaque = 1;

		Anc_type = type;
		Anc_posImage = posImage;
		Anc_posMouvement = posMouvement;
		Anc_posAttaque = posAttaque;

		int[] var1 = new int[10];
		for (int i = 0; i < 10; i ++)
			var1[i] = -1;

		var1 [0] = Anc_type;
		var1 [1] = Anc_posImage;
		var1 [2] = Anc_posMouvement;
		var1 [3] = Anc_posAttaque;
		var1 [4] = Anc_vie;
		var1 [5] = Anc_nb;
		camera.GetComponent<GestionGrillage> ().SetInfo (var1, camera.GetComponent<GestionGrillage>().vague, y, x);

		RefreshPanel ();
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

		GetPage ();
		RefreshListe ();

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

		inputVie.text = Anc_vie.ToString ();
		inputNb.text = Anc_nb.ToString ();


		Anc_type = type;
		Anc_posImage = posImage;
		Anc_posMouvement = posMouvement;
		Anc_posAttaque = posAttaque;


		int[] var1 = { type, posImage, posMouvement, posAttaque, Anc_vie, Anc_nb };
		camera.GetComponent<GestionGrillage> ().SetInfo (var1, camera.GetComponent<GestionGrillage>().vague, y, x);
		RefreshPanel ();
		RefreshListe ();
	}



	public void Exit(){
		panel.SetActive (false);
	}


	// Update is called once per frame
	public void SwitchType (int var1) {
		type = var1;
		nbPageEnnemi = 0;

		GetPage ();
		RefreshListe ();
		RefreshPanel ();
	}

	public void SwitchEnnemi (int var1) {
		posImage = ((posListeImage - 1) * 5) + var1;
		RefreshPanel ();
	}

	public void SwitchAttaque (int var1) {
		posAttaque = ((posListeAttaque - 1) * 5) + var1;
		RefreshPanel ();
	}

	public void SwitchMouvement (int var1) {
		posMouvement = ((posListeMouvement - 1) * 5) + var1;
		RefreshPanel ();
	}


	public void GetPage(){
		int nbTotal = 0;

		if (type == 2)
			nbTotal = spriteBoss.Length;
		else
			nbTotal = spriteEnnemi.Length;
		if (((nbTotal % 5) == 0) && ((nbTotal >= 5)))
			nbPageEnnemi = (nbTotal / 5);
		else
			nbPageEnnemi = (nbTotal / 5) + 1;

		nbTotal = spriteMouvement.Length;
		if (((nbTotal % 5) == 0) && ((nbTotal >= 5)))
			nbPageMouvement = (nbTotal / 5);
		else
			nbPageMouvement = (nbTotal / 5) + 1;

		nbTotal = spriteAttaque.Length;
		if (((nbTotal % 5) == 0) && ((nbTotal >= 5)))
			nbPageAttaque = (nbTotal / 5);
		else
			nbPageAttaque = (nbTotal / 5) + 1;
	}

}
