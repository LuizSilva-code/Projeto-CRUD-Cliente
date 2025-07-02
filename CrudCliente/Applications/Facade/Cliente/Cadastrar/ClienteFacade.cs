using AutoMapper;
using CrudCliente.Applications.DTO;
using CrudCliente.Applications.Strategy;
using CrudCliente.Applications.Strategy.Validators;
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
        private readonly AtribuirNumeroRankingStrategy _atribuirNumeroRankingStrategy;
        private readonly ValidarSenhaForteStrategy _validarSenhaForteStrategy;
        private readonly CriptografarSenhaStrategy _criptografarSenhaStrategy;


        public ClienteFacade(IMapper mapper, IClienteRepository clienteRepository, IEnderecoRepository enderecorepository, ITelefoneRepository telefoneRepository, AtribuirNumeroRankingStrategy atribuirNumeroRankingStrategy, ValidarSenhaForteStrategy validarSenhaForteStrategy, CriptografarSenhaStrategy criptografarSenhaStrategy)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
            _enderecoRepository = enderecorepository;
            _atribuirNumeroRankingStrategy = atribuirNumeroRankingStrategy;
            _validarSenhaForteStrategy = validarSenhaForteStrategy;
            _criptografarSenhaStrategy = criptografarSenhaStrategy;
        }

        public void CadastrarCliente(ClienteDTO clientedto)
        {
            _validarSenhaForteStrategy.Validar(clientedto.Senha);
            clientedto.Senha = _criptografarSenhaStrategy.CriptografarSenha(clientedto.Senha);
            clientedto.NumRanking = _atribuirNumeroRankingStrategy.AtribuirNumeroNoRanking();

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

        public void EditarCliente(int id, EditarClienteDTO dto)
        {
            var clienteEntity = _mapper.Map<ClienteEntity>(dto);
            clienteEntity.Id = id;

            _validarSenhaForteStrategy.Validar(clienteEntity.Senha);
            clienteEntity.Senha = _criptografarSenhaStrategy.CriptografarSenha(clienteEntity.Senha);
            _clienteRepository.EditarCliente(id, clienteEntity);
        }

        public bool InativarCliente(int id)
        {
            return _clienteRepository.InativarCliente(id);
        }

        public void AlterarSenha(int id, string novaSenha)
        {
            _validarSenhaForteStrategy.Validar(novaSenha);
            novaSenha = _criptografarSenhaStrategy.CriptografarSenha(novaSenha);
            _clienteRepository.AlterarSenha(id, novaSenha);
        }
    }
}