using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class VerifyLogin : MonoBehaviour {

	public InputField ime;
	public InputField sifra;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void login(){
		string korisnickoIme = ime.text;
		string pass = sifra.text;

		if (korisnickoIme == PlayerPrefs.GetString ("korisnickoIme") && pass == PlayerPrefs.GetString ("sifra")) {
			SceneManager.LoadScene ("RoditeljScena");
		} else {
			EditorUtility.DisplayDialog("Upozorenje", "Neispravna sifra i/ili korisnicko ime!", "OK");
		}
	}
}
