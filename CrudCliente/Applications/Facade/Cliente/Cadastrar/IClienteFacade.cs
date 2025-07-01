using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    public interface IClienteFacade
    {
        void CadastrarCliente(ClienteDTO clientedto);
        List<ResponseClienteDTO> ListarClientes();
        bool EditarCliente(int id, EditarClienteDTO dto);
        bool InativarCliente(int id);
        void AlterarSenha(int id, string novaSenha);
    }
}