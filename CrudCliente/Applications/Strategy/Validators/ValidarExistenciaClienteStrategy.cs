using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarExistenciaClienteStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarExistenciaClienteStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void ValidarExistenciaCliente(ClienteDTO cliente)
        {

        }
    }
}
