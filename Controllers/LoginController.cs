using GavResortsTest.Interface.Services;
using GavResortsTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace GavResortsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Logar na API, todos os outros endpoints dependem do token gerado
        /// </summary>
        /// <param name="model">Nome de usuário e senha</param>
        /// <returns>Retorna as informações do usuário e o token a ser usado nos demais endpoints da aplicação</returns>
        [HttpPost]
        public ActionResult<dynamic> Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome) || string.IsNullOrEmpty(model.Senha))
            {
                return BadRequest("Nome ou senha inválidos");
            }
            try
            {
                var usuario = _userService.Login(model.Nome, model.Senha);
                var token = _tokenService.GenerateToken(usuario);
                return Ok(new
                {
                    usuario,
                    token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
