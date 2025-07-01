using CrudCliente.Domain.Enumerators;

namespace CrudCliente.Domain.Entities
{
    public class CartaoDeCreditoEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string NumCartao { get; set; }
        public string NomeImpresso { get; set; }
        public int Cvc { get; set; }
        public BandeiraCartao Bandeira { get; set; }

    }
}