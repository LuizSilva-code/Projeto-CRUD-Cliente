using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Config;

namespace CrudCliente.Infra.Repository.Cliente.Cartao
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly AppDbContext _context;

        public CartaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public CartaoDeCreditoEntity CadastrarCartao(CartaoDeCreditoEntity cartao)
        {
            _context.Cartoes.Add(cartao);
            _context.SaveChanges();
            return cartao;
        }
    }
}