using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour {

    public Text result;
    

	// Use this for initialization
	void Start () {
        result.text = TrackingScore.timer.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
