using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ValorHoras_ValorHoraIdValorHora",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ValorHoraIdValorHora",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ValorHoraIdValorHora",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdCadastro",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorHoraIdValorHora",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioIdCadastro",
                table: "Usuarios",
                column: "UsuarioIdCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ValorHoraIdValorHora",
                table: "Usuarios",
                column: "ValorHoraIdValorHora");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioIdCadastro",
                table: "Usuarios",
                column: "UsuarioIdCadastro",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_ValorHoras_ValorHoraIdValorHora",
                table: "Usuarios",
                column: "ValorHoraIdValorHora",
                principalTable: "ValorHoras",
                principalColumn: "IdValorHora");
        }
    }
}
