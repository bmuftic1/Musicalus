using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class Navigation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
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