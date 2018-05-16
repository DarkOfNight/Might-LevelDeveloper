using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConstructeurEnnemi : MonoBehaviour {

	/*
	* 0 - type			0 normal 1 infini 2 boss
	* 1 - image			0 ... 1 ... 2 ... ...
	* 2 - mouvement		0 ... 1 ... 2 ... ...
	* 3 - attaque		0 ... 1 ... 2 ... ...
	* 4 - vie			> 0
	* 5 - Nombre		> 0
	* 
	*	MAX = 999
	*  -1 ou "---" = rien
	*/ 

	public Sprite[] image;
	float[] positionObjectX = { -2.74f, -1.82f, -0.91f, 0f, 0.91f, 1.82f, 2.74f };
	float[] positionObjectY = { 4.24f, 3.32f, 2.41f, 1.5f, 0.41f, -0.32f, -1.24f };

	int a = 0;


	public void Pop(int y, int x, int[] info){
		if (info [0] < 0)
			return;
		GameObject var1 = new GameObject ("Ennemi"+a.ToString());
		a++;


		var1.tag = "Ennemi_base";

		var1.transform.position = new Vector3 (positionObjectX [x], positionObjectY [y]);
		var1.transform.localScale = new Vector3 (1f, 1f, 1f);

		var1.AddComponent<SpriteRenderer>();
		var1.GetComponent<SpriteRenderer>().sprite = image [info [1]];
		var1.GetComponent<SpriteRenderer>().color = Color.white;
		var1.GetComponent<SpriteRenderer> ().sortingOrder = 0;

		var1.AddComponent<PVEnnemy> ();
		var1.GetComponent<PVEnnemy> ().PV = info [4];
		var1.GetComponent<PVEnnemy> ().x = x;
		var1.GetComponent<PVEnnemy> ().y = y;



		var1.AddComponent<Rigidbody2D> ();
		var1.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
		var1.GetComponent<Rigidbody2D> ().simulated = true;
		var1.GetComponent<Rigidbody2D> ().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
		var1.GetComponent<Rigidbody2D> ().sleepMode = RigidbodySleepMode2D.StartAwake;
		var1.GetComponent<Rigidbody2D> ().interpolation = RigidbodyInterpolation2D.None;

		var1.AddComponent<PolygonCollider2D> ();
		var1.GetComponent<PolygonCollider2D> ().autoTiling = true;
		//var1.AddComponent<BoxCollider2D> ();
		//var1.GetComponent<BoxCollider2D> ().size = new Vector2 (0.2846097f, 0.5653049f);

		//var1.AddComponent<DetectionDestroy> ();
		//var1.GetComponent<DetectionDestroy> ().x = x;
		//var1.GetComponent<DetectionDestroy> ().y = y;

	}


}
