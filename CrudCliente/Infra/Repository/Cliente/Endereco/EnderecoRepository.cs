using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Config;

namespace CrudCliente.Infra.Repository.Cliente.Endereco
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public EnderecoEntity CadastrarEndereco(EnderecoEntity endereco)
        {
            try
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();   
            }
            catch(Exception ex)
            {

            }
            return endereco;

        }
    }
}