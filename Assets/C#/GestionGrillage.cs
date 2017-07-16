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

	public int level, chapitre, vague;

	public Image[,] grille = new Image[7,7];


	// Use this for initialization
	void Start () {
		ResetCadre ();
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
	public void ResetCadre () {
		cadrillage = new int[255,7,7,6];
		for (int i = 0; i < 255; i++)
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
					for (int l = 0; l < 6; l++)
						cadrillage [i, j, k, l] = -1;			
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
