using GavResortsTest.Interface.Services;
using GavResortsTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GavResortsTest.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        /// <summary>
        /// Listar todos os contatos cadastrados
        /// </summary>
        /// <returns>Lista de contatos com todas informações, a lista ficará vazia caso não tenha nenhum cadastrado</returns>
        [HttpGet]
        [Authorize]
        public ActionResult<List<Contact>> Get()
        {
            return Ok(_contactService.Get());
        }
        /// <summary>
        /// Obtém o contato atravéz do Identificador
        /// </summary>
        /// <param name="id">Número do Identificador do contato</param>
        /// <returns>Todas informações de um único contato caso o ID exista</returns>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Contact> Get(int id)
        {
            try
            {
                return Ok(_contactService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// Cadastrar um único contato
        /// </summary>
        /// <param name="contato">Entidade contato que será cadastrada, não é necessário informar ID</param>
        /// <returns>Retorna as informações do contato cadastrado em caso de sucesso</returns>
        [HttpPost]
        [Authorize]
        public ActionResult<Contact> Post([FromBody] Contact contato)
        {
            try
            {
                if (contato == null)
                {
                    return BadRequest("Contato nulo");
                }
                return Ok(_contactService.Create(contato));
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um erro na requisão: {ex.Message}");
            } 
        }
        /// <summary>
        /// Atualizar um único contato
        /// </summary>
        /// <param name="id">Identificador do contato a ser atualizado</param>
        /// <param name="contato">Entidade contato com as informações que serão atualizadas, id não é necessário aqui</param>
        /// <returns>Retorna as informações do contato atualizadas em caso de sucesso</returns>
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Contact> Put(int id, [FromBody] Contact contato)
        {
            if (contato == null)
            {
                return BadRequest("Erro na requisição contato vazio, favor preencher valores");
            }
            try
            {
                contato.Id = id;
                return Ok(_contactService.Update(contato, id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na requisição: {ex.Message}");
            }
            
        }
        /// <summary>
        /// Remover um contato pelo identificador
        /// </summary>
        /// <param name="id">Número do indentifiado do contato</param>
        /// <returns>Retorna uma mensagem de sucesso ou erro</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADM")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_contactService.Delete(id))
                {
                    return Ok($"Contato do id {id} removido com sucesso!");
                }
                return BadRequest($"Erro na remoção do id: {id}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na remoção: {ex.Message}");
            }
        }
    }
}
