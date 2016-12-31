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
using SupportFragment = Android.Support.V4.App.Fragment;
using Eventos.core.DataService;

namespace Eventos.AsyncTasks
{
    //<summary>
    //The purpose of this class was to instantiate dataService in an Async Task, this class is no longer used on the application
    //</summary>

    class InstantiateDataServiceTask
    {
        private List<SupportFragment> fragmentsList;
        private DataService dataServiceInstance;

        public InstantiateDataServiceTask(List<SupportFragment> fragmentsList, DataService dataServiceInstance)
        {
            this.fragmentsList = fragmentsList;
            this.dataServiceInstance = dataServiceInstance;
        }



    }
}