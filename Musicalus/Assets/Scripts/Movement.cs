using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    List<float> keyPosition;
    public AudioSource audioSource;
    public AudioClip[] notes;
    int whichNote;

    Vector3 initialPosition= new Vector3(125.0f, 36.0f, -64.3f);
	Vector3 finalPosition = new Vector3(35.5f, 36.0f, -64.3f);


	// Use this for initialization
	void Start () {
		//initialPosition = new Vector2();
		this.gameObject.transform.position = initialPosition;
        keyPosition = new List<float>(); //positions of the notes
        whichNote = 0;
        audioSource = GetComponent<AudioSource>();

        keyPosition.Add(36.2f);
        keyPosition.Add(37.7f);
        keyPosition.Add(39.0f);
        keyPosition.Add(40.7f);
        keyPosition.Add(42.0f);
        keyPosition.Add(43.4f);
        keyPosition.Add(45.0f);
        keyPosition.Add(46.3f);
        keyPosition.Add(47.6f);
    }

	// Update is called once per frame
	void Update () {
		//create random number or a vector of positions
		this.gameObject.transform.Translate(Vector3.right*7f*Time.deltaTime);
		if (this.gameObject.transform.position.x < finalPosition.x) {

            whichNote = getRandomValue();
            Vector3 newPosition = new Vector3(125.0f, keyPosition[whichNote], -64.3f);
			this.gameObject.transform.position = newPosition;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("PocetnaScena");
		}
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Treble_clef") {

            audioSource.clip = notes[whichNote];
            audioSource.Play();

            whichNote = getRandomValue();
            Vector3 newPosition = new Vector3(125.0f, keyPosition[whichNote], -64.3f);
            this.gameObject.transform.position = newPosition;

            TrackingScore.score++;
			if (TrackingScore.score >= 20) {
				SceneManager.LoadScene ("ResultScene");
				String message = CreateReport.saveResult (DateTime.Today);
			}
		}
	}

    int getRandomValue()
    {
        return UnityEngine.Random.Range(0, keyPosition.Count);
    }

}
