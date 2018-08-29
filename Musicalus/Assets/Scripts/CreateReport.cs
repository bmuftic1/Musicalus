using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class CreateReport
{

	const String pattern = "dd-MM-yyyy";

	private static String[] months = new string[12]{ "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };



	public static String saveResult() {

        DateTime date = DateTime.Today;


        String message = "Something went wrong.";

        try
        {

            String temp = PlayerPrefs.GetString("" + months[date.Month - 1] + date.Year.ToString(), "");

            if (temp != "")
            {

                String[] scores = temp.Split('\n');
                String[] lastEntry = scores[scores.Length - 1].Split(' ');
                String[] lastDate = lastEntry[0].Split('-');

                if (DateTime.Today.Day == Int32.Parse(lastDate[0]))
                {
                     message = "Score already added for today!";
                }
                else
                {
                    temp += "\n" + DateTime.Today.ToString(pattern) + " " + PlayerPrefs.GetInt("Timer").ToString();
                    message = "Score added!";
                    PlayerPrefs.SetString("" + months[date.Month - 1] + date.Year.ToString(), temp);
                }
            }
            else
            {
                temp = DateTime.Today.ToString(pattern) + " " + PlayerPrefs.GetInt("Timer").ToString();
                message = "Score added!";
                PlayerPrefs.SetString("" + months[date.Month - 1] + date.Year.ToString(), temp);
            }
        } catch(Exception e)
        {
            return message+"\n"+e.Message;
        } 

		return message;

	}




	public static List<int> getMonthlyResults(int month, int year){
		List<int> results = new List<int> ();

		String temp = PlayerPrefs.GetString(""+months[month-1] +year.ToString());

		if (temp != "") {

			String[] scores = temp.Split ('\n');

			for (int i = 0; i < scores.Length; i++) {
				String[] lastEntry = scores [i].Split(' ');
				results.Add (Int32.Parse(lastEntry[1]));
            }

		}
		return results;
	}


	public static List<double> getAnnualResults(int year){
		List<double> results = new List<double> ();

		for (int i = 1; i <= 12; i++) {
			List<int> monthly = getMonthlyResults (i, 2018);

            if (monthly.Count == 0)
            {
                results.Add(0);
            }
            else
            {

                results.Add(monthly.Average());
            }
		}

		return results;
	}



	public static void restartData(){
        String name = PlayerPrefs.GetString("korisnickoIme");
        String pass = PlayerPrefs.GetString("sifra");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetString("korisnickoIme", name);
        PlayerPrefs.SetString("sifra", pass);
        PlayerPrefs.SetInt("pjesma", InformationHolder.CurrentSong);
        PlayerPrefs.SetInt("brzina", InformationHolder.CurrentSpeed);
    }



}


