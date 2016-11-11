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
        string url = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=0BygDDSNmqMx7RC1JTVotWjFBUnc";

        //Query Methods

       public DataRepository()
        {
            Task.Run(() => this.LoadDataAsync(url).Wait());
            //JSonStrings strings = new JSonStrings();
            //string responseJsonString = strings.JSonString;
            //MainEvent = JsonConvert.DeserializeObject<MainEvent>(responseJsonString);
        }

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



        public Presenter GetPresenterById(int personId)
        {
            IEnumerable<Presenter> persons =

            from person in mainEvent.Presenters
            where person.PresenterId == personId
            select person;

            return persons.FirstOrDefault<Presenter>();
        }

        public Place GetPlaceById(int placeId)
        {
            List<Place> AllPlaces = GetAllPlaces();

            IEnumerable<Place> placeById =
            from place in AllPlaces
            where place.PlaceId == placeId
            select place;

            return placeById.FirstOrDefault<Place>();
        }

        public List<Place> GetAllPlaces()
        {
            List<Place> PlacesList = new List<Place>();

            IEnumerable<Place> allPlaces =
            from presenter in mainEvent.Presenters
            from conference in presenter.Conferences
            select conference.ConferencePlace;

            PlacesList = allPlaces.ToList<Place>();
            PlacesList.Add(mainEvent.Place);

            return PlacesList;
        }

        public List<Work> GetAllPreviousWorkByPresenterId(int presenterId)
        {
            IEnumerable<Presenter> selectedPresenter =
                from presenter in mainEvent.Presenters
                where presenter.PresenterId == presenterId
                select presenter;

            return selectedPresenter.FirstOrDefault<Presenter>().PreviousWorks;
        }

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

        public List<Conference> GetAllConferences()
        {
            IEnumerable<Conference> allConferences =
                from presenter in mainEvent.Presenters
                from conference in presenter.Conferences
                select conference;

            return allConferences.ToList<Conference>();
        }

        public List<Conference> GetConferenceByPresenterId(int presenterId)
        {
            IEnumerable<Presenter> selectedPresenter =
                from presenter in mainEvent.Presenters
                where presenter.PresenterId == presenterId
                select presenter;

                return selectedPresenter.FirstOrDefault<Presenter>().Conferences;
        }

        public Place GetPlaceByConferenceId(int conferenceId)
        {
            return GetAllConferences().Where(i => i.ConferenceId == conferenceId).FirstOrDefault<Conference>().ConferencePlace;
        }

        public List<Conference> GetConferencesByDay(int day)
        {
            IEnumerable<Conference> conferencesByDay =
                from person in mainEvent.Presenters
                from conference in person.Conferences
                where conference.Date.Day == day
                select conference;

            return conferencesByDay.ToList<Conference>();
        }

        public List<Work> GetAllWorks()
        {
            IEnumerable<Work> allPreviousWorks =
                from presenter in mainEvent.Presenters
                from work in presenter.PreviousWorks
                select work;
            allPreviousWorks.ToList<Work>();

            IEnumerable<Work> allConferenceWorks =
                from presenter in mainEvent.Presenters
                from work in presenter.Conferences
                select work;
            allConferenceWorks.ToList<Work>();

            return allPreviousWorks.Concat(allConferenceWorks).ToList<Work>();
        }

        public Conference GetConferenceByWorkId(int workId)
        {
            IEnumerable<Conference> selectedConference =
                from presenter in mainEvent.Presenters
                from conference in presenter.Conferences
                where conference.WorkId == workId
                select conference;

            return selectedConference.FirstOrDefault<Conference>();
        }


        public Work GetWorkById(int workId)
        {
            return GetAllWorks().Where(i => i.WorkId == workId).FirstOrDefault<Work>();
        }

        public MainEvent GetEvent()
        {
            return mainEvent;
        }

        public Presenter GetPresenterByConferenceId(int conferenceId)
        {
            IEnumerable<Presenter> selectedPresenter =
                from presenter in mainEvent.Presenters
                from conference in presenter.Conferences
                where conference.ConferenceId == conferenceId
                select presenter;

            return selectedPresenter.FirstOrDefault<Presenter>();
        }
    }
}
