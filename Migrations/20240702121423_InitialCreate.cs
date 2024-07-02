using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_EstatisticaCasa",
                columns: table => new
                {
                    IdEstatisticaCasa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTimeCasa = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    GolsCasa = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsCasa = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsCasa = table.Column<int>(type: "int", nullable: false),
                    chutespraforaCasa = table.Column<int>(type: "int", nullable: false),
                    escanteiosCasa = table.Column<int>(type: "int", nullable: false),
                    InpedimentosCasa = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroCasa = table.Column<int>(type: "int", nullable: false),
                    FaltasCasas = table.Column<int>(type: "int", nullable: false),
                    CartoesVermelhosCasa = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloCasa = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisCasa = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosCasa = table.Column<int>(type: "int", nullable: false),
                    AtaquesperigososCasa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_EstatisticaCasa", x => x.IdEstatisticaCasa);
                });

            migrationBuilder.InsertData(
                table: "Tb_EstatisticaCasa",
                columns: new[] { "IdEstatisticaCasa", "AtaquesperigososCasa", "CartoesAmareloCasa", "CartoesVermelhosCasa", "DefesaGoleiroCasa", "FaltasCasas", "GolsCasa", "InpedimentosCasa", "NomeTimeCasa", "PassesCompletosCasa", "PassesTotaisCasa", "TentativasGolsCasa", "chutesnoGolsCasa", "chutespraforaCasa", "escanteiosCasa" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, 0, 99, 0, "Palmeiras", 0, 0, 0, 0, 0, 0 },
                    { 2, 0, 0, 0, 0, 0, -31, 0, "Cortinas", 0, 0, 0, 0, 0, 0 },
                    { 3, 0, 0, 0, 0, 0, 2, 0, "Flamengo", 0, 0, 0, 0, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_EstatisticaCasa");
        }
    }
}
