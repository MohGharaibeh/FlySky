using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IUserAccountService
    {
        public List<Useracount> AllUsers();
        public bool CreateUser(Useracount useracount);
        public bool UpdateUser(Useracount useracount);
        public bool DeleteUser(int id);
        public Useracount UserById(int id);
        public string Login(Useracount useracount);
        public List<Flight> SearchByDate(Flight flight);
        public List<Flight> SearchByCountry(Flight flight);
    }
}
