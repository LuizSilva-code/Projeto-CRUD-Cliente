using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente
{
    public interface IClienteRepository
    {
        void CadastrarCliente(ClienteEntity cliente, EnderecoEntity endereco, TelefoneEntity telefone);
        List<ClienteEntity> ListarClientes();
        bool EditarCliente(int id, EditarClienteDTO dto);
        bool InativarCliente(int id);
        void AlterarSenha(int id, string novaSenha);
    }
}