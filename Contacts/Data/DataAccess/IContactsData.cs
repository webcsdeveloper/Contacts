using Contacts.Models.DB;

namespace Contacts.Data.DataAccess
{
    public interface IContactsData
    {
        IEnumerable<Contact> ListContacts(string searchQuery);
        Contact GetContact(int id);
        Contact CreateContact(Contact contact);
        Contact EditContact(Contact contact);
        bool ContactExists(int id);
        Contact DeleteContact(Contact contact);
    }
}
