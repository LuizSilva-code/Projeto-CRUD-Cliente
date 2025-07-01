using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCliente.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DtCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DtNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genero = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    NumRanking = table.Column<int>(type: "INTEGER", nullable: true),
                    CadastroAtivo = table.Column<bool>(type: "INTEGER", nullable: true),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumCartao = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeImpresso = table.Column<string>(type: "TEXT", nullable: false),
                    Cvc = table.Column<int>(type: "INTEGER", nullable: false),
                    Bandeira = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Pessoa_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoResidencia = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoLogradouro = table.Column<int>(type: "INTEGER", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoa_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoTelefone = table.Column<int>(type: "INTEGER", nullable: false),
                    Ddd = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ClienteId",
                table: "Cartoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaId",
                table: "Pessoa",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
