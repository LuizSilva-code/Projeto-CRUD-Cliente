using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;
using CrudCliente.Infra.Repository.Cliente.Cartao;
using CrudCliente.Infra.Repository.Cliente.Endereco;
using CrudCliente.Infra.Repository.Cliente.Telefone;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CrudCliente.Applications.Facade.Cliente.Cadastrar
{
    public class ClienteFacade : IClienteFacade
    {
        private readonly IMapper _mapper;
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        public ClienteFacade(IMapper mapper, ICartaoRepository cartaoRepository, IClienteRepository clienteRepository, IEnderecoRepository enderecorepository, ITelefoneRepository telefoneRepository)
        {
            _mapper = mapper;
            _cartaoRepository = cartaoRepository;
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
            _enderecoRepository = enderecorepository;
        }

        public void CadastrarCliente(ClienteDTO clientedto)
        {
            var cliente = _mapper.Map<ClienteEntity>(clientedto);
            var endereco = _mapper.Map<EnderecoEntity>(clientedto);
            var telefone = _mapper.Map<TelefoneEntity>(clientedto);

            try
            {
                //todo: validaçoes
                _clienteRepository.CadastrarCliente(cliente, endereco, telefone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<ResponseClienteDTO> ListarClientes()
        {
            var clientes = _clienteRepository.ListarClientes();
            return _mapper.Map<List<ResponseClienteDTO>>(clientes);
        }

        public bool EditarCliente(int id, EditarClienteDTO dto)
        {
            var clienteEntity = _mapper.Map<ClienteEntity>(dto);
            clienteEntity.Id = id;

            return _clienteRepository.EditarCliente(id, dto);
        }
    }
}