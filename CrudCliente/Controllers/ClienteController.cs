using CrudCliente.Applications.DTO;
using CrudCliente.Applications.Facade.Cliente.Cadastrar;
using CrudCliente.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteFacade _clienteFacade;

        public ClienteController(IClienteFacade clienteFacade)
        {
            _clienteFacade = clienteFacade;

        }

        [HttpPost]
        [Route("/Cadastrar/Cliente")]
        public IActionResult CadastrarCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                _clienteFacade.CadastrarCliente(cliente);

                return Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao cadastrar, revise os dados enviados!!");
            }
        }

        [HttpGet]
        [Route("/Listar/Cliente")]
        [ProducesResponseType(typeof(List<ResponseClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ListarClientes()
        {
            try
            {
                var clientes = _clienteFacade.ListarClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao listar clientes.");
            }
        }

        [HttpPut]
        [Route("/Editar/Cliente/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarCliente(int id, [FromBody] EditarClienteDTO dto)
        {
            try
            {
                var atualizado = _clienteFacade.EditarCliente(id, dto);

                if (!atualizado)
                    return NotFound("Cliente não encontrado");

                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar cliente");
            }
        }
    }
}