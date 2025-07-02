using CrudCliente.Applications.DTO;
using CrudCliente.Applications.Facade.Cliente.Cadastrar;
using CrudCliente.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudCliente.Controllers
{
    [ApiController]
    [Route("api/[ClienteController]")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteFacade _clienteFacade;
        private readonly ICartaoFacade _cartaoFacade;

        public ClienteController(IClienteFacade clienteFacade, ICartaoFacade cartaofacade)
        {
            _clienteFacade = clienteFacade;
            _cartaoFacade = cartaofacade;

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
                // Retorna a mensagem de erro específica da validação da senha
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/Listar/Clientes")]
        [ProducesResponseType(typeof(List<ResponseClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarClientes()
        {
            try
            {
                var clientes = _clienteFacade.ListarClientes();
                return Ok(clientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao listar clientes.");
            }
        }

        [HttpPut]
        [Route("/Editar/Cliente/{id:int}")]
        public IActionResult EditarCliente(int id, [FromBody] EditarClienteDTO dto)
        {
            try
            {
                _clienteFacade.EditarCliente(id, dto);

                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/Inativar/Cliente/{id:int}")]
        public IActionResult InativarCliente(int id)
        {
            try
            {
                var sucesso = _clienteFacade.InativarCliente(id);

                if (!sucesso)
                    return BadRequest("Erro ao inativar cliente.");

                return Ok("Cliente inativado com sucesso!");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao inativar cliente.");
            }
        }

        [HttpPut]
        [Route("/AlterarSenha/Cliente/{id:int}")]
        public IActionResult AlterarSenhaCliente(int id, [FromBody] string novaSenha)
        {
            try
            {
                 _clienteFacade.AlterarSenha(id, novaSenha);
                return Ok("Senha alterada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CadastrarCartao/Cliente/{id:int}")]
        public IActionResult CadastrarCartao(int id,[FromBody] CartaoDTO cartao)
        {
            try
            {
                _cartaoFacade.CadastrarCartao(id, cartao);
                return Ok("Cartão cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar cartão, revise os dados enviados.");
            }
        }

        

        //       Método ValidarExistenciaCliente
        //       Método ValidarExistencia Enderecos
    }
}