using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabalhos_Usuarios_UsuarioId",
                table: "Trabalhos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Trabalhos",
                newName: "CadastroId");

            migrationBuilder.RenameIndex(
                name: "IX_Trabalhos_UsuarioId",
                table: "Trabalhos",
                newName: "IX_Trabalhos_CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabalhos_Usuarios_CadastroId",
                table: "Trabalhos",
                column: "CadastroId",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabalhos_Usuarios_CadastroId",
                table: "Trabalhos");

            migrationBuilder.RenameColumn(
                name: "CadastroId",
                table: "Trabalhos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Trabalhos_CadastroId",
                table: "Trabalhos",
                newName: "IX_Trabalhos_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabalhos_Usuarios_UsuarioId",
                table: "Trabalhos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
