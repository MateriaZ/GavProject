using GavResortsTest.DataBase;
using GavResortsTest.Interface.Repositories;
using GavResortsTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GavResortsTest.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public async Task<User> Login(string nome, string senha)
        {
            return await _context.Usuarios.Include(p => p.Perfil).FirstOrDefaultAsync(x => x.Nome.ToUpper() == nome.ToUpper() && x.Senha == senha);
        }
    }
}
