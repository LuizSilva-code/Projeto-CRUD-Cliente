namespace CrudCliente.Applications.DTO
{
    public class ResponseClienteDTO
    {
        public int Id { get; set; }
        public int NumRanking { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}