using GavResortsTest.Models;

namespace GavResortsTest.Interface.Services
{
    public interface ITokenService
    {
        string GenerateToken(User usuario);
    }
}
