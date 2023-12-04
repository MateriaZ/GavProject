using GavResortsTest.Models;

namespace GavResortsTest.Interface.Services
{
    public interface IUserService
    {
        User Login(string nome, string senha);
    }
}
