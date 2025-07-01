using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    public interface ICartaoFacade
    {
        void CadastrarCartao(int id, CartaoDTO cartao);
    }
}
