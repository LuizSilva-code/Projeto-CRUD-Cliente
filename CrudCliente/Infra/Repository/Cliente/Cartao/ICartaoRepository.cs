using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente.Cartao
{
    public interface ICartaoRepository
    {
        void CadastrarCartao(int id, CartaoDeCreditoEntity cartao);
    }
}
