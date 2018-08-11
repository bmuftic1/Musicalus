using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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


	// Use this for initialization
	void Start () {
		korisnickoIme = null;
		sifra = null;
		razumijem = false;
		AGREE_INIT.isOn = razumijem;
	}

	// Update is called once per frame
	void Update () {

	}

	public void buttonNastaviClick(){
		sifra = PASS_INIT.text;
		korisnickoIme = IME_INIT.text;
		razumijem = AGREE_INIT.isOn;

		if (razumijem && korisnickoIme.Length > 1 && sifra.Length > 4) {
			PlayerPrefs.SetString ("korisnickoIme", korisnickoIme);
			PlayerPrefs.SetString ("sifra", sifra);
			postaviPocetnePodatke ();
			SceneManager.LoadScene ("PocetnaScena");

		} else {
            //messageBox
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Upozorenje", "Niste popunili sva polja!", "OK");
#endif
        }
	}

	private void postaviPocetnePodatke() {
		//uradi ovo i za ostale, tj za 12 mjeseci u trenutnoj godini
		PlayerPrefs.SetString ("Jun2018", "");
	}
}


