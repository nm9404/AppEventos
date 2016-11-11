using Eventos.core.Model;
using Eventos.core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.DataService
{
    public class DataService
    {
        private DataRepository dataRepository = new DataRepository();

        public Presenter GetPresenterById(int personId)
        {
            return dataRepository.GetPresenterById(personId);
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

        public List<Conference> GetConferencesByDay(int day)
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

        public Presenter GetPresenterByConferenceId(int conferenceId)
        {
            return dataRepository.GetPresenterByConferenceId(conferenceId);
        }

        public Conference GetConferenceByWorkId(int workId)
        {
            return dataRepository.GetConferenceByWorkId(workId);
        }
    }
}
