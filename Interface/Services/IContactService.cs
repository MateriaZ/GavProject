using GavResortsTest.Models;

namespace GavResortsTest.Interface.Services
{
    public interface IContactService
    {
        Contact Get(int id);
        List<Contact> Get();
        Contact Create(Contact contato);
        Contact Update(Contact contato, int id);
        bool Delete(int id);
    }
}
