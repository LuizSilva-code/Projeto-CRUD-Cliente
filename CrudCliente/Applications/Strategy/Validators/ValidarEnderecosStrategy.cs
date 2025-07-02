using CrudCliente.Domain.Entities;
using CrudCliente.Domain.Enumerators;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarEnderecosStrategy
    {
        public void Validar(List<EnderecoEntity> enderecos)
        {
            if (enderecos == null || !enderecos.Any())
            {
                throw new System.Exception("É necessário cadastrar ao menos um endereço.");
            }

            var temEnderecoCobranca = enderecos.Any(e => e.TipoEndereco == TipoEndereco.Cobranca);
            var temEnderecoEntrega = enderecos.Any(e => e.TipoEndereco == TipoEndereco.Entrega);

            if (!temEnderecoCobranca)
            {
                throw new System.Exception("É necessário cadastrar um endereço de cobrança.");
            }

            if (!temEnderecoEntrega)
            {
                throw new System.Exception("É necessário cadastrar um endereço de entrega.");
            }
        }
    }
}
