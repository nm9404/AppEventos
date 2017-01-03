using Eventos.core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Repository
{
    public class DataRepository
    {
        //All Event Data

        private MainEvent mainEvent = new MainEvent();
        string url = "https://drive.google.com/uc?export=download&id=0BygDDSNmqMx7cGVzMDhOUWZralE"; //This URL is the JSON file's URL...

        //Query Methods

        //<summary>
        //Builds the respository
        //</summary>
        public DataRepository()
        {
            //JSonStrings strings = new JSonStrings();
            //string responseJsonString = strings.JSonString;
            //MainEvent = JsonConvert.DeserializeObject<MainEvent>(responseJsonString);
        }

        //<summary>
        //Sets in an Async Task the event data from the JSON's url
        //</summary>
        public void setEventOnline()
        {
            Task.Run(() => this.LoadDataAsync(url).Wait());
        }


        public void SetEvent(MainEvent mainEvent)
        {
            this.mainEvent = mainEvent;
        }

        //<summary>
        //Task for setting the data on an Async Task
        //</summary>
        private async Task LoadDataAsync(string uri)
        {
            JSonStrings strings = new JSonStrings();
            string responseJsonString = null;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                    HttpResponseMessage response = await getResponse;
                    responseJsonString = await response.Content.ReadAsStringAsync();
                    mainEvent = JsonConvert.DeserializeObject<MainEvent>(responseJsonString);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //<summary>
        //Returns an element of type Presenter by using its Id
        //</summary>
        public Presenter GetPresenterById(int personId)
        {
            IEnumerable<Presenter> persons =

            from conference in GetAllConferences()
            from person in conference.Presenters

            where person.PresenterId == personId
            select person;

            return persons.FirstOrDefault<Presenter>();
        }

        //<summary>
        //Returns an element of type Place by using its Id
        //</summary>
        public Place GetPlaceById(int placeId)
        {
            List<Place> AllPlaces = GetAllPlaces();

            IEnumerable<Place> placeById =
            from place in AllPlaces
            where place.PlaceId == placeId
            select place;

            return placeById.FirstOrDefault<Place>();
        }

        //<summary>
        //Returns a List containing all the elements of type Place in the data
        //</summary>
        public List<Place> GetAllPlaces()
        {
            List<Place> PlacesList = new List<Place>();

            IEnumerable<Place> allPlaces =
            from conference in GetAllConferences()
            select conference.ConferencePlace;

            PlacesList = allPlaces.ToList<Place>();
            PlacesList.Add(mainEvent.Place);

            return PlacesList;
        }

        //<summary>
        //Returns a List containing all the previous work from a given presenter querying from its Id
        //</summary>
        public List<Work> GetAllPreviousWorkByPresenterId(int presenterId)
        {
            Presenter presenter = GetPresenterById(presenterId);
            return presenter.PreviousWorks;
        }

        //<summary>
        //Returns a List containing all the works (previous works and conference works) from a given presenter querying from its Id
        //</summary>
        public List<Work> GetAllWorksByPresenterId(int presenterId)
        {
            List<Work> allWorks = new List<Work>();
            allWorks = GetAllPreviousWorkByPresenterId(presenterId);

            List<Work> allConferencesWorkType = new List<Work>();
            List<Conference> allConferences = new List<Conference>();

            allConferences = GetConferenceByPresenterId(presenterId);
            foreach (Conference conference in allConferences)
            {
                allConferencesWorkType.Add((Work)conference);
            }

            return allConferencesWorkType.Concat<Work>(allWorks).ToList<Work>();
        }

        //<summary>
        //Returns a List containing all the Conferences contained in the data file
        //</summary>
        public List<Conference> GetAllConferences()
        {
            IEnumerable<Conference> allConferences =
                from conference in mainEvent.Conferences
                select conference;

            return allConferences.ToList<Conference>();
        }

        //<summary>
        //Returns a List containing all the Presenters contained in the data file
        //</summary>
        public List<Presenter> GetAllPresenters()
        {
            IEnumerable<Presenter> allPresenters =
                from conference in mainEvent.Conferences
                from presenter in conference.Presenters
                select presenter;
            return allPresenters.Distinct<Presenter>().ToList<Presenter>();
        }

        //<summary>
        //Returns a List containing all the Conferences from a given presenter Id
        //</summary>
        public List<Conference> GetConferenceByPresenterId(int presenterId)
        {
            IEnumerable<Conference> allConferences =
                from conference in mainEvent.Conferences
                from presenter in conference.Presenters
                where presenter.PresenterId == presenterId
                select conference;
            return allConferences.ToList<Conference>();
        }

        //<summary>
        //Returns an object of type Place for a given conference by using its id as the input
        //</summary>
        public Place GetPlaceByConferenceId(int conferenceId)
        {
            return GetAllConferences().Where(i => i.ConferenceId == conferenceId).FirstOrDefault<Conference>().ConferencePlace;
        }

        //<summary>
        //Returns an object of type Place for a given conference by using its id as the input
        //</summary>
        public List<Conference> GetConferencesByDay(DateF day)
        {
            IEnumerable<Conference> conferencesByDay =

                from conference in mainEvent.Conferences
                where conference.Date.Day == day.Day && conference.Date.Year == day.Year && conference.Date.Month == day.Month
                select conference;

            return conferencesByDay.ToList<Conference>();
        }

        //<summary>
        //Returns an object of type Place for a given conference by using its id as the input
        //</summary>
        public List<Work> GetAllWorks()
        {
            IEnumerable<Work> allPreviousWorks =
                from presenter in GetAllPresenters()
                from work in presenter.PreviousWorks
                select work;
            allPreviousWorks.ToList<Work>();

            IEnumerable<Work> allConferenceWorks =
                from work in mainEvent.Conferences
                select work;
            allConferenceWorks.ToList<Work>();

            return allPreviousWorks.Concat(allConferenceWorks).ToList<Work>();
        }

        //<summary>
        //Returns an object of type Place for a given conference by using its id as the input
        //</summary>
        public Conference GetConferenceByWorkId(int workId)
        {
            IEnumerable<Conference> selectedConference =
                from conference in GetAllConferences()
                where conference.WorkId == workId
                select conference;

            return selectedConference.FirstOrDefault<Conference>();
        }

        //<summary>
        //Returns an object of type Work for a given work by using its id as the input
        //</summary>
        public Work GetWorkById(int workId)
        {
            return GetAllWorks().Where(i => i.WorkId == workId).FirstOrDefault<Work>();
        }

        //<summary>
        //Returns the Event
        //</summary>
        public MainEvent GetEvent()
        {
            return mainEvent;
        }

        //<summary>
        //Returns a List of type Presenter querying by the Conference Id
        //</summary>
        public List<Presenter> GetPresentersByConferenceId(int conferenceId)
        {
            Conference conference = GetAllConferences().Where(i => i.ConferenceId == conferenceId).FirstOrDefault<Conference>();
            return conference.Presenters;
        }
    }
}
