using Eventos.core.Model;
using Eventos.core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.DataService
{
    //<summary>
    //This class has all the callbacks for all the methods on the dataRepository class, they serve as query methods for all the data for any event
    //</summary>

    public class DataService
    {
        private DataRepository dataRepository = new DataRepository();

        public Presenter GetPresenterById(int personId)
        {
            return dataRepository.GetPresenterById(personId);
        }

        public void SetEventOnline()
        {
            dataRepository.setEventOnline();
        }

        public void SetEvent(MainEvent mainEvent)
        {
            dataRepository.SetEvent(mainEvent);
        }

        public List<Presenter> GetAllPresenters()
        {
            return dataRepository.GetAllPresenters();
        }

        public Place GetPlaceById(int placeId)
        {
            return dataRepository.GetPlaceById(placeId);
        }

        public List<Place> GetAllPlaces()
        {
            return dataRepository.GetAllPlaces();
        }

        public List<Work> GetAllWorksByPresenterId(int presenterId)
        {
            return dataRepository.GetAllWorksByPresenterId(presenterId);
        }

        public List<Work> GetAllPreviousWorkByPresenterId(int presenterId)
        {
            return dataRepository.GetAllPreviousWorkByPresenterId(presenterId);
        }

        public List<Conference> GetAllConferences()
        {
            return dataRepository.GetAllConferences();
        }

        public List<Conference> GetConferenceByPresenterId(int presenterId)
        {
            return dataRepository.GetConferenceByPresenterId(presenterId);
        }

        public Place GetPlaceByConferenceId(int conferenceId)
        {
            return dataRepository.GetPlaceByConferenceId(conferenceId);
        }

        public List<Conference> GetConferencesByDay(DateF day)
        {
            return dataRepository.GetConferencesByDay(day);
        }

        public List<Work> GetAllWorks()
        {
            return dataRepository.GetAllWorks();
        }

        public Work GetWorkById(int workId)
        {
            return dataRepository.GetWorkById(workId);
        }

        public MainEvent GetEvent()
        {
            return dataRepository.GetEvent();
        }

        public List<Presenter> GetPresentersByConferenceId(int conferenceId)
        {
            return dataRepository.GetPresentersByConferenceId(conferenceId);
        }

        public Conference GetConferenceByWorkId(int workId)
        {
            return dataRepository.GetConferenceByWorkId(workId);
        }
    }
}
