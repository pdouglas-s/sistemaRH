using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValorHoras");

            migrationBuilder.DropTable(
                name: "Cadastros");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdCadastro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdCadastro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    IdCadastro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.IdCadastro);
                });

            migrationBuilder.CreateTable(
                name: "ValorHoras",
                columns: table => new
                {
                    IdValorHora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroIdCadastro = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorHoras", x => x.IdValorHora);
                    table.ForeignKey(
                        name: "FK_ValorHoras_Cadastros_CadastroIdCadastro",
                        column: x => x.CadastroIdCadastro,
                        principalTable: "Cadastros",
                        principalColumn: "IdCadastro");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValorHoras_CadastroIdCadastro",
                table: "ValorHoras",
                column: "CadastroIdCadastro");
        }
    }
}
