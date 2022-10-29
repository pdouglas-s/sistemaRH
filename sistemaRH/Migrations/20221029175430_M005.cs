using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdCadastro",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioIdCadastro",
                table: "Usuarios",
                column: "UsuarioIdCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_VeiculoId",
                table: "Atividades",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Usuarios_VeiculoId",
                table: "Atividades",
                column: "VeiculoId",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioIdCadastro",
                table: "Usuarios",
                column: "UsuarioIdCadastro",
                principalTable: "Usuarios",
                principalColumn: "IdCadastro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Usuarios_VeiculoId",
                table: "Atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_VeiculoId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "UsuarioIdCadastro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Atividades");
        }
    }
}
