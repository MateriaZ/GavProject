using GavResortsTest.Models;

namespace GavResortsTest.Interface.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> Get(int id);
        Task<List<Contact>> Get();
        Task<Contact> Create(Contact contato);
        Task<Contact> Update(Contact contato, int id);
        Task<bool> Delete(int id);
    }
}
