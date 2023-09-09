using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public List<Useracount> AllUsers()
        {
            return _userAccountRepository.AllUsers();
        }
        public bool CreateUser(Useracount useracount)
        {
            return _userAccountRepository.CreateUser(useracount);
        }
        public bool UpdateUser(Useracount useracount)
        {
            return _userAccountRepository.UpdateUser(useracount);
        }
        public bool DeleteUser(int id)
        {
            return _userAccountRepository.DeleteUser(id);
        }
        public Useracount UserById(int id)
        {
            return _userAccountRepository.UserById(id);
        }
    }
}
