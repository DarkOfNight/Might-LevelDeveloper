using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GestionGrillage : MonoBehaviour {

	public int[,,,] cadrillage = new int[255,7,7,6];
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

	public int level = 0, chapitre = 0, vague = 0;
	public Text level_T, chapitre_T, vague_T;

	public Image[] CadreImage0 = new Image[7];
	public Image[] CadreImage1 = new Image[7];
	public Image[] CadreImage2 = new Image[7];
	public Image[] CadreImage3 = new Image[7];
	public Image[] CadreImage4 = new Image[7];
	public Image[] CadreImage5 = new Image[7];
	public Image[] CadreImage6 = new Image[7];

	public Sprite[] ennemi, boss;


	// Use this for initialization
	void Start () {
		ResetCadre (true);
	}

	public void ChangeLevel(bool suivant){
		if (suivant)
			level++;
		else
			level--;
		if (level < 0)
			level = 254;
		if (level > 254)
			level = 0;

		level_T.text = (level + 1).ToString ();
	}
	public void ChangeChapitre(bool suivant){
		if (suivant)
			chapitre++;
		else
			chapitre--;
		if (chapitre < 0)
			chapitre = 254;
		if (chapitre > 254)
			chapitre = 0;

		chapitre_T.text = (chapitre + 1).ToString ();
	}
	public void ChangeVague(bool suivant){
		if (suivant)
			vague++;
		else
			vague--;
		if (vague < 0)
			vague = 254;
		if (vague > 254)
			vague = 0;

		vague_T.text = (vague + 1).ToString ();
		RefreshCadre ();
	}

	public void RefreshCadre(){
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 7; j++) {
				if (cadrillage [vague, i, j, 0] == 2)
					ApplyCadre (i, j, true);
				else if (cadrillage [vague, i, j, 0] >= 0)
					ApplyCadre (i, j, false);
				else EmptyCadre (i, j);
			}
	}

	void ApplyCadre(int y, int x, bool isBoss){
		switch (y) {
		case 0:
			if (isBoss)
				CadreImage0 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage0 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 1:
			if (isBoss)
				CadreImage1 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage1 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 2:
			if (isBoss)
				CadreImage2 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage2 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 3:
			if (isBoss)
				CadreImage3 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage3 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 4:
			if (isBoss)
				CadreImage4 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage4 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 5:
			if (isBoss)
				CadreImage5 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage5 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		case 6:
			if (isBoss)
				CadreImage6 [x].sprite = boss[cadrillage[vague, y, x, 1]];
			else
				CadreImage6 [x].sprite = ennemi[cadrillage[vague, y, x, 1]];
			break;
		}
	}

	void EmptyCadre(int y, int x){
		switch (y) {
		case 0:
			CadreImage0 [x].sprite = null;
			break;
		case 1:
			CadreImage1 [x].sprite = null;
			break;
		case 2:
			CadreImage2 [x].sprite = null;
			break;
		case 3:
			CadreImage3 [x].sprite = null;
			break;
		case 4:
			CadreImage4 [x].sprite = null;
			break;
		case 5:
			CadreImage5 [x].sprite = null;
			break;
		case 6:
			CadreImage6 [x].sprite = null;
			break;
		}
	}

	public int TestCadreEmpty(){
		for (int i = 0; i < 255; i++) {
			bool empty = true;
			int[,,] var1 = GetVague (i);
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
						if (var1 [j, k, 0] >= 0)
							empty = false;
			if (empty)
				return i;
		}
		return 255;
	}
	
	// Update is called once per frame
	public void ResetCadre (bool integral) {
		if (integral) {
			cadrillage = new int[255, 7, 7, 6];
			for (int i = 0; i < 255; i++)
				for (int j = 0; j < 7; j++)
					for (int k = 0; k < 7; k++)
						for (int l = 0; l < 6; l++)
							cadrillage [i, j, k, l] = -1;
		} else {

			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
					for (int l = 0; l < 6; l++)
						cadrillage [vague, j, k, l] = -1;
		}
	}

	public int[,,] GetVague(int var1){
		int[,,] var2 = new int[7,7,6];
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
				for (int l = 0; l < 6; l++)
					var2[j, k, l] =  cadrillage [var1, j, k, l];	
		return var2;
	}

	public void SetVague(int[,,] var1, int var2){
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
				for (int l = 0; l < 6; l++)
					cadrillage [var2, j, k, l] = var1[j, k, l];	
	}

	public int[] GetInfo(int var1, int var2, int var3){
		int[] var4 = new int[6];
			for (int l = 0; l < 6; l++)
				var4[l] = cadrillage [var1, var2, var3, l];
		return var4;
	}



	public void SetInfo(int[] var1, int var2, int var3, int var4){
		for (int l = 0; l < 6; l++)
			cadrillage [var2, var3, var4, l] = var1[l];;
	}

	public int x, y;
	public void SetX(int i) {
		x = i;
	}
	public void SetY(int i) {
		y= i;
	}

}
