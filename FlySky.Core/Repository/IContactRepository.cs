using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContact();
        Contact GetContactById(int id);
    }
}
