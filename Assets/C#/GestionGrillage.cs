using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class GestionGrillage : MonoBehaviour {


	[Serializable]
	public class CadreInformationLevel
	{
		public int[,,,] information = new int[30,7,7,10];
		public List<string> infoSerialized = new List<string>();
		public DateTime creation = DateTime.UtcNow;
		public DateTime modification = DateTime.UtcNow;
		public string date_creation;
		public string date_modification;
		public int level = 0;
		public int chapitre = 0;
		public int vague = 0;

		public void InfoToFile()
		{
			this.infoSerialized.Clear();
			for (int v = 0; v < 30; v++) {
				string serial = "";
				for (int i = 0; i < 7; i++)
					for (int j = 0; j < 7; j++)
						for (int k = 0; k < 10; k++)
						{
							if (this.information [v, i, j, k] < 0)
								serial += "---";
							else
								serial += this.information [v, i, j, k].ToString ("D3");
						}
				this.infoSerialized.Add (serial);
			}

		}
		public void FileToInfo()
		{
			this.information = new int[30,7,7,10];
			for (int v = 0; v < this.infoSerialized.Capacity; v++)
			{
				int pos = 0;
				for (int i = 0; i < 7; i++)
					for (int j = 0; j < 7; j++)
						for (int k = 0; k < 10; k++)
						{
							string info = this.infoSerialized[v].Substring(pos, 3);
							if (info != "---")
								Debug.Log (info);
							if (info == "---")
								this.information [v, i, j, k] = -1;
							else
								this.information [v, i, j, k] = int.Parse (info);
							pos += 3;
						}
			}

		}

		public void DateToFile()
		{
			this.date_creation = this.creation.ToString ();
			this.modification = DateTime.UtcNow;
			this.date_modification = this.modification.ToString ();
		}
		public void FileToDate()
		{
			this.creation = DateTime.Parse(this.date_creation);
			this.modification = DateTime.Parse(this.date_modification);
		}
	}

	public CadreInformationLevel cadrillage = new CadreInformationLevel();
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

	public Text open, save, inject;

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
			level = 29;
		if (level > 29)
			level = 0;

		level_T.text = (level + 1).ToString ();
	}
	public void ChangeChapitre(bool suivant){
		if (suivant)
			chapitre++;
		else
			chapitre--;
		if (chapitre < 0)
			chapitre = 29;
		if (chapitre > 29)
			chapitre = 0;

		chapitre_T.text = (chapitre + 1).ToString ();
	}
	public void ChangeVague(bool suivant){
		if (suivant)
			vague++;
		else
			vague--;
		if (vague < 0)
			vague = 29;
		if (vague > 29)
			vague = 0;

		vague_T.text = (vague + 1).ToString ();
		RefreshCadre ();
	}

	public void RefreshCadre(){
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 7; j++)
				ApplyCadre (i, j, (cadrillage.information [vague, i, j, 0] == 2));
	}

	void ApplyCadre(int y, int x, bool isBoss){
		if (cadrillage.information [vague, y, x, 0] < 0 || cadrillage.information [vague, y, x, 1] < 0) {
			EmptyCadre (y, x);
			return;
		}


		Debug.Log (vague);
		Debug.Log (cadrillage.information[vague, y, x, 1]);

		switch (y) {
		case 0:
			if (isBoss)
				CadreImage0 [x].sprite = boss [cadrillage.information [vague, y, x, 1]];
			else
				CadreImage0 [x].sprite = ennemi [cadrillage.information[vague, y, x, 1]];
			break;
		case 1:
			if (isBoss)
				CadreImage1 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage1 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
			break;
		case 2:
			if (isBoss)
				CadreImage2 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage2 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
			break;
		case 3:
			if (isBoss)
				CadreImage3 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage3 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
			break;
		case 4:
			if (isBoss)
				CadreImage4 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage4 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
			break;
		case 5:
			if (isBoss)
				CadreImage5 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage5 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
			break;
		case 6:
			if (isBoss)
				CadreImage6 [x].sprite = boss[cadrillage.information[vague, y, x, 1]];
			else
				CadreImage6 [x].sprite = ennemi[cadrillage.information[vague, y, x, 1]];
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
		for (int i = 0; i < 30; i++) {
			bool empty = true;
			int[,,] var1 = GetVague (i);
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
						if (var1 [j, k, 0] >= 0)
							empty = false;
			if (empty)
				return i;
		}
		return 30;
	}
	
	// Update is called once per frame
	public void ResetCadre (bool integral) {
		if (integral) {
			cadrillage.information = new int[30,7,7,10];
			for (int i = 0; i < 30; i++)
				for (int j = 0; j < 7; j++)
					for (int k = 0; k < 7; k++)
						for (int l = 0; l < 10; l++)
							cadrillage.information [i, j, k, l] = -1;
		} else {

			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
					for (int l = 0; l < 10; l++)
						cadrillage.information [vague, j, k, l] = -1;
		}
		RefreshCadre ();
	}

	public int[,,] GetVague(int var1){
		int[,,] var2 = new int[7,7,10];
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
				for (int l = 0; l < 10; l++)
					var2[j, k, l] =  cadrillage.information [var1, j, k, l];	
		return var2;
	}

	public void SetVague(int[,,] var1, int var2){
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
				for (int l = 0; l < 10; l++)
					cadrillage.information [var2, j, k, l] = var1[j, k, l];	
	}

	public int[] GetInfo(int var1, int var2, int var3){
		int[] var4 = new int[10];
			for (int l = 0; l < 10; l++)
				var4[l] = cadrillage.information [var1, var2, var3, l];
		return var4;
	}



	public void SetInfo(int[] var1, int var2, int var3, int var4){
		for (int l = 0; l < 10; l++) {
			try{
			cadrillage.information [var2, var3, var4, l] = var1 [l];
			}catch{
				cadrillage.information [var2, var3, var4, l] = -1;
			}
		}
	}

	public int x, y;
	public void SetX(int i) {
		x = i;
	}
	public void SetY(int i) {
		y= i;
	}


	public void SaveAs(){
		
		cadrillage.vague = TestCadreEmpty ();
		cadrillage.chapitre = chapitre + 1;
		cadrillage.level = level + 1;

		cadrillage.InfoToFile ();
		cadrillage.DateToFile ();

		if (PlayerPrefs.GetString ("Address.Level", string.Empty) == string.Empty) {
			string home = (Environment.OSVersion.Platform == PlatformID.Unix || 
				Environment.OSVersion.Platform == PlatformID.MacOSX)
				? Environment.GetEnvironmentVariable("HOME")
				: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
			PlayerPrefs.SetString ("Address.Level", EditorUtility.OpenFolderPanel ("Dossier des niveaux Editeur \".lvlcrt\"", home, "Levels"));
		}

		if (PlayerPrefs.GetString ("Address.Level", string.Empty) == string.Empty)
			return;

		using (StreamWriter outputFile = new StreamWriter (PlayerPrefs.GetString ("Address.Level") + @"\" + cadrillage.chapitre.ToString() + "-" + cadrillage.level.ToString() + ".lvlcrt")) {
			outputFile.Write (JsonUtility.ToJson(cadrillage, true));
		}
		save.text = "Enregistrer";
	}


	public void Open(){

			string home = (Environment.OSVersion.Platform == PlatformID.Unix || 
				Environment.OSVersion.Platform == PlatformID.MacOSX)
				? Environment.GetEnvironmentVariable("HOME")
				: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
		string chemin = EditorUtility.OpenFilePanel ("Sélectionner le Niveau Might", home, "lvlcrt");

		if (chemin == null || chemin == string.Empty)
			return;

		string inputFile = System.IO.File.ReadAllText(chemin);

		JsonUtility.FromJsonOverwrite(inputFile, cadrillage);
		cadrillage.FileToInfo ();
		cadrillage.FileToDate ();

		level = cadrillage.level -1;
		chapitre = cadrillage.chapitre -1;
		vague = 0;

		level_T.text = cadrillage.level.ToString ();
		chapitre_T.text = cadrillage.chapitre.ToString ();
		vague_T.text = "1";

	
			

		open.text = "Ouvrir";
		RefreshCadre ();

	}




	public void Inject(){

		cadrillage.vague = TestCadreEmpty ();
		cadrillage.chapitre = chapitre + 1;
		cadrillage.level = level + 1;

		cadrillage.InfoToFile ();
		cadrillage.DateToFile ();


		if (PlayerPrefs.GetString ("Address.Game", string.Empty) == string.Empty) {
			string home = (Environment.OSVersion.Platform == PlatformID.Unix || 
				Environment.OSVersion.Platform == PlatformID.MacOSX)
				? Environment.GetEnvironmentVariable("HOME")
				: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
			PlayerPrefs.SetString ("Address.Game", EditorUtility.OpenFolderPanel ("Dossier du Jeu en Développement contenant les niveaux \".lvlcrt\"", home, "Levels"));
		}

		if (PlayerPrefs.GetString ("Address.Game", string.Empty) == string.Empty)
			return;
		
		using (StreamWriter outputFile = new StreamWriter (PlayerPrefs.GetString ("Address.Game") + @"\" + cadrillage.chapitre.ToString () + "-" + cadrillage.level.ToString () + ".lvlcrt")) {
			outputFile.Write (JsonUtility.ToJson(cadrillage, true));
		}
		inject.text = "Injecter";



	}

	void OnApplicationQuit(){
		PlayerPrefs.DeleteAll ();
	}


}
