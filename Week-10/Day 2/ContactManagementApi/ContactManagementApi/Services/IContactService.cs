using ContactManagementApi.Models;

namespace ContactManagementApi.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();

        Contact? GetById(int id);

        void Add(Contact contact);

        bool Update(int id, Contact contact);

        bool Delete(int id);
    }
}