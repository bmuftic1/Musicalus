using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class Navigation : MonoBehaviour {

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

		if (razumijem && korisnickoIme.Length > 1 && sifra.Length > 1) {
			PlayerPrefs.SetString ("korisnickoIme", korisnickoIme);
			PlayerPrefs.SetString ("sifra", sifra);
			postaviPocetnePodatke ();
			predjiNaPocetnu ();
		
		} else {
			//messageBox
			EditorUtility.DisplayDialog("Upozorenje", "Niste popunili sva polja!", "OK");
		}
	}

	private void postaviPocetnePodatke() {
		//uradi ovo i za ostale, tj za 12 mjeseci u trenutnoj godini
		PlayerPrefs.SetString ("Jun2018", "");
	}


	public void predjiNaIgricu(){
		SceneManager.LoadScene ("Igrica");
	}

	public void predjiNaLogin(){
		SceneManager.LoadScene ("Login");
	}

	public void predjiNaPocetnu(){
		SceneManager.LoadScene ("PocetnaScena");
	}

	public void predjiNaMjesecniIzvjestaj(){
		SceneManager.LoadScene ("MjesecniIzvjestajScena");
	}

	public void predjiNaGodisnjiIzvjestaj(){
		SceneManager.LoadScene ("GodisnjiIzvjestajScena");
	}

	public void predjiNaPostavke(){
		SceneManager.LoadScene ("PostavkeScena");
	}

	public void predjiNaRoditeljScena(){
		SceneManager.LoadScene ("RoditeljScena");
	}


	public void spasiIzmjene(){
		
	}

	public void izadji(){
		//myb prvo pitaj usera
		Application.Quit ();
	}

}