using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValorHoras",
                columns: table => new
                {
                    IdValorHora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CadastroIdCadastro = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValorHoras");
        }
    }
}
