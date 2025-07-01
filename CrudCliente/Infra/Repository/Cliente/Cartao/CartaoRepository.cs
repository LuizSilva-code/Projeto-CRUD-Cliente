using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Config;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrudCliente.Infra.Repository.Cliente.Cartao
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly AppDbContext _context;

        public CartaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarCartao(int id, CartaoDeCreditoEntity cartao)
        {
            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var insertSql = @"
                INSERT INTO Cartoes(Bandeira, ClienteId, Cvc, NomeImpresso, NumCartao)
                VALUES (@Bandeira, @ClienteId, @Cvc, @NomeImpresso, @NumCartao);
                ";

                var cartaoCommand = connection.CreateCommand();
                cartaoCommand.Transaction = transaction;
                cartaoCommand.CommandText = insertSql;

                AddParameter(cartaoCommand, "@Bandeira", cartao.Bandeira);
                AddParameter(cartaoCommand, "@ClienteId", id);
                AddParameter(cartaoCommand, "@Cvc", cartao.Cvc);
                AddParameter(cartaoCommand, "@NomeImpresso", cartao.NomeImpresso);
                AddParameter(cartaoCommand, "@NumCartao", cartao.NumCartao);

                cartaoCommand.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao cadastrar Cartão e dados relacionados", ex);
            }
        }
        private void AddParameter(DbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}