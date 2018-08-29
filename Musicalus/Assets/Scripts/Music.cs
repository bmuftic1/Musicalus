using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        AudioSource[] songs = GetComponents<AudioSource>();
        if (PlayerPrefs.GetInt("pjesma", 0)==0)
        {
            songs[0].mute = false;
            songs[1].mute = true;
            songs[2].mute = true;
        } else if (PlayerPrefs.GetInt("pjesma", 0) == 1)
        {
            songs[0].mute = true;
            songs[1].mute = false;
            songs[2].mute = true;
        } else if (PlayerPrefs.GetInt("pjesma", 0) == 2)
        {
            songs[0].mute = true;
            songs[1].mute = true;
            songs[2].mute = false;
        }


        if (SceneManager.GetActiveScene().name=="Igrica" || SceneManager.GetActiveScene().name == "EndGameReward")
        {
            songs[PlayerPrefs.GetInt("pjesma", 0)].mute = true;
        } else
        {
            songs[PlayerPrefs.GetInt("pjesma", 0)].mute = false;
        }


    }

}
