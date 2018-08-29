using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoading : MonoBehaviour {

    public Image image;
    public Image endPointImage;
    float speed;
    Vector3 finalDestination;

	// Use this for initialization
	void Start () {
        speed = 60;
        finalDestination = endPointImage.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        image.transform.position = Vector3.MoveTowards(image.transform.position, finalDestination, step);

		if (image.transform.position == finalDestination)
        {
            if (PlayerPrefs.GetString("korisnikoIme", "")=="")
            {
                SceneManager.LoadScene("InitializeScena");
            } else
            {
                SceneManager.LoadScene("PocetnaScena");
            }
            
        }
	}
}
