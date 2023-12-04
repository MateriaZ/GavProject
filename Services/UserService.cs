using GavResortsTest.Interface.Repositories;
using GavResortsTest.Interface.Services;
using GavResortsTest.Models;

namespace GavResortsTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public User Login(string nome, string senha)
        {
            var userResult = _userRepository.Login(nome, senha).Result;
            if (userResult == null)
            {
                throw new Exception("Erro ao tentar logar, verifique nome do usuário ou senha");
            }
            userResult.Senha = "";
            return userResult;
        }
    }
}
