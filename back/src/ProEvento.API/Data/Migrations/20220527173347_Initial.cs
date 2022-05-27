using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEvento.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    eventoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    local = table.Column<string>(type: "TEXT", nullable: true),
                    dataEvento = table.Column<string>(type: "TEXT", nullable: true),
                    tema = table.Column<string>(type: "TEXT", nullable: true),
                    qtdPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    lote = table.Column<string>(type: "TEXT", nullable: true),
                    imagemURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.eventoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
