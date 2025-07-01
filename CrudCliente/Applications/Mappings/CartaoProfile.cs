using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Applications.Mappings
{
    public class CartaoProfile : Profile
    {
        public CartaoProfile() 
        {
            CreateMap<CartaoDTO, CartaoDeCreditoEntity>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Bandeira, opt => opt.MapFrom(src => src.Bandeira))
               .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
               .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.Cvc))
               .ForMember(dest => dest.NomeImpresso, opt => opt.MapFrom(src => src.NomeImpresso))
               .ForMember(dest => dest.NumCartao, opt => opt.MapFrom(src => src.NumCartao));

            CreateMap<CartaoDeCreditoEntity, CartaoDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Bandeira, opt => opt.MapFrom(src => src.Bandeira))
               .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
               .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.Cvc))
               .ForMember(dest => dest.NomeImpresso, opt => opt.MapFrom(src => src.NomeImpresso))
               .ForMember(dest => dest.NumCartao, opt => opt.MapFrom(src => src.NumCartao));
        }
    }
}
