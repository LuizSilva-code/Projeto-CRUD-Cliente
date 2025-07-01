using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy
{
    public class AtribuirNumeroRankingStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public AtribuirNumeroRankingStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public int AtribuirNumeroNoRanking()
        {
            var clientesAtivos = _clienteRepository.ContarClientesAtivos();
            return clientesAtivos + 1;
        }
    }
}
