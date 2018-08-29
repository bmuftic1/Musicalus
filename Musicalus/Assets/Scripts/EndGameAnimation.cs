using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameAnimation : MonoBehaviour {


    public AudioSource audioSource;
    public AudioClip[] endingMusic;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        int rand = UnityEngine.Random.Range(0, endingMusic.Length);

        audioSource.clip = endingMusic[rand];
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (!audioSource.isPlaying)
        {
            SceneManager.LoadScene("ResultScene");
        }

    }

}
