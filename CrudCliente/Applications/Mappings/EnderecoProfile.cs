using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;

namespace CrudCliente.Applications.Mappings
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDTO, EnderecoEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.TipoEndereco, opt => opt.MapFrom(src => src.TipoEndereco))
                .ForMember(dest => dest.TipoLogradouro, opt => opt.MapFrom(src => src.TipoLogradouro))
                .ForMember(dest => dest.TipoResidencia, opt => opt.MapFrom(src => src.TipoResidencia));

            CreateMap<EnderecoEntity, EnderecoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.TipoEndereco, opt => opt.MapFrom(src => src.TipoEndereco))
                .ForMember(dest => dest.TipoLogradouro, opt => opt.MapFrom(src => src.TipoLogradouro))
                .ForMember(dest => dest.TipoResidencia, opt => opt.MapFrom(src => src.TipoResidencia));

        }
    }
}
