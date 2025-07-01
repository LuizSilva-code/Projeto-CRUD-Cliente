using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarEnderecosStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarEnderecosStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void ValidarEnderecos(EnderecoEntity endereco)
        {

        }

    }
}
