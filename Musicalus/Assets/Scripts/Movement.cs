using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	Vector3 initialPosition= new Vector3(125.0f, 36.0f, -64.3f);
	Vector3 finalPosition = new Vector3(35.5f, 36.0f, -64.3f);

	// Use this for initialization
	void Start () {
		//initialPosition = new Vector2();
		this.gameObject.transform.position = initialPosition;
	}

	// Update is called once per frame
	void Update () {
		//create random number or a vector of positions
		this.gameObject.transform.Translate(Vector3.right*7f*Time.deltaTime);
		if (this.gameObject.transform.position.x < finalPosition.x) {
			this.gameObject.transform.position = initialPosition;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("PocetnaScena");
		}
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Treble_clef") {
			this.gameObject.transform.position = initialPosition;
			TrackingScore.score++;
			if (TrackingScore.score >= 20) {
				SceneManager.LoadScene ("ResultScene");
				//TrackingScore.saveResult (TrackingScore.timer);
			}
		}
	}

}
