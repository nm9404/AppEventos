using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Eventos.core.Model;

namespace Eventos.Utility
{
    class YearListOrder
    {
        //<summary>
        //Helper class, it recieves a list of conferences and returns a list of ordered dates in order to print correctly the agenda for the event
        //</summary>

        //<summary>
        //This function performs the conversion from date to a number ex. 28/07/2016 becomes the number 28072016
        //</summary>
        //<return>
        //returns the concatenated number of a given DateF date
        //</return>
        //<param name ="date">
        //DateF date to convert into a number
        //</param>
        public static int DateNumberConcat(DateF date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

        //<summary>
        //This function checks if an element is on the concatenated list
        //</summary>
        //<return>
        //returns true if the number is on the list, otherwise it returns false
        //</return>
        //<param name ="concatList">
        //is the list of numbers to check
        //</param>
        //<param name ="number">
        //is the number to check if it's on the list
        //</param>
        public static bool IsOnList (List<int> concatList, int number)
        {
            foreach (int num in concatList)
            {
                if (num==number)
                {
                    return true;
                }
            }
            return false;
        }

        //<summary>
        //This function creates the list of dates from a conference List
        //</summary>
        //<return>
        //returns the list of ordered dates for all conferences
        //</return>
        //<param name ="conferenceList">
        //List of all conferences of the event
        //</param>
        public static List<int> ConferenceToDates(List<Conference> conferenceList)
        {
            List<int> concatedDates = new List<int>();
            foreach (Conference conference in conferenceList)
            {
                if (concatedDates.Count == 0)
                {
                    concatedDates.Add(DateNumberConcat(conference.Date));
                }
                else
                {
                    if (!IsOnList(concatedDates, DateNumberConcat(conference.Date)))
                    {
                        concatedDates.Add(DateNumberConcat(conference.Date));
                    }
                }
            }

            return concatedDates.OrderBy(i=>i).ToList<int>();
        }


        //<summary>
        //This function creates a DateF object from a number
        //</summary>
        //<return>
        //returns the DateF object from the given concatenated number
        //</return>
        //<param name ="concatedDate">
        //Number to convert into a DateF in format DDMMYYYY
        //</param>
        public static DateF ConvetNumberToDateObject(int concatedDate)
        {
            DateF date = new DateF();
            date.Year = (int)(concatedDate / 10000);
            date.Month = (int)(concatedDate / 100 - date.Year * 100);
            date.Day = (int)concatedDate - (date.Year * 10000) - (date.Month * 100);
            return date;
        }
    }
}