using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static float time;
	public Text timer;

	// Use this for initialization
	void Start () {
		time = 0;
    }
	
	// Update is called once per frame
	void Update () {
		time += (float)Time.deltaTime;
		int sec = (int)time;
		timer.text = "VRIJEME: "+sec.ToString ();
		InformationHolder.timer = sec;
        PlayerPrefs.SetInt("Timer", sec);
	}
}
