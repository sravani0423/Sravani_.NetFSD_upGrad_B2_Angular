using Web_Application.Models;


namespace Web_Application.Repos
{
    public interface IContactService<TEntity>
    {
        List<TEntity> GetAllContacts();
        TEntity GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}
