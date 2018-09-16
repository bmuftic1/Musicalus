using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveChanges : MonoBehaviour {

    public InputField oldPassword;
    public InputField newPassword;
    public Dropdown melody;
    public Dropdown speedOfGame;

    private void Start()
    {
        melody.value = PlayerPrefs.GetInt("song");
        speedOfGame.value = PlayerPrefs.GetInt("speed");
    }


    public void saveChanges()
    {
        if (PlayerPrefs.GetString("password")==oldPassword.text)
        {
            PlayerPrefs.SetString("password", newPassword.text);
        }


        if (melody.value != PlayerPrefs.GetInt("song"))
        {
            PlayerPrefs.SetInt("song", melody.value);
            InformationHolder.CurrentSong = melody.value;
        }

        if (PlayerPrefs.GetInt("speed") != speedOfGame.value)
        {
            PlayerPrefs.SetInt("speed", speedOfGame.value);
            InformationHolder.CurrentSpeed = speedOfGame.value;
            CreateReport.restartData();
        }

    }

}
