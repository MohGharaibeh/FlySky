using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        public Useracount ChickUser(string email)
        {
            return _userAccountRepository.ChickUser(email);
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

        public string Login(Useracount useracount)
        {
            var result = _userAccountRepository.Login(useracount);
            if (result == null)
            {
                return null;
            }
            else
            {
                var Skey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsSpecialTeamYU@200000000000"));
                var cred = new SigningCredentials(Skey, SecurityAlgorithms.HmacSha256);
                var clims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Email.ToString()),
                    new Claim(ClaimTypes.Role, result.Roleid.ToString()),
                    new Claim("Useracountid", result.Useracountid.ToString()),
                    new Claim("email", result.Email.ToString()),
                    new Claim("fname", result.Fname.ToString())
                };

                var option = new JwtSecurityToken(claims: clims, expires: DateTime.Now.AddHours(1), signingCredentials: cred);

                var token = new JwtSecurityTokenHandler().WriteToken(option);
                return token;
            }
        }
        public List<Flight> SearchByDate(Flight flight)
        {
            return _userAccountRepository.SearchByDate(flight);
        }
        public List<Flight> SearchByCountry(Flight flight)
        {
            return _userAccountRepository.SearchByCountry(flight);
        }
        public List<ReservedFlightByUser> ReservedUser(int id)
        {
            return _userAccountRepository.ReservedUser(id);
        }
        public List<TrackingMap> TrackInMap(int id)
        {
            return _userAccountRepository.TrackInMap(id);
        }

    }
}
