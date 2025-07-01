using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarSenhaForteStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarSenhaForteStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void ValidarSenhaForte(ClienteDTO cliente)
        {

        }
    }
}
