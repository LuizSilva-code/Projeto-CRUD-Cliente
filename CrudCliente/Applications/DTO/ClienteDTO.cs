using CrudCliente.Domain.Entities;
using CrudCliente.Domain.Enumerators;

namespace CrudCliente.Applications.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNasc { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? NumRanking { get; set; }
        public bool CadastroAtivo { get; set; }
        public DateTime DtCadastro { get; set; }
        public int Genero { get; set; }
        public int TipoEndereco { get; set; }
        public int TipoResidencia { get; set; }
        public int TipoLogradouro { get; set; }
        public string NomeEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string? Observacoes { get; set; }
        public int TipoTelefone { get; set; }
        public string Ddd { get; set; }
        public string NumeroTelefone { get; set; }
        public string NumCartao { get; set; }
        public string NomeImpresso { get; set; }
        public int Cvc { get; set; }
        public int Bandeira { get; set; }
    }
}
