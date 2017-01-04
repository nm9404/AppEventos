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
        //<param name = "uri">
        //recieves the URL that performs a direct download of the JSON datafile
        //</param>
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
        //Searchs a Presenter with the given presenter Id
        //</summary>
        //<param name = "personId">
        //Presenter Id to find into the data
        //</param>
        //<return>
        //Returns an object of type Presenter
        //</return>
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
        //Returns the element of type Place with the given Id
        //</summary>
        //<param name = "placeId">
        //Id to look for into the data
        //</param>
        //<return>
        //Returns an element of type Place by using its Id
        //</return>
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
        //Looks for all the elements of type Place in the Event data and returns a List containing all of them
        //</summary>
        //<return>
        //Returns an element of type Place by using its Id
        //</return>
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
        //Looks for a presenter by its Id and then returns his/her list of all available previous works
        //</summary>
        //<param name = "presenterId">
        //Id to look for into the data
        //</param>
        //<return>
        //Returns all the elements of type work nor conference found for a given presenter
        //</return>
        public List<Work> GetAllPreviousWorkByPresenterId(int presenterId)
        {
            Presenter presenter = GetPresenterById(presenterId);
            return presenter.PreviousWorks;
        }

        //<summary>
        //This function returns a list of all elements of type work for a given presenter, this includes his/her conference/s
        //</summary>
        //<param name = "presenterId">
        //Id to look for into the data
        //</param>
        //<return>
        //Returns a List containing all the works (previous works and conference works)
        //</return>
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
        //<return>
        //Returns a list containing all the conferences of the event
        //</return>
        public List<Conference> GetAllConferences()
        {
            IEnumerable<Conference> allConferences =
                from conference in mainEvent.Conferences
                select conference;

            return allConferences.ToList<Conference>();
        }

        //<summary>
        //Looks for all the presenters contained in the datafile and returns a list
        //</summary>
        //<return>
        //Returns a List containing all the Presenters contained in the data file
        //</return>
        public List<Presenter> GetAllPresenters()
        {
            IEnumerable<Presenter> allPresenters =
                from conference in mainEvent.Conferences
                from presenter in conference.Presenters
                select presenter;
            return allPresenters.Distinct<Presenter>().ToList<Presenter>();
        }

        //<summary>
        //This function looks for all the conferences containing the same presenter and returns a list
        //</summary>
        //<param name="presenterId">
        //Id to find into the datafile
        //</param>
        //<return>
        //Returns a list with all the conferences of a presenter
        //</return>
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
        //This function looks for a conference by a given a id and returns its place
        //</summary>
        //<param name = "conferenceId">
        //Id to find into the dataFile
        //</param>
        //<return>
        //Returns an object of type 'Place' with the data of the Conference's place
        //</return>
        public Place GetPlaceByConferenceId(int conferenceId)
        {
            return GetAllConferences().Where(i => i.ConferenceId == conferenceId).FirstOrDefault<Conference>().ConferencePlace;
        }

        //<summary>
        //This function compares each conference date from the event data with a given date returning a list of those that match
        //</summary>
        //<param name = "day">
        //recieves an object of type DateF containing the date to look for 
        //</param>
        //<return>
        //returns a List with all the conferences that match with the given dateF object
        //</return>
        public List<Conference> GetConferencesByDay(DateF day)
        {
            IEnumerable<Conference> conferencesByDay =

                from conference in mainEvent.Conferences
                where conference.Date.Day == day.Day && conference.Date.Year == day.Year && conference.Date.Month == day.Month
                select conference;

            return conferencesByDay.ToList<Conference>();
        }

        //<summary>
        //Looks for all the elements of type work in the data and returns a List
        //</summary>
        //<return>
        //Returns a list of type Work
        //</return>
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
        //<param name = "workId">
        //Id of the work to look into the conference data
        //</param>
        //<return>
        //returns an object of type Conference if the workId has a conference associated with it
        //</return>
        public Conference GetConferenceByWorkId(int workId)
        {
            IEnumerable<Conference> selectedConference =
                from conference in GetAllConferences()
                where conference.WorkId == workId
                select conference;

            return selectedConference.FirstOrDefault<Conference>();
        }

        //<summary>
        //Compares the given Id with all work id's, if one matches the object of type work is returned
        //</summary>
        //<param name = "workId">
        //work Id to look for in the data
        //</param>
        //<return>
        //Returns an object of type work
        //</return>
        public Work GetWorkById(int workId)
        {
            return GetAllWorks().Where(i => i.WorkId == workId).FirstOrDefault<Work>();
        }

        //<summary>
        //Returns the Event
        //</summary>
        //<return>
        //Returns the Event Object
        //</return>
        public MainEvent GetEvent()
        {
            return mainEvent;
        }

        //<summary>
        //Looks for all conferences and if the Id matches with the parameter, the function returns a List of its associated presenters
        //</summary>
        //<param name = "conferenceId">
        //Id to look for in the data
        //</param>
        //<return>
        //Returns a List of type presenter when the id of the conference matches
        //</return>
        public List<Presenter> GetPresentersByConferenceId(int conferenceId)
        {
            Conference conference = GetAllConferences().Where(i => i.ConferenceId == conferenceId).FirstOrDefault<Conference>();
            return conference.Presenters;
        }
    }
}
