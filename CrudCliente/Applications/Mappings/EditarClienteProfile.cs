using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;


namespace CrudCliente.Applications.Mappings
{
    public class EditarClienteProfile : Profile
    {
        public EditarClienteProfile() 
        {
            CreateMap<EditarClienteDTO, ClienteEntity>()
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.DtNasc, opt => opt.MapFrom(src => src.DtNascimento))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));

            CreateMap<ClienteEntity, EditarClienteDTO >()
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNasc))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));

        }
    }
}
