using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class VerifyLogin : MonoBehaviour {

	public InputField ime;
	public InputField sifra;
    public Text warning;

	// Use this for initialization
	void Start () {
        warning.gameObject.SetActive(false);
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
            warning.gameObject.SetActive(true);
        }
	}
}
