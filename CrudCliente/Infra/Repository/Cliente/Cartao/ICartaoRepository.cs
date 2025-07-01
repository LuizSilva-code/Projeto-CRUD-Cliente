using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente.Cartao
{
    public interface ICartaoRepository
    {
        CartaoDeCreditoEntity CadastrarCartao(CartaoDeCreditoEntity cartao);
    }
}
