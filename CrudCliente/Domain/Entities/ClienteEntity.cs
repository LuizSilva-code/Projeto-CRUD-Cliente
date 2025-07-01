namespace CrudCliente.Domain.Entities
{
    public class ClienteEntity : PessoaEntity
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? NumRanking { get; set; }
        public bool CadastroAtivo { get; set; }
    }
}