using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movement_base : MonoBehaviour {
	float coeffID = 0.1f;
	public int wall=0;

	void OnTriggerEnter2D(Collider2D mur){
		if (mur.gameObject.name == "MurDroit")
			wall=1;
		if (mur.gameObject.name == "MurGauche")
			wall=2;
	}

	public bool isDashed = false;

	void Update (){
		if(Time.timeScale == 0)return;

		if (gameObject.transform.position.x > 2.74f)
			gameObject.transform.position = new Vector3(2.74f, gameObject.transform.position.y);
		else if (gameObject.transform.position.x < -2.76f)
			gameObject.transform.position = new Vector3(-2.76f, gameObject.transform.position.y);
		
		#if UNITY_EDITOR ||  UNITY_EDITOR_WIN ||  UNITY_EDITOR_64
		if (!isDashed && Input.GetKey ("left")&&(wall!=2)){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(-300f , transform.position.y, transform.position.z), coeffID);
			wall=0;
		}

		if (!isDashed && Input.GetKey ("right")&&(wall!=1)){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(300f, transform.position.y, transform.position.z), coeffID);
			wall=0;
		}
		#elif UNITY_ANDROID

		if (Input.touchCount > 0 && !isDashed && (wall!=1 && wall != 2)) {
         // The screen has been touched so store the touch
         Touch touch = Input.GetTouch(0);

		Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)); 
		if ((wall!=2 && touchPosition.x < 0f) || (wall!=1 && touchPosition.x > 0f)){

		Vector3 startPos = gameObject.transform.position;
         
         if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
             // If the finger is on the screen, move the object smoothly to the touch position               
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(touchPosition.x, transform.position.y, transform.position.z), coeffID); //Time.deltaTime);
         }
           		wall=0;
		}
		}
		#endif
	}


	void Awake() { 
		#if !UNITY_ANDROID
		#else
		Input.multiTouchEnabled = true;
		#endif

	}
}