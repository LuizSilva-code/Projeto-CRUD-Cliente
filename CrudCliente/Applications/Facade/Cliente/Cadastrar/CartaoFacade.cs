using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente.Cartao;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    
    public class CartaoFacade : ICartaoFacade
    {
        private readonly IMapper _mapper;
        private readonly ICartaoRepository _cartaoRepository;
        public CartaoFacade(ICartaoRepository cartaoRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _cartaoRepository = cartaoRepository;
        }
        public void CadastrarCartao(int id, CartaoDTO cartaoDto)
        {

            try
            {
                var cartao = _mapper.Map<CartaoDeCreditoEntity>(cartaoDto);
                _cartaoRepository.CadastrarCartao(id, cartao);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString);
            }
        }
    }
}
