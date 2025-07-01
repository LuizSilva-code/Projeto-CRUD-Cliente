using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    public interface IEnderecoFacade
    {
        void CadastrarEndereco(int id, EnderecoDTO endereco);
        void EditarEndereco(int id, EditarEnderecoDTO enderecoDTO);
    }
}
