using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using System.Collections.Generic;

namespace CrudCliente.Infra.Repository.Cliente
{
    public interface IClienteRepository
    {
        void CadastrarCliente(ClienteEntity cliente, List<EnderecoEntity> enderecos, TelefoneEntity telefone);
        List<ClienteEntity> ListarClientes();
        void EditarCliente(int id, ClienteEntity cliente);
        bool InativarCliente(int id);
        void AlterarSenha(int id, string novaSenha);
        int ContarClientesAtivos();
    }
}