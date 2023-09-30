using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IUserAccountRepository
    {
        public List<Useracount> AllUsers();
        public bool CreateUser(Useracount useracount);
        public bool UpdateUser(Useracount useracount);
        public bool DeleteUser(int id);
        public Useracount UserById(int id);
        public Useracount Login(Useracount useracount);
        public List<Flight> SearchByDate(Flight flight);
        public List<Flight> SearchByCountry(Flight flight);
        public List<ReservedFlightByUser> ReservedUser(int id);
        public List<TrackingMap> TrackInMap(int id);

    }
}
