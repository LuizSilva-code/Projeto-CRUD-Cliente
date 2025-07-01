using CrudCliente.Domain.Entities;

namespace CrudCliente.Infra.Repository.Cliente.Telefone
{
    public interface ITelefoneRepository
    {
        TelefoneEntity CadastrarTelefone(TelefoneEntity telefone);
    }
}
