using System.Collections;
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
	string user;
	string password;
	bool razumijem;
	public InputField IME_INIT;
	public InputField PASS_INIT;
	public Toggle AGREE_INIT;
    public Text warning;

   
    // Use this for initialization
    void Start () {
		user = null;
		password = null;
		razumijem = false;
		AGREE_INIT.isOn = razumijem;
        warning.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

	}

	public void buttonNastaviClick(){
		password = PASS_INIT.text;
		user = IME_INIT.text;
		razumijem = AGREE_INIT.isOn;

		if (razumijem && user.Length >= 1 && password.Length >= 1) {
			PlayerPrefs.SetString ("user", user);
			PlayerPrefs.SetString ("password", password);

            PlayerPrefs.SetInt("song", 0);
            PlayerPrefs.SetInt("speed", 0);

            SceneManager.LoadScene ("PocetnaScena");

		} else {
            warning.gameObject.SetActive(true);
        }
	}
}


