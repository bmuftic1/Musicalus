using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Tests.Mocks
{
    public static class CreateReportMock
    {

        const String pattern = "dd-MM-yyyy";

        private static String[] months = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public static String saveResult(ref String temp, int result)
        {

            DateTime date = DateTime.Today;


            String message = "Something went wrong.";

            try
            {

                if (temp != "" && temp != null)
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
                        temp += "\n" + DateTime.Today.ToString(pattern) + " " + result.ToString();
                        message = "Score added!";
                    }
                }
                else
                {
                    temp = DateTime.Today.ToString(pattern) + " " + result.ToString();
                    message = "Score added!";
                }
            }
            catch (Exception e)
            {
                return message + "\n" + e.Message;
            }

            return message;

        }

        public static List<int> getMonthlyResults(String temp)
        {
            List<int> results = new List<int>();
            
            if (temp != "")
            {
                try
                {
                    String[] scores = temp.Split('\n');

                    for (int i = 0; i < scores.Length; i++)
                    {
                        String[] lastEntry = scores[i].Split(' ');
                        results.Add(Int32.Parse(lastEntry[1]));
                    }
                } catch(Exception e)
                {
                    return new List<int>();
                }

            }
            return results;
        }

        public static List<double> getAnnualResults(List<String> monthResults)
        {
            List<double> results = new List<double>();

            for (int i = 0; i < monthResults.Count; i++)
            {
                List<int> monthly = getMonthlyResults(monthResults[i]);

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

    }
}
