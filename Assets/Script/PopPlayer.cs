using UnityEngine;
using System.Collections;
using System;

public class PopPlayer : MonoBehaviour {

	public GameObject[] vaisseaux;

	// Use this for initialization
	void Awake () {
		try{ Instantiate (vaisseaux [int.Parse(PlayerPrefs.GetString ("Play.VaisseauID", "0"))]); }
		catch (Exception e) {
			Debug.Log (e);
			Instantiate (vaisseaux [0]);
		}
	}
}
