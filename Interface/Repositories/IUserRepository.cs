using GavResortsTest.Models;

namespace GavResortsTest.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string nome, string senha);
    }
}
