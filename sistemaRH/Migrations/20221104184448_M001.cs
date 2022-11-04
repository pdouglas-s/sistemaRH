using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    cpf_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.cpf_usuario);
                });

            migrationBuilder.CreateTable(
                name: "ValorHoras",
                columns: table => new
                {
                    IdValorHora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorHoras", x => x.IdValorHora);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    IdAtividade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    IdValorHora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.IdAtividade);
                    table.ForeignKey(
                        name: "FK_Atividades_ValorHoras_IdValorHora",
                        column: x => x.IdValorHora,
                        principalTable: "ValorHoras",
                        principalColumn: "IdValorHora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabalhos",
                columns: table => new
                {
                    IdTrabalho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdAtividade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhos", x => x.IdTrabalho);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Atividades_IdAtividade",
                        column: x => x.IdAtividade,
                        principalTable: "Atividades",
                        principalColumn: "IdAtividade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Usuarios_cpf_usuario",
                        column: x => x.cpf_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "cpf_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdValorHora",
                table: "Atividades",
                column: "IdValorHora");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_cpf_usuario",
                table: "Trabalhos",
                column: "cpf_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_IdAtividade",
                table: "Trabalhos",
                column: "IdAtividade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabalhos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ValorHoras");
        }
    }
}
