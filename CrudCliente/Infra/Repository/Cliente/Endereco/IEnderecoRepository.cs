using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente.Endereco
{
    public interface IEnderecoRepository
    {
        EnderecoEntity CadastrarEndereco(EnderecoEntity endereco);
    }
}
