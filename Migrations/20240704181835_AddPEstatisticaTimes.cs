using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPEstatisticaTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa",
                table: "TB_Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora",
                table: "TB_Partidas");

            migrationBuilder.DeleteData(
                table: "Tb_EstatisticaCasa",
                keyColumn: "IdEstatisticaCasa",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tb_EstatisticaCasa",
                keyColumn: "IdEstatisticaCasa",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tb_EstatisticaCasa",
                keyColumn: "IdEstatisticaCasa",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCampeonato",
                table: "TB_TBCampeonato",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificacaoIds",
                table: "TB_TBCampeonato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeFora",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeCasa",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "IdEstatisticaFora",
                table: "TB_Partidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstatisticaCasa",
                table: "TB_Partidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Campeonato",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "PartidaAnalise",
                table: "TB_Partidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "TB_Palpites",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeFora",
                table: "Tb_EstatisticaFora",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesVermelhosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdversarioCasa",
                table: "Tb_EstatisticaFora",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeCasa",
                table: "Tb_EstatisticaCasa",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesVermelhosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdversarioFora",
                table: "Tb_EstatisticaCasa",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos5",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos4",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos3",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos2",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos1",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTime",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "Tb_EstatisticaTimes",
                columns: table => new
                {
                    IdTime = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTime = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: true),
                    GolMedias = table.Column<int>(type: "int", nullable: false),
                    GolMaior = table.Column<int>(type: "int", nullable: false),
                    GolMenor = table.Column<int>(type: "int", nullable: false),
                    GolMediasCF = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsMedias = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsMenor = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsMaior = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsMediasCF = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsMedia = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsMenor = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsMaior = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsMediaCF = table.Column<int>(type: "int", nullable: false),
                    chutespraforaMedia = table.Column<int>(type: "int", nullable: false),
                    chutespraforaMenor = table.Column<int>(type: "int", nullable: false),
                    chutespraforaMaior = table.Column<int>(type: "int", nullable: false),
                    chutespraforaMediaCF = table.Column<int>(type: "int", nullable: false),
                    escanteiosMedia = table.Column<int>(type: "int", nullable: false),
                    escanteiosMenor = table.Column<int>(type: "int", nullable: false),
                    escanteiosMaior = table.Column<int>(type: "int", nullable: false),
                    escanteiosMediaCF = table.Column<int>(type: "int", nullable: false),
                    InpedimentosMedia = table.Column<int>(type: "int", nullable: false),
                    InpedimentosMenor = table.Column<int>(type: "int", nullable: false),
                    InpedimentosMaior = table.Column<int>(type: "int", nullable: false),
                    InpedimentosMediaCF = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroMedia = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroMenor = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroMaior = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroMediaCF = table.Column<int>(type: "int", nullable: false),
                    FaltasMedia = table.Column<int>(type: "int", nullable: false),
                    FaltasMenor = table.Column<int>(type: "int", nullable: false),
                    FaltasMaior = table.Column<int>(type: "int", nullable: false),
                    FaltasMediaCF = table.Column<int>(type: "int", nullable: false),
                    CartoesVermelhosMedia = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloMedia = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloMenor = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloMaior = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloMediaCF = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisMedia = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisMenor = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisMaior = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisMediaCF = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosMedia = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosMediaCF = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosMaior = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosMenor = table.Column<int>(type: "int", nullable: false),
                    AtaquesperigososMedia = table.Column<int>(type: "int", nullable: false),
                    AtaquesperigososMediaCF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_EstatisticaTimes", x => x.IdTime);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa",
                table: "TB_Partidas",
                column: "IdEstatisticaCasa",
                principalTable: "Tb_EstatisticaCasa",
                principalColumn: "IdEstatisticaCasa");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora",
                table: "TB_Partidas",
                column: "IdEstatisticaFora",
                principalTable: "Tb_EstatisticaFora",
                principalColumn: "IdEstatisticaFora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa",
                table: "TB_Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora",
                table: "TB_Partidas");

            migrationBuilder.DropTable(
                name: "Tb_EstatisticaTimes");

            migrationBuilder.DropColumn(
                name: "PartidaAnalise",
                table: "TB_Partidas");

            migrationBuilder.DropColumn(
                name: "AdversarioCasa",
                table: "Tb_EstatisticaFora");

            migrationBuilder.DropColumn(
                name: "GolsSofridosFora",
                table: "Tb_EstatisticaFora");

            migrationBuilder.DropColumn(
                name: "AdversarioFora",
                table: "Tb_EstatisticaCasa");

            migrationBuilder.DropColumn(
                name: "GolsSofridosCasa",
                table: "Tb_EstatisticaCasa");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCampeonato",
                table: "TB_TBCampeonato",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificacaoIds",
                table: "TB_TBCampeonato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeFora",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeCasa",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEstatisticaFora",
                table: "TB_Partidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEstatisticaCasa",
                table: "TB_Partidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campeonato",
                table: "TB_Partidas",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "TB_Palpites",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeFora",
                table: "Tb_EstatisticaFora",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartoesVermelhosFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloFora",
                table: "Tb_EstatisticaFora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "escanteiosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "chutesnoGolsCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTimeCasa",
                table: "Tb_EstatisticaCasa",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InpedimentosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefesaGoleiroCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartoesVermelhosCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartoesAmareloCasa",
                table: "Tb_EstatisticaCasa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos5",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos4",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos3",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos2",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ultiomojogos1",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTime",
                table: "TB_Classificacao",
                type: "varChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Tb_EstatisticaCasa",
                columns: new[] { "IdEstatisticaCasa", "AtaquesperigososCasa", "CartoesAmareloCasa", "CartoesVermelhosCasa", "DefesaGoleiroCasa", "FaltasCasas", "GolsCasa", "InpedimentosCasa", "NomeTimeCasa", "PassesCompletosCasa", "PassesTotaisCasa", "TentativasGolsCasa", "chutesnoGolsCasa", "chutespraforaCasa", "escanteiosCasa" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, 0, 99, 0, "Palmeiras", 0, 0, 0, 0, 0, 0 },
                    { 2, 0, 0, 0, 0, 0, -31, 0, "Corinthians", 0, 0, 0, 0, 0, 0 },
                    { 3, 0, 0, 0, 0, 0, 2, 0, "Flamengo", 0, 0, 0, 0, 0, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa",
                table: "TB_Partidas",
                column: "IdEstatisticaCasa",
                principalTable: "Tb_EstatisticaCasa",
                principalColumn: "IdEstatisticaCasa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora",
                table: "TB_Partidas",
                column: "IdEstatisticaFora",
                principalTable: "Tb_EstatisticaFora",
                principalColumn: "IdEstatisticaFora",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
