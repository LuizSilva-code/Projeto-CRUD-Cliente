using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente.Endereco
{
    public interface IEnderecoRepository
    {
        void CadastrarEndereco(int id, EnderecoEntity endereco);
        void EditarEndereco(int id, EnderecoEntity endereco);
    }
}
