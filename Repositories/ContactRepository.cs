using GavResortsTest.DataBase;
using GavResortsTest.Interface.Repositories;
using GavResortsTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GavResortsTest.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;
        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task<Contact> Get(int id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Contact>> Get()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<Contact> Create(Contact contato)
        {
            await _context.Contatos.AddAsync(contato);
            _context.SaveChanges();
            return contato;
        }

        public async Task<Contact> Update(Contact contato, int id)
        {
            var contatoId = await Get(id);
            if (contatoId == null)
            {
                throw new Exception($"ID {id} do contato não foi encontrado");
            }

            contatoId.Nome = contato.Nome;
            contatoId.Email = contato.Email;
            contatoId.Telefone = contato.Telefone;
            contatoId.Endereco = contato.Endereco;
            contatoId.Categoria = contato.Categoria;
            contatoId.Ativo = contato.Ativo;
            _context.Contatos.Update(contatoId);
            _context.SaveChanges();

            return contatoId;
        }
        public async Task<bool> Delete(int id)
        {
            var contatoId = await Get(id);
            if (contatoId == null)
            {
                throw new Exception($"ID {id} do contato não foi encontrado");
            }
            _context.Contatos.Remove(contatoId);
            _context.SaveChanges();
            return true;
        }
    }
}
