using AppDemo.Models;

namespace AppDemo.DataAccess
{
    public class ContactImplementation : IContactRepo<ContactInfo>
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
             new ContactInfo{ ContactId=1,FirstName="Sravani",LastName="K",CompanyName="Cognizant",EmailId="sravani@gmail.com",MobileNo=6745366477,Designation="Program  Analyst Trainee" },
             new ContactInfo{ ContactId=2,FirstName="sonu",LastName="CH",CompanyName="Cognizant",EmailId="sonu@gmail.com",MobileNo=6437643436,Designation="Trainee Analyst" },
             new ContactInfo{ ContactId=3,FirstName="Teja",LastName="K",CompanyName="wipro",EmailId="teja@gmail.com",MobileNo=7654376456,Designation="Developer" }
        };
        public bool AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return true;
        }

        public ContactInfo GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(con => con.ContactId.Equals(id));
            return contact;
        }

        public List<ContactInfo> ShowContacts()
        {
            return contacts;
        }
    }
}
