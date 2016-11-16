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
        public static int DateNumberConcat(DateF date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

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