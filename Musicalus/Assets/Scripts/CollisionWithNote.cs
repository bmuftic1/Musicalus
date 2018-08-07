using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionWithNote : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onCollisionEnter2D(Collision2D col){
		//poredi tag
		//vrati na initial position
		Debug.Log("HEREEEEEEEEEEEEEE");
		if (col.gameObject.name == "quarter_note") {
			Debug.Log ("I MADE IT, I FCKING MADE IT");
		}

		Debug.Log("HERE");
		if (col.gameObject.CompareTag("NotaCetvrtinka")){
			Debug.Log("YAY");
		}
		TrackingScore.score+=1;
		if (TrackingScore.score >= 20) {
			SceneManager.LoadScene ("ResultScene");
		}
	}


}
