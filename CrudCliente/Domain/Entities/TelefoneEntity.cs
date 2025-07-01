using CrudCliente.Domain.Enumerators;

namespace CrudCliente.Domain.Entities
{
    public class TelefoneEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }

        public ClienteEntity Cliente { get; set; }

    }

}
