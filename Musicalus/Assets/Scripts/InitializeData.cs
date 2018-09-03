﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InitializeData : MonoBehaviour
{
	string korisnickoIme;
	string sifra;
	bool razumijem;
	public InputField IME_INIT;
	public InputField PASS_INIT;
	public Toggle AGREE_INIT;
    public Text warning;

   
    // Use this for initialization
    void Start () {
		korisnickoIme = null;
		sifra = null;
		razumijem = false;
		AGREE_INIT.isOn = razumijem;
        warning.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

	}

	public void buttonNastaviClick(){
		sifra = PASS_INIT.text;
		korisnickoIme = IME_INIT.text;
		razumijem = AGREE_INIT.isOn;

		if (razumijem && korisnickoIme.Length >= 1 && sifra.Length >= 1) {
			PlayerPrefs.SetString ("korisnickoIme", korisnickoIme);
			PlayerPrefs.SetString ("sifra", sifra);

            PlayerPrefs.SetInt("pjesma", 0);
            PlayerPrefs.SetInt("brzina", 0);

            SceneManager.LoadScene ("PocetnaScena");

		} else {
            warning.gameObject.SetActive(true);
        }
	}
}


