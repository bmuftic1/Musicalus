using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;
using Assets.Tests.Mocks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEditor;

public class GameTests {

    [Test]
    public void saveResultTestInvalidInput() {
        String input = "Invalid input";
        String message = CreateReportMock.saveResult(ref input, 12);
        StringAssert.StartsWith("Something went wrong", message);
    }

    [Test]
    public void saveFirstResultTest()
    {
        String input = "";
        int result = 12;
        String message = CreateReportMock.saveResult(ref input, result);
        StringAssert.StartsWith("Score added", message);

        String day = DateTime.Today.Day.ToString("00");
        String month = DateTime.Today.Month.ToString("00");
        String year = DateTime.Today.Year.ToString();
        StringAssert.AreEqualIgnoringCase(day+"-"+month+"-"+year+" "+result.ToString(), input);
    }

    [Test]
    public void saveAlreadyAddedResultTest()
    {
        String day = DateTime.Today.Day.ToString("00");
        String month = DateTime.Today.Month.ToString("00");
        String year = DateTime.Today.Year.ToString();
        int result = 12;

        String temp = day + "-" + month + "-" + year + " " + result.ToString();

        String message = CreateReportMock.saveResult(ref temp, result);
        StringAssert.Contains("already added", message);
    }

    [Test]
    public void saveResultSuccessfullyTest()
    {
        if (DateTime.Today.Day != 1)
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            String dayYesterday = yesterday.Day.ToString();
            String monthYesterday = yesterday.Month.ToString();
            String yearYesterday = yesterday.Year.ToString();
            int result = 12;

            String tempYesterday = dayYesterday + "-" + monthYesterday + "-" + yearYesterday + " " + result.ToString();
            String message = CreateReportMock.saveResult(ref tempYesterday, result + 1);
            StringAssert.StartsWith("Score added", message);
            StringAssert.EndsWith((result+1).ToString(), tempYesterday);


        } else
        {
            saveFirstResultTest();
        }
    }

    [Test]
    public void monthlyResultsTest()
    {
        String input = "";
        System.Random random = new System.Random();

        List<int> scores = new List<int>();

        for (int i=0; i<30; i++)
        {
            int result = random.Next(30, 300);
            scores.Add(result);
            String temp = (i + 1).ToString("00") + "-05-2018 " + result.ToString();
            if (i==0)
            {
                input += temp;
            } else
            {
                input += "\n";
                input += temp;
            }
        }

        CollectionAssert.AreEqual(scores, CreateReportMock.getMonthlyResults(input));

    }

    [Test]
    public void monthlyResultsEmptyTest()
    {
        List<int> scores = new List<int>();
        CollectionAssert.AreEqual(scores, CreateReportMock.getMonthlyResults(""));
    }

    [Test]
    public void monthlyResultsInvalidInputTest()
    {
        List<int> scores = new List<int>();
        CollectionAssert.AreEqual(scores, CreateReportMock.getMonthlyResults("Invalid input"));
    }

    [Test]
    public void annualResultsInvalidInputTest()
    {
        List<String> monthly = new List<String> { "Invalid", "Input","Test","","","","","","","","","" };
        List<int> expected = new List<int>{ 0,0,0,0,0,0,0,0,0,0,0,0 };
        CollectionAssert.AreEqual(expected, CreateReportMock.getAnnualResults(monthly));
    }

    [Test]
    public void annualResultsTest()
    {
        List<String> monthly = new List<String>();
        List<double> average = new List<double>();
        System.Random random = new System.Random();

        for (int i=0; i<12; i++)
        {
            String input = "";
            for (int j=0; j<DateTime.DaysInMonth(DateTime.Today.Year, i+1); j++)
            {

                int number = random.Next(30, 300);
                String temp = (j + 1).ToString("00") + "-" + (i + 1).ToString("00") + "-" + DateTime.Today.Year.ToString() + " " + number.ToString();
                if (j==0)
                {
                    input = temp;
                    average.Add(number);
                } else
                {
                    input += "\n";
                    input += temp;
                    average[i] += number;
                }

            }
            monthly.Add(input);
            average[i] /= DateTime.DaysInMonth(DateTime.Today.Year, i + 1);

        }

        List<double> expected = CreateReportMock.getAnnualResults(monthly);
        double eps = 0.0001;
        
        for (int i = 0; i < 12; i++)
        {
            Assert.That(average[i], Is.InRange(expected[i] - eps, expected[i] + eps));
        }
    }




}
