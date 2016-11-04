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

namespace Eventos.Utility
{
    class MathOperations
    {
        public static bool IsEven(int number)
        {
            float fNumber = (float)number;
            return fNumber / 2 > (float)Math.Truncate(fNumber / 2);
        }
    }
}