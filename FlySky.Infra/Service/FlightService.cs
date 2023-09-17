using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class FlightService: IFlightService
    {
        private readonly IFlightRepository _repository;
        public FlightService(IFlightRepository repository)
        {
            _repository = repository;
        }
        public void CreateFlight(Flight flight)
        {
            _repository.CreateFlight(flight);
        }
        public void UpdateFlight(Flight flight)
        {
            _repository.UpdateFlight(flight);
        }
        public void DeleteFlight(int id)
        {
            _repository.DeleteFlight(id);
        }
        public List<FlightAndAorport> GetAllFlight()
        {
            return _repository.GetAllFlight();
        }
        public FlightAndAorport GetFlightById(int id)
        {
            return _repository.GetFlightById(id);
        }
    }
}
