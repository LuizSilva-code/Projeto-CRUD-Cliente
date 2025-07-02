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

        public void Validar(string senha)
        {
            var clientes = _clienteRepository.ListarClientes();
            if (clientes.Any(c => c.Cpf == senha))
            {
                throw new Exception("Já existe um cliente cadastrado com este CPF.");
            }
        }
    }
}

