using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCliente.Migrations
{
    /// <inheritdoc />
    public partial class EditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_Pessoa_ClienteId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoa_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Pessoa_PessoaId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Telefones",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                newName: "IX_Telefones_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Enderecos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumRanking",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CadastroAtivo",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_Clientes_ClienteId",
                table: "Cartoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_Clientes_ClienteId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Telefones",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                newName: "IX_Telefones_PessoaId");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Pessoa",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "NumRanking",
                table: "Pessoa",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "CadastroAtivo",
                table: "Pessoa",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_Pessoa_ClienteId",
                table: "Cartoes",
                column: "ClienteId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoa_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Pessoa_PessoaId",
                table: "Telefones",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
