using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public AnimationClip jump;
	Animation animation;
	bool play=false;
	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//jump
			//play animation
			//animation.clip=jump;
			//animation.Play ();
			play=true;
		}
			
	}
}
