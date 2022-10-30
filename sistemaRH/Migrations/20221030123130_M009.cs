using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Usuarios_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_ValorHoras_ValorHoraId",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_ValorHoraId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "ValorHoraId",
                table: "Atividades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorHoraId",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ValorHoraId",
                table: "Atividades",
                column: "ValorHoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Usuarios_UsuarioId",
                table: "Atividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_ValorHoras_ValorHoraId",
                table: "Atividades",
                column: "ValorHoraId",
                principalTable: "ValorHoras",
                principalColumn: "IdValorHora",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
