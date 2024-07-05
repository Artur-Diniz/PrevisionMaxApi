using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEstatisticaTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosMaior",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosMedias",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosMenor",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GolsSofridosMaior",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolsSofridosMedias",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolsSofridosMediasCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolsSofridosMenor",
                table: "Tb_EstatisticaTimes");
        }
    }
}
