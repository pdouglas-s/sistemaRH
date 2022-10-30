using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaRH.Migrations
{
    public partial class M011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabalhos",
                columns: table => new
                {
                    IdTrabalho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    ValorHoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhos", x => x.IdTrabalho);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "IdAtividade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdCadastro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabalhos_ValorHoras_ValorHoraId",
                        column: x => x.ValorHoraId,
                        principalTable: "ValorHoras",
                        principalColumn: "IdValorHora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_AtividadeId",
                table: "Trabalhos",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_UsuarioId",
                table: "Trabalhos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_ValorHoraId",
                table: "Trabalhos",
                column: "ValorHoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabalhos");
        }
    }
}
