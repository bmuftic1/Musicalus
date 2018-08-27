using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoading : MonoBehaviour {

    public Image image;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (image.transform.position.x>=900f)
        {
            if (PlayerPrefs.GetString("korisnikoIme", null)==null)
            {
                SceneManager.LoadScene("InitializeScena");
            } else
            {
                SceneManager.LoadScene("PocetnaScena");
            }
            
        }
	}
}
