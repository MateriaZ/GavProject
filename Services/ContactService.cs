using GavResortsTest.Interface.Repositories;
using GavResortsTest.Interface.Services;
using GavResortsTest.Models;

namespace GavResortsTest.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository repository)
        {
            _contactRepository = repository;
        }
        public Contact Get(int id)
        {
            var contato = _contactRepository.Get(id).Result;
            if (contato == null)
            {
                throw new Exception($"ID {id} do contato não foi encontrado");
            }
            return contato;
        }
        public List<Contact> Get()
        {
            return _contactRepository.Get().Result;
        }
        public Contact Create(Contact contato) 
        {
            return _contactRepository.Create(contato).Result;
        }
        public Contact Update(Contact contato, int id)
        {
            return _contactRepository.Update(contato, id).Result;
        }
        public bool Delete(int id)
        {
            return _contactRepository.Delete(id).Result;
        }
    }
}
