using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class Upload2707 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloMaiorSofridos",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloMaiorSofridosCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "CartoesAmareloMediaSofridos",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CartoesAmareloMediaSofridosCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloMenorSofridos",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloMenorSofridosCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosSofridosMaior",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosSofridosMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "escanteiosSofridosMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "escanteiosSofridosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosSofridosMenor",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosSofridosMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloForaSofridos",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosForaSofridos",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartoesAmareloCasaSofridos",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "escanteiosCasaSofridos",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartoesAmareloMaiorSofridos",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMaiorSofridosCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMediaSofridos",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMediaSofridosCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMenorSofridos",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMenorSofridosCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMaior",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMedia",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMediaCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMenor",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosSofridosMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloForaSofridos",
                table: "Tb_EstatisticaFora");

            migrationBuilder.DropColumn(
                name: "escanteiosForaSofridos",
                table: "Tb_EstatisticaFora");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloCasaSofridos",
                table: "Tb_EstatisticaCasa");

            migrationBuilder.DropColumn(
                name: "escanteiosCasaSofridos",
                table: "Tb_EstatisticaCasa");
        }
    }
}
