using System.Data.Common;
using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Config;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrudCliente.Infra.Repository.Cliente.Endereco
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarEndereco(int id, EnderecoEntity endereco)
        {
            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var insertEnderecoSql = @"
            INSERT INTO Enderecos (Bairro, Cep, Cidade, ClienteId, Estado, Logradouro, Nome, Numero, Observacoes, Pais, TipoEndereco, TipoLogradouro, TipoResidencia)
            VALUES (@Bairro, @Cep, @Cidade, @ClienteId, @Estado, @Logradouro, @Nome, @Numero, @Observacoes, @Pais, @TipoEndereco, @TipoLogradouro, @TipoResidencia);
        ";

                var enderecoCommand = connection.CreateCommand();
                enderecoCommand.Transaction = transaction;
                enderecoCommand.CommandText = insertEnderecoSql;

                AddParameter(enderecoCommand, "@Bairro", endereco.Bairro);
                AddParameter(enderecoCommand, "@Cep", endereco.Cep);
                AddParameter(enderecoCommand, "@Cidade", endereco.Cidade);
                AddParameter(enderecoCommand, "@ClienteId", id);
                AddParameter(enderecoCommand, "@Estado", endereco.Estado);
                AddParameter(enderecoCommand, "@Logradouro", endereco.Logradouro);
                AddParameter(enderecoCommand, "@Nome", endereco.Nome);
                AddParameter(enderecoCommand, "@Numero", endereco.Numero);
                AddParameter(enderecoCommand, "@Observacoes", endereco.Observacoes ?? string.Empty);
                AddParameter(enderecoCommand, "@Pais", endereco.Pais);
                AddParameter(enderecoCommand, "@TipoEndereco", (int)endereco.TipoEndereco);
                AddParameter(enderecoCommand, "@TipoLogradouro", (int)endereco.TipoLogradouro);
                AddParameter(enderecoCommand, "@TipoResidencia", (int)endereco.TipoResidencia);
                enderecoCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao cadastrar endereço.", ex);
            }
        }

        public void EditarEndereco(int id, EnderecoEntity endereco)
        {
            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var updateSql = @"
                    UPDATE Enderecos 
                    SET 
                        Nome = @Nome,
                        Logradouro = @Logradouro,
                        Numero = @Numero,
                        Bairro = @Bairro,
                        Cidade = @Cidade,
                        Estado = @Estado,
                        Pais = @Pais,
                        Cep = @Cep,
                        Observacoes = @Observacoes,
                        TipoLogradouro = @TipoLogradouro,
                        TipoResidencia = @TipoResidencia
                    WHERE Id = @Id";

                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = updateSql;

                AddParameter(command, "@Nome", endereco.Nome);
                AddParameter(command, "@Logradouro", endereco.Logradouro);
                AddParameter(command, "@Numero", endereco.Numero);
                AddParameter(command, "@Bairro", endereco.Bairro);
                AddParameter(command, "@Cidade", endereco.Cidade);
                AddParameter(command, "@Estado", endereco.Estado);
                AddParameter(command, "@Pais", endereco.Pais);
                AddParameter(command, "@Cep", endereco.Cep);
                AddParameter(command, "@Observacoes", endereco.Observacoes);
                AddParameter(command, "@TipoLogradouro", endereco.TipoLogradouro);
                AddParameter(command, "@TipoResidencia", endereco.TipoResidencia);
                AddParameter(command, "@Id", id);

                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
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