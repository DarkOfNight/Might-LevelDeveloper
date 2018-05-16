using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class GestionNiveau : MonoBehaviour
{
	public GameObject imageVictoire, interfaceTest, interfaceEditor, might;
	public Text informationLevel;
	public ConstructeurEnnemi constructeurEnnemi;
	public SystemLevel constructeurLevel;
	public int level = 1, chapitre = 1;

	public void EnnemyDestroyed (int x, int y)
	{
		StartCoroutine(constructeurLevel.EnnemyDestroyed (x, y));
	}

	public void TestLevel () {
		StartCoroutine (LaunchLevel());
	}

	private IEnumerator LaunchLevel(){
		bool finished = false;
		constructeurLevel = new SystemLevel(constructeurEnnemi, gameObject.GetComponentInParent<GestionGrillage>().cadrillage);
		imageVictoire.SetActive (false);
		interfaceTest.SetActive (true);
		might.SetActive (true);
		StartCoroutine (might.GetComponent<Tir_Allie> ().GestionTir ());
		interfaceEditor.SetActive (false);
		constructeurLevel.New ();
		while (!finished) {
			informationLevel.text = "Chapitre: " + constructeurLevel.chapitre + "\nLevel: " + constructeurLevel.level + "\nVague: " + (constructeurLevel.currentVague + 1);
			yield return new WaitForSeconds(1);
			if (constructeurLevel.VagueFinished ()) {
				if (constructeurLevel.currentVague < (constructeurLevel.vague - 1))
					constructeurLevel.New ();
				else {
					constructeurLevel.Stop ();
					finished = true;
				}
			}
		}
		Finish ();
	}

	public void StopTest()
	{
		StopAllCoroutines ();
		constructeurLevel.Stop ();
		imageVictoire.SetActive (false);
		interfaceEditor.SetActive (true);
		might.transform.position = new Vector3 (0f, might.transform.position.y);
		might.GetComponent<Tir_Allie> ().passifmight = 0;
		might.SetActive (false);
		interfaceTest.SetActive (false);

	}

	private void Finish(){
		StopAllCoroutines ();
		imageVictoire.SetActive (true);
	}
	/////
	/// 
	[Serializable]
	public class SystemLevel : GestionNiveau {
		public List<string> infoSerialized;
		public string[,,] information;
		/*
	 * 0 - type			000 normal	001 infini	002 boss	...
	 * 1 - image		000 ...		001 ...		002 ...		...
	 * 2 - mouvement	000 ...		001 ...		002 ...		...
	 * 3 - attaque		000 ...		001 ...		002 ...		...
	 * 4 - vie			> 000
	 * 5 - Nombre		> 000
	 * 
	 *  -1 / --- = rien
	 */ 
		public int vague, currentVague = -1;

		//public string date_creation, date_modification;
		public string[,] currentInformation;
		public int[,] currentTypeEnnemi, currentNombreEnnemi;


		public SystemLevel(ConstructeurEnnemi var1, GestionGrillage.CadreInformationLevel var2)
		{
			constructeurEnnemi = var1;
			int[,,,] cadrillage = var2.information;
			this.vague = var2.vague;
			this.level = var2.level;
			this.chapitre = var2.chapitre;
			this.information = new string[this.vague,7,7];
			for (int v = 0; v < this.vague; v++)
			{
				for (int i = 0; i < 7; i++)
					for (int j = 0; j < 7; j++) {
						string serial = "";
						for (int k = 0; k < 10; k++)
						{
							if (cadrillage [v, i, j, k] < 0)
								serial += "---";
							else
								serial += cadrillage [v, i, j, k].ToString ("D3");
						}
						this.information [v, i, j] = serial;
					}
			}
		}

		public void New(){
			this.currentVague ++;
			this.currentInformation  = this.GetVague();
			for (int i = 0; i < 7; i++)
				for (int j = 0; j < 7; j++)
					this.GameObjectsVague (i, j);
			this.GetInfo();
		}

		public void Stop(){
			for (int i = 0; i < 7; i ++)
				for (int j = 0; j < 7; j ++)
					this.currentNombreEnnemi [i, j] = 0;
			foreach (GameObject ennemi in GameObject.FindGameObjectsWithTag ("Ennemi_base"))
				Destroy(ennemi);
		}



		// Use this for initialization
		int TestCadreEmpty(){
			for (int i = 0; i < this.vague; i++) {
				bool empty = true;
				string[,] var1 = this.GetVague (i);
				for (int j = 0; j < 7; j++)
					for (int k = 0; k < 7; k++)
						if (var1 [j, k].Substring(0, 3) != "---")
							empty = false;
				if (empty)
					return i;
			}
			return 30;
		}

		string[,] GetVague(int i = -1){
			if (i == -1 || i >= this.vague)
				i = this.currentVague;
			string[,] var2 = new string[7,7];
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++) {
					var2 [j, k] = this.information [i, j, k];
				}
			return var2;
		}

		public new IEnumerator EnnemyDestroyed (int y, int x){
			yield return null;
			if (this.currentNombreEnnemi[y, x] > 0)
				this.currentNombreEnnemi [y, x] -= 1;
			if (this.currentNombreEnnemi [y, x] > 0)
				this.GameObjectsVague (y, x);
		}

		public bool VagueFinished (){
			if (GameObject.FindGameObjectsWithTag ("Ennemi_base").Length <= 0)
				return true;

			for (int i = 0; i < 7; i++)// ennemi simple
				for (int j = 0; j < 7; j++)
					if (this.currentNombreEnnemi [i, j] > 0)
						return false;

			return true;
		}

		void GameObjectsVague (int y, int x)
		{
			constructeurEnnemi.Pop(y, x, this.DecoupageDonnee(y, x));
		}

		void GetInfo(){
			currentTypeEnnemi = new int[7,7];
			currentNombreEnnemi = new int[7,7];
			for (int i = 0; i < 7; i++)
				for (int j = 0; j < 7; j++) {
					string var1 = this.currentInformation [i, j].Substring (0*3, 3), var2 = this.currentInformation [i, j].Substring (5*3, 3);
					if (var1 == "---")
						this.currentTypeEnnemi[i, j] = -1;
					else
						this.currentTypeEnnemi[i, j] = int.Parse(var1);
					if (var2 == "---")
						this.currentNombreEnnemi[i, j] = -1;
					else
						this.currentNombreEnnemi[i, j] = int.Parse(var2);
				}
		}

		int[] DecoupageDonnee(int y, int x)
		{
			int[] result = new int[10];
			for (int i = 0; i < 10; i++) {
				string var1 = this.currentInformation [y, x].Substring (i * 3, 3);
				if (var1 == "---")
					result [i] = -1;
				else 
					result [i] = int.Parse (var1);
			}
			return result;
		}

	}
}

