using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Domain.Enumerators;
using CrudCliente.Infra.Config;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data.Common;

//Add comentario teste

namespace CrudCliente.Infra.Repository.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CadastrarCliente(ClienteEntity cliente, EnderecoEntity endereco, TelefoneEntity telefone)
        {
            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var insertClienteSql = @"
                INSERT INTO Clientes (Nome, Cpf, DtNasc, DtCadastro, Genero, Email, Senha, NumRanking, CadastroAtivo)
                VALUES (@Nome, @Cpf, @DtNasc, @DtCadastro, @Genero, @Email, @Senha, @NumRanking, @CadastroAtivo);
                SELECT last_insert_rowid(); -- Para SQLite; use SCOPE_IDENTITY() para SQL Server
            ";

                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = insertClienteSql;

                AddParameter(command, "@Nome", cliente.Nome);
                AddParameter(command, "@Cpf", cliente.Cpf);
                AddParameter(command, "@DtNasc", cliente.DtNasc);
                AddParameter(command, "@DtCadastro", cliente.DtCadastro);
                AddParameter(command, "@Genero", (int)cliente.Genero);
                AddParameter(command, "@Email", cliente.Email);
                AddParameter(command, "@Senha", cliente.Senha);
                AddParameter(command, "@NumRanking", cliente.NumRanking);
                AddParameter(command, "@CadastroAtivo", cliente.CadastroAtivo);

                var clienteId = Convert.ToInt32(command.ExecuteScalar());

                var insertEnderecoSql = @"
                INSERT INTO Enderecos (ClienteId, TipoEndereco, TipoResidencia, TipoLogradouro, Nome, Logradouro, Numero, Cep, Bairro, Cidade, Estado, Pais, Observacoes)
                VALUES (@ClienteId, @TipoEndereco, @TipoResidencia, @TipoLogradouro, @Nome, @Logradouro, @Numero, @Cep, @Bairro, @Cidade, @Estado, @Pais, @Observacoes);
            ";

                var enderecoCommand = connection.CreateCommand();
                enderecoCommand.Transaction = transaction;
                enderecoCommand.CommandText = insertEnderecoSql;

                AddParameter(enderecoCommand, "@ClienteId", clienteId);
                AddParameter(enderecoCommand, "@TipoEndereco", (int)endereco.TipoEndereco);
                AddParameter(enderecoCommand, "@TipoResidencia", (int)endereco.TipoResidencia);
                AddParameter(enderecoCommand, "@TipoLogradouro", (int)endereco.TipoLogradouro);
                AddParameter(enderecoCommand, "@Nome", endereco.Nome);
                AddParameter(enderecoCommand, "@Logradouro", endereco.Logradouro);
                AddParameter(enderecoCommand, "@Numero", endereco.Numero);
                AddParameter(enderecoCommand, "@Cep", endereco.Cep);
                AddParameter(enderecoCommand, "@Bairro", endereco.Bairro);
                AddParameter(enderecoCommand, "@Cidade", endereco.Cidade);
                AddParameter(enderecoCommand, "@Estado", endereco.Estado);
                AddParameter(enderecoCommand, "@Pais", endereco.Pais);
                AddParameter(enderecoCommand, "@Observacoes", endereco.Observacoes ?? string.Empty);

                enderecoCommand.ExecuteNonQuery();

                var insertTelefoneSql = @"
                INSERT INTO Telefones (ClienteId, TipoTelefone, Ddd, Numero)
                VALUES (@ClienteId, @TipoTelefone, @Ddd, @Numero);
            ";

                var telefoneCommand = connection.CreateCommand();
                telefoneCommand.Transaction = transaction;
                telefoneCommand.CommandText = insertTelefoneSql;

                AddParameter(telefoneCommand, "@ClienteId", clienteId);
                AddParameter(telefoneCommand, "@TipoTelefone", (int)telefone.TipoTelefone);
                AddParameter(telefoneCommand, "@Ddd", telefone.Ddd);
                AddParameter(telefoneCommand, "@Numero", telefone.Numero);

                telefoneCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao cadastrar cliente e dados relacionados", ex);
            }
        }

        public List<ClienteEntity> ListarClientes()
        {
            var clientes = new List<ClienteEntity>();

            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "SELECT * FROM Clientes;";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new ClienteEntity
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                        DtNasc = reader.GetDateTime(reader.GetOrdinal("DtNasc")),
                        DtCadastro = reader.GetDateTime(reader.GetOrdinal("DtCadastro")),
                        Genero = (Genero)reader.GetInt32(reader.GetOrdinal("Genero")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Senha = reader.GetString(reader.GetOrdinal("Senha")),
                        NumRanking = reader.GetInt32(reader.GetOrdinal("NumRanking")),
                        CadastroAtivo = reader.GetBoolean(reader.GetOrdinal("CadastroAtivo"))
                    };

                    clientes.Add(cliente);
                }

                transaction.Commit();
                return clientes;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao listar clientes", ex);
            }
        }

        public bool EditarCliente(int id, EditarClienteDTO dto)
        {
            using var connection = _context.Database.GetDbConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                // Verifica se o cliente existe
                var checkCmd = connection.CreateCommand();
                checkCmd.Transaction = transaction;
                checkCmd.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Id = @Id;";
                AddParameter(checkCmd, "@Id", id);

                var exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                if (!exists)
                {
                    transaction.Rollback();
                    return false;
                }

                var camposParaAtualizar = new List<string>();
                var parametros = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(dto.Cpf))
                {
                    camposParaAtualizar.Add("Cpf = @Cpf");
                    parametros.Add("@Cpf", dto.Cpf);
                }

                if (dto.DataNascimento.HasValue)
                {
                    camposParaAtualizar.Add("DtNasc = @DtNasc");
                    parametros.Add("@DtNasc", dto.DataNascimento.Value);
                }

                if (!string.IsNullOrWhiteSpace(dto.Email))
                {
                    camposParaAtualizar.Add("Email = @Email");
                    parametros.Add("@Email", dto.Email);
                }

                if (dto.Genero.HasValue)
                {
                    camposParaAtualizar.Add("Genero = @Genero");
                    parametros.Add("@Genero", dto.Genero.Value);
                }

                if (!string.IsNullOrWhiteSpace(dto.Nome))
                {
                    camposParaAtualizar.Add("Nome = @Nome");
                    parametros.Add("@Nome", dto.Nome);
                }

                if (!string.IsNullOrWhiteSpace(dto.Senha))
                {
                    camposParaAtualizar.Add("Senha = @Senha");
                    parametros.Add("@Senha", dto.Senha);
                }

                if (!camposParaAtualizar.Any())
                {
                    transaction.Rollback();
                    return false;
                }

                var updateSql = $"UPDATE Clientes SET {string.Join(", ", camposParaAtualizar)} WHERE Id = @Id";

                var updateCmd = connection.CreateCommand();
                updateCmd.Transaction = transaction;
                updateCmd.CommandText = updateSql;

                foreach (var param in parametros)
                    AddParameter(updateCmd, param.Key, param.Value);

                AddParameter(updateCmd, "@Id", id);

                var rowsAffected = updateCmd.ExecuteNonQuery();
                transaction.Commit();

                return rowsAffected > 0;
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