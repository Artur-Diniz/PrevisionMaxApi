using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class Upload0208 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMaior",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMenor",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PossedeBolaMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossedeBolaFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossedeBolaCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossedeBolaMaior",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaMedia",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaMediaCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaMenor",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PossedeBolaFora",
                table: "Tb_EstatisticaFora");

            migrationBuilder.DropColumn(
                name: "PossedeBolaCasa",
                table: "Tb_EstatisticaCasa");
        }
    }
}
