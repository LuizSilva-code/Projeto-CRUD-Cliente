using CrudCliente.Applications.DTO;
using CrudCliente.Applications.Facade.Cliente.Cadastrar;
using CrudCliente.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudCliente.Controllers
{
    [ApiController]
    [Route("api/[EnderecoController]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoFacade _enderecoFacade;

        public EnderecoController(IEnderecoFacade enderecoFacade)
        {
            _enderecoFacade = enderecoFacade;
        }

        [HttpPost]
        [Route("/CadastrarEndereco/{id:int}")]
        public IActionResult CadastrarEndereco(int id,[FromBody] EnderecoDTO endereco)
        {
            try
            {
                _enderecoFacade.CadastrarEndereco(id, endereco);
                return Ok("Endereço cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/EditarEndereco/{id:int}")]

        public IActionResult EditarEndereco(int id, [FromBody] EditarEnderecoDTO enderecodto)
        {
            try
            {
                _enderecoFacade.EditarEndereco(id, enderecodto);
                return Ok("Endereço editado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao cadastrar endereço, revise os dados enviados.");
            }
        }

    }
}
