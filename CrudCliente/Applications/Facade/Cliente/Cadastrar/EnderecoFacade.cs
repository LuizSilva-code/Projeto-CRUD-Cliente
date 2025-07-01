using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente.Endereco;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    public class EnderecoFacade : IEnderecoFacade
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoFacade(IMapper mapper, IEnderecoRepository enderecoRepository)
        {
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }

        public void CadastrarEndereco(int id, EnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<EnderecoEntity>(enderecoDTO);

            _enderecoRepository.CadastrarEndereco(id, endereco);
        }

        public void EditarEndereco(int id, EditarEnderecoDTO enderecodto)
        {
            var endereco = _mapper.Map<EnderecoEntity>(enderecodto);
            endereco.Id = id;

            _enderecoRepository.EditarEndereco(id, endereco);
        }

    }
}
