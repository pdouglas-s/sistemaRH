using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Usuarios_VeiculoId",
                table: "Atividades");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "Atividades",
                newName: "ValorHoraId");

            migrationBuilder.RenameIndex(
                name: "IX_Atividades_VeiculoId",
                table: "Atividades",
                newName: "IX_Atividades_ValorHoraId");

            migrationBuilder.AddColumn<int>(
                name: "ValorHoraIdValorHora",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ValorHoraIdValorHora",
                table: "Usuarios",
                column: "ValorHoraIdValorHora");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades",
                column: "UsuarioId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_ValorHoras_ValorHoraIdValorHora",
                table: "Usuarios",
                column: "ValorHoraIdValorHora",
                principalTable: "ValorHoras",
                principalColumn: "IdValorHora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Usuarios_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_ValorHoras_ValorHoraId",
                table: "Atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ValorHoras_ValorHoraIdValorHora",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ValorHoraIdValorHora",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "ValorHoraIdValorHora",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "ValorHoraId",
                table: "Atividades",
                newName: "VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Atividades_ValorHoraId",
                table: "Atividades",
                newName: "IX_Atividades_VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Usuarios_VeiculoId",
                table: "Atividades",
                column: "VeiculoId",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
