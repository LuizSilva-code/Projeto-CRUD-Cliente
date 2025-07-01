using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarCPFStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarCPFStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void ValidarCPF(ClienteDTO cliente)
        {

        }
    }
}
