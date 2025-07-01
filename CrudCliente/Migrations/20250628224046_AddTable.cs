using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCliente.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Pessoa_PessoaId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_PessoaId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Pessoa",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaId",
                table: "Pessoa",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Pessoa_PessoaId",
                table: "Pessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
