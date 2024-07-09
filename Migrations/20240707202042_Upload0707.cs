using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class Upload0707 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassesCompletosMaior",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PassesCompletosMenor",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.AddColumn<string>(
                name: "TipoPartida",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "escanteiosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "escanteiosMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "chutespraforaMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "chutespraforaMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "chutesnoGolsMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "chutesnoGolsMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "TentativasGolsMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "TentativasGolsMedias",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "PassesTotaisMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "PassesTotaisMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "PassesCompletosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "PassesCompletosMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "InpedimentosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "InpedimentosMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "GolsSofridosMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "GolsSofridosMedias",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "GolMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "GolMedias",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "FaltasMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "FaltasMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "DefesaGoleiroMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "DefesaGoleiroMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "CartoesVermelhosMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "CartoesAmareloMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "CartoesAmareloMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "AtaquesperigososMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "AtaquesperigososMedia",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "CartoesAmareloMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CartoesAmareloMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DefesaGoleiroMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DefesaGoleiroMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FaltasMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FaltasMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GolMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GolMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GolsSofridosMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GolsSofridosMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InpedimentosMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InpedimentosMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassesTotaisMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassesTotaisMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TentativasGolsMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TentativasGolsMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "chutesnoGolsMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "chutesnoGolsMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "chutespraforaMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "chutespraforaMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "escanteiosMaiorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "escanteiosMenorCF",
                table: "Tb_EstatisticaTimes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPartida",
                table: "TB_Partidas");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "CartoesAmareloMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "DefesaGoleiroMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "DefesaGoleiroMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "FaltasMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "FaltasMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolsSofridosMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "GolsSofridosMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "InpedimentosMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "InpedimentosMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PassesTotaisMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PassesTotaisMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "TentativasGolsMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "TentativasGolsMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "chutesnoGolsMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "chutesnoGolsMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "chutespraforaMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "chutespraforaMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosMaiorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "escanteiosMenorCF",
                table: "Tb_EstatisticaTimes");

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "chutespraforaMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "chutespraforaMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "TentativasGolsMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "TentativasGolsMedias",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "PassesTotaisMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "PassesTotaisMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "PassesCompletosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "PassesCompletosMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "GolsSofridosMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "GolsSofridosMedias",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "GolMediasCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "GolMedias",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "FaltasMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "FaltasMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesVermelhosMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "AtaquesperigososMediaCF",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "AtaquesperigososMedia",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "PassesCompletosMaior",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassesCompletosMenor",
                table: "Tb_EstatisticaTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
