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
	public InputField password;
    public Text warning;

	// Use this for initialization
	void Start () {
        warning.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void login(){
		string user = ime.text;
		string pass = password.text;

		if (user == PlayerPrefs.GetString ("user") && pass == PlayerPrefs.GetString ("password")) {
			SceneManager.LoadScene ("RoditeljScena");
		} else {
            warning.gameObject.SetActive(true);
        }
	}
}
