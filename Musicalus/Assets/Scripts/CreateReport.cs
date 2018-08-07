using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class CreateReport
{

	const String pattern = "dd-MM-yyyy";

	private static String[] months = new string[12]{ "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };



	public static String saveResult(DateTime date) {

		String message = "Something went wrong.";

		//dodaj u inicijalizaciji da se doda string "" kao Keeping Score za svaki mjesec
		String temp = PlayerPrefs.GetString(""+months[date.Month-1]+date.Year.ToString());

		if (temp != "") {

			String[] scores = temp.Split('\n');
			String[] lastEntry = scores [scores.Length - 1].Split(' ');
			String[] lastDate = lastEntry [0].Split('-');

			if (DateTime.Today.Day == Int32.Parse (lastDate [0])) {
				message = "Score already added for today!";
			} else {
				temp += DateTime.Today.ToString (pattern) + " " + TrackingScore.timer+"\n";
				message = "Score added!";
				PlayerPrefs.SetString(""+months[date.Month-1]+date.Year.ToString(), temp);
			}
		} else {
			temp = DateTime.Today.ToString (pattern) + " " + TrackingScore.timer+"\n";
			message = "Score added!";
			PlayerPrefs.SetString(""+months[date.Month-1]+date.Year.ToString(), temp);
		}

		return message;

	}




	public static List<int> getMonthlyResults(int month, int year){
		List<int> results = new List<int> ();

		String temp = PlayerPrefs.GetString(""+months[month-1] +year.ToString());
		if (temp != "") {

			String[] scores = temp.Split ('\n');
			for (int i = 0; i < scores.Length; i++) {
				String[] lastEntry = scores [scores.Length - 1].Split(' ');
				results.Add (Int32.Parse(lastEntry [2]));
			}

		}
		return results;
	}


	public static List<double> getAnnualResults(int year){
		List<double> results = new List<double> ();

		for (int i = 1; i <= 12; i++) {
			List<int> monthly = getMonthlyResults (i, 2018);
			results.Add (monthly.Average());
		}

		return results;
	}



	public static void restartData(){
		for (int i = 0; i < months.Length; i++) {
			PlayerPrefs.SetString ("" + months [i], "");
		}
	}



}


