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
        melody.value = PlayerPrefs.GetInt("pjesma");
        speedOfGame.value = PlayerPrefs.GetInt("brzina");
    }


    public void saveChanges()
    {
        if (PlayerPrefs.GetString("sifra")==oldPassword.text && newPassword.text.Length>4)
        {
            PlayerPrefs.SetString("sifra", newPassword.text);
        }


        if (melody.value != PlayerPrefs.GetInt("pjesma"))
        {
            PlayerPrefs.SetInt("pjesma", melody.value);
            InformationHolder.CurrentSong = melody.value;
        }

        if (PlayerPrefs.GetInt("brzina") != speedOfGame.value)
        {
            PlayerPrefs.SetInt("brzina", speedOfGame.value);
            InformationHolder.CurrentSpeed = speedOfGame.value;
            CreateReport.restartData();
        }

    }

}
