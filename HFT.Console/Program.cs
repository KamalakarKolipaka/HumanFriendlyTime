using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HFT.BLL;

namespace HFT.TimeConsole
{
    public class Program
    {
        public static string ValidTime
        {
            get; set;
        }
        static void Main(string[] args)
        {
            try
            {
                string inputTime = string.Empty;
                Console.WriteLine("Please enter time to display human friendly :");
                inputTime = Console.ReadLine();
                string humanFriendtlyTime = string.Empty;
                TimeConversionBL TimeConversionBL = new TimeConversionBL();

                if (string.IsNullOrEmpty(inputTime))
                {
                    //The below method displays friendly time based on current time.
                    humanFriendtlyTime = TimeConversionBL.GetTimeInWords(DateTime.Now.Hour, DateTime.Now.Minute);
                }
                else
                {
                    ValidateTimeFormat(inputTime);
                    string[] hm = ValidTime.Split(':');
                    if (hm.Length > 0)
                    {
                        //The below method displays friendly time based on user input.
                        humanFriendtlyTime = TimeConversionBL.GetTimeInWords(Convert.ToInt32(hm[0]), Convert.ToInt32(hm[1]));
                    }
                }
                Console.WriteLine(humanFriendtlyTime);
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while converting entered time to display human friendly");
            }

        }        

        /// <summary>
        /// This method validates whether user input time is valid or not
        /// </summary>
        /// <param name="inputTime"></param>
        public static void ValidateTimeFormat(string inputTime)
        {
            string regEx = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            if (  !inputTime.Contains(':') || !Regex.IsMatch(inputTime, regEx))
            {
                Console.WriteLine("Please enter valid time to display human friendly:");
                ValidTime = Console.ReadLine();

                ValidateTimeFormat(ValidTime);
                inputTime = ValidTime;
            }
            else
            {              
                ValidTime = inputTime;
            }

        }        
    }
}
