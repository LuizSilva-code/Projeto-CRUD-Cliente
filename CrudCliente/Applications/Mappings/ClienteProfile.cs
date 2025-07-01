using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Domain.Enumerators;

namespace CrudCliente.Applications.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDTO, ClienteEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DtNasc, opt => opt.MapFrom(src => src.DtNasc))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => (Genero)src.Genero))
                .ForMember(dest => dest.DtCadastro, opt => opt.MapFrom(src => src.DtCadastro == default ? DateTime.UtcNow : src.DtCadastro))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.NumRanking, opt => opt.MapFrom(src => src.NumRanking))
                .ForMember(dest => dest.CadastroAtivo, opt => opt.MapFrom(src => src.CadastroAtivo));

            CreateMap<ClienteEntity, ClienteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DtNasc, opt => opt.MapFrom(src => src.DtNasc))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => (int)src.Genero))
                .ForMember(dest => dest.DtCadastro, opt => opt.MapFrom(src => src.DtCadastro))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.NumRanking, opt => opt.MapFrom(src => src.NumRanking))
                .ForMember(dest => dest.CadastroAtivo, opt => opt.MapFrom(src => src.CadastroAtivo));

            CreateMap<ClienteEntity, ResponseClienteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumRanking, opt => opt.MapFrom(src => src.NumRanking))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CadastroAtivo));

            CreateMap<EditarClienteDTO, ClienteEntity>()
                .ForMember(dest => dest.Cpf, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Cpf) ? src.Cpf : null))

                .ForMember(dest => dest.DtNasc, opt =>
                    opt.MapFrom(src => src.DtNascimento.HasValue ? src.DtNascimento.Value : default(DateTime)))

                .ForMember(dest => dest.Email, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Email) ? src.Email : null))

                .ForMember(dest => dest.Genero, opt =>
                    opt.MapFrom(src => src.Genero.HasValue ? (Genero?)src.Genero.Value : null))

                .ForMember(dest => dest.Nome, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Nome) ? src.Nome : null))

                .ForMember(dest => dest.Senha, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Senha) ? src.Senha : null))

                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DtCadastro, opt => opt.Ignore())
                .ForMember(dest => dest.CadastroAtivo, opt => opt.Ignore())
                .ForMember(dest => dest.NumRanking, opt => opt.Ignore());



            CreateMap<ClienteDTO, EnderecoEntity>()
                .ForMember(dest => dest.TipoEndereco, opt => opt.MapFrom(src => (TipoEndereco)src.TipoEndereco))
                .ForMember(dest => dest.TipoResidencia, opt => opt.MapFrom(src => (TipoResidencia)src.TipoResidencia))
                .ForMember(dest => dest.TipoLogradouro, opt => opt.MapFrom(src => (TipoLogradouro)src.TipoLogradouro))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeEndereco))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore());

            CreateMap<EnderecoEntity, ClienteDTO>()
                .ForMember(dest => dest.TipoEndereco, opt => opt.MapFrom(src => (int)src.TipoEndereco))
                .ForMember(dest => dest.TipoResidencia, opt => opt.MapFrom(src => (int)src.TipoResidencia))
                .ForMember(dest => dest.TipoLogradouro, opt => opt.MapFrom(src => (int)src.TipoLogradouro))
                .ForMember(dest => dest.NomeEndereco, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes));

            CreateMap<ClienteDTO, TelefoneEntity>()
                .ForMember(dest => dest.TipoTelefone, opt => opt.MapFrom(src => (TipoTelefone)src.TipoTelefone))
                .ForMember(dest => dest.Ddd, opt => opt.MapFrom(src => src.Ddd))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.NumeroTelefone))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore());

            CreateMap<TelefoneEntity, ClienteDTO>()
                .ForMember(dest => dest.TipoTelefone, opt => opt.MapFrom(src => (int)src.TipoTelefone))
                .ForMember(dest => dest.Ddd, opt => opt.MapFrom(src => src.Ddd))
                .ForMember(dest => dest.NumeroTelefone, opt => opt.MapFrom(src => src.Numero));

            CreateMap<ClienteDTO, CartaoDeCreditoEntity>()
                .ForMember(dest => dest.NumCartao, opt => opt.MapFrom(src => src.NumCartao))
                .ForMember(dest => dest.NomeImpresso, opt => opt.MapFrom(src => src.NomeImpresso))
                .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.Cvc))
                .ForMember(dest => dest.Bandeira, opt => opt.MapFrom(src => (BandeiraCartao)src.Bandeira))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore());

            CreateMap<CartaoDeCreditoEntity, ClienteDTO>()
                .ForMember(dest => dest.NumCartao, opt => opt.MapFrom(src => src.NumCartao))
                .ForMember(dest => dest.NomeImpresso, opt => opt.MapFrom(src => src.NomeImpresso))
                .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.Cvc))
                .ForMember(dest => dest.Bandeira, opt => opt.MapFrom(src => (int)src.Bandeira));
        }
    }
}
