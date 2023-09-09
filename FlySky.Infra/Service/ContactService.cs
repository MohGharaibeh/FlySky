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
    public class ContactService: IContactService
    {
        private readonly IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public void CreateContact(Contact contact)
        {
            contactRepository.CreateContact(contact);
        }
        public void UpdateContact(Contact contact)
        {
            contactRepository.UpdateContact(contact);
        }
        public void DeleteContact(int id)
        {
            contactRepository.DeleteContact(id);
        }
        public List<Contact> GetAllContact()
        {
            return contactRepository.GetAllContact();
        }
        public Contact GetContactById(int id)
        {
            return contactRepository.GetContactById(id);
        }
    }
}
