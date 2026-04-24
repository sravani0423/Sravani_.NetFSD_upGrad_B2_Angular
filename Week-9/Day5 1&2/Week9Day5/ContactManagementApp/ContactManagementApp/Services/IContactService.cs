using ContactManagementApp.Models;
using System.Collections.Generic;

namespace ContactManagementApp.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);

        List<Contact> GetAllContacts();

        Contact GetContactById(int id);

        bool DeleteContact(int id);
    }
}