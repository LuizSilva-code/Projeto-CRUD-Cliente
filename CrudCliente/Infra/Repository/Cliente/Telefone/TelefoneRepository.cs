using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Config;

namespace CrudCliente.Infra.Repository.Cliente.Telefone
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly AppDbContext _context;

        public TelefoneRepository(AppDbContext context)
        {
            _context = context;
        }
        public TelefoneEntity CadastrarTelefone(TelefoneEntity telefone)
        {
            _context.Telefones.Add(telefone);
            _context.SaveChanges();
            return telefone;
        }
    }
}