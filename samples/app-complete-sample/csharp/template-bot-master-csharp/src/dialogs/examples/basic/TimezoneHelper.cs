using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Microsoft.Teams.TemplateBotCSharp.src.dialogs.examples.basic
{

    public static class  TimezoneHelper
    {
        public static string DateTimeConversion(string Date, string DateInputFormat, string DateOutputFormat)
        {
            string ConvertedDate = ""; 
            if (string.IsNullOrEmpty(Date))
            {
                ConvertedDate = "Please Provide the Valid DateTime";
            }
            else
            {
                DateTime Outputdate; if (DateTime.TryParseExact(Date, DateInputFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Outputdate))
                {
                    ConvertedDate = Outputdate.ToString(DateOutputFormat);
                }
                else
                {
                    ConvertedDate = "Enter the valid Date as Per Input Format";
                }
            }
            return ConvertedDate;
        }
        public class Data1
        {
            public string Date;
            public string TimeZone;
        }

        public static string ConvertTimeZoneJson(string DateandTimeJson)
        {

            var output = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Data1>(DateandTimeJson);

            // DateandTime = TimezoneHelper.DateTimeConversion(DateandTime, "yyyy-MM-dd'T'HH':'mm':'ss", "dd/MM/yyyy HH:mm:ss tt");
            CultureInfo culture = CultureInfo.InvariantCulture;

            //string text = "2019-08-18T07:36:13+01:00";
            //string text = "2022-03-29T10:53:00.000Z";
            DateTime DandT = DateTime.Parse(output.Date, culture, DateTimeStyles.None); // convert from yyyy-MM-dd'T'HH':'mm':'ss to MM/dd/yyyy HH:mm:ss tt
            var timezone = output.TimeZone;
            return ConvertTimeZone(DandT, timezone);    
           
        }
        public static string ConvertTimeZone(DateTime DandT,string timezone)
        {
            if (timezone == "IST" || timezone == "ist")
            {
                var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime inTime = TimeZoneInfo.ConvertTime(DandT, TimeZoneInfo.Local, inTimeZone);
                return Convert.ToString("India Standard Time " + inTime);
            }
            else if (timezone == "PST" || timezone == "pst")
            {
                var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                DateTime inTime = TimeZoneInfo.ConvertTime(DandT, TimeZoneInfo.Local, inTimeZone);
                return Convert.ToString("Pacific Standard Time " + inTime);
            }
            else if (timezone == "Israel" || timezone == "israel")
            {
                var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
                DateTime inTime = TimeZoneInfo.ConvertTime(DandT, TimeZoneInfo.Local, inTimeZone);
                return Convert.ToString("Israel Standard Time " + inTime);
            }
            else if (timezone == "UTC" || timezone == "utc")
            {
                var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
                DateTime inTime = TimeZoneInfo.ConvertTime(DandT, TimeZoneInfo.Local, inTimeZone);
                return Convert.ToString("UTC Time " + inTime);
            }
            else
            {
                return "Invalid Input";
            }
        }
    }
}