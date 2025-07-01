using CrudCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudCliente.Infra.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<CartaoDeCreditoEntity> Cartoes { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<TelefoneEntity> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            base.OnModelCreating(modelBuilder);
        }

    }
}
