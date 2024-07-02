using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaCampeonatoAndClassificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Classificacao",
                columns: table => new
                {
                    idClassficacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicaoTime = table.Column<int>(type: "int", nullable: false),
                    NomeTime = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    numJogos = table.Column<int>(type: "int", nullable: false),
                    numVitorias = table.Column<int>(type: "int", nullable: false),
                    numEmpates = table.Column<int>(type: "int", nullable: false),
                    numDerrotas = table.Column<int>(type: "int", nullable: false),
                    GolsFeitos = table.Column<int>(type: "int", nullable: false),
                    GolsSofridos = table.Column<int>(type: "int", nullable: false),
                    Pontos = table.Column<int>(type: "int", nullable: false),
                    ultiomojogos1 = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    ultiomojogos2 = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    ultiomojogos3 = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    ultiomojogos4 = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    ultiomojogos5 = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Classificacao", x => x.idClassficacao);
                });

            migrationBuilder.CreateTable(
                name: "Tb_EstatisticaFora",
                columns: table => new
                {
                    IdEstatisticaFora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTimeFora = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    GolsFora = table.Column<int>(type: "int", nullable: false),
                    TentativasGolsFora = table.Column<int>(type: "int", nullable: false),
                    chutesnoGolsFora = table.Column<int>(type: "int", nullable: false),
                    chutespraforaFora = table.Column<int>(type: "int", nullable: false),
                    escanteiosFora = table.Column<int>(type: "int", nullable: false),
                    InpedimentosFora = table.Column<int>(type: "int", nullable: false),
                    DefesaGoleiroFora = table.Column<int>(type: "int", nullable: false),
                    FaltasForas = table.Column<int>(type: "int", nullable: false),
                    CartoesVermelhosFora = table.Column<int>(type: "int", nullable: false),
                    CartoesAmareloFora = table.Column<int>(type: "int", nullable: false),
                    PassesTotaisFora = table.Column<int>(type: "int", nullable: false),
                    PassesCompletosFora = table.Column<int>(type: "int", nullable: false),
                    AtaquesperigososFora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_EstatisticaFora", x => x.IdEstatisticaFora);
                });

            migrationBuilder.CreateTable(
                name: "TB_TBCampeonato",
                columns: table => new
                {
                    idCampeonato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCampeonato = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassificacaoIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TBCampeonato", x => x.idCampeonato);
                });

            migrationBuilder.CreateTable(
                name: "TB_Partidas",
                columns: table => new
                {
                    idPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTimeCasa = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    NomeTimeFora = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Campeonato = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false),
                    IdEstatisticaCasa = table.Column<int>(type: "int", nullable: false),
                    IdEstatisticaFora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Partidas", x => x.idPartida);
                    table.ForeignKey(
                        name: "FK_TB_Partidas_Tb_EstatisticaCasa_IdEstatisticaCasa",
                        column: x => x.IdEstatisticaCasa,
                        principalTable: "Tb_EstatisticaCasa",
                        principalColumn: "IdEstatisticaCasa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Partidas_Tb_EstatisticaFora_IdEstatisticaFora",
                        column: x => x.IdEstatisticaFora,
                        principalTable: "Tb_EstatisticaFora",
                        principalColumn: "IdEstatisticaFora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Palpites",
                columns: table => new
                {
                    idPalpites = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPartida = table.Column<int>(type: "int", nullable: false),
                    tipoAposta = table.Column<int>(type: "int", nullable: false),
                    num = table.Column<double>(type: "float", nullable: true),
                    descricao = table.Column<string>(type: "varChar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Palpites", x => x.idPalpites);
                    table.ForeignKey(
                        name: "FK_TB_Palpites_TB_Partidas_idPartida",
                        column: x => x.idPartida,
                        principalTable: "TB_Partidas",
                        principalColumn: "idPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tb_EstatisticaCasa",
                keyColumn: "IdEstatisticaCasa",
                keyValue: 2,
                column: "NomeTimeCasa",
                value: "Corinthians");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Palpites_idPartida",
                table: "TB_Palpites",
                column: "idPartida");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Partidas_IdEstatisticaCasa",
                table: "TB_Partidas",
                column: "IdEstatisticaCasa");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Partidas_IdEstatisticaFora",
                table: "TB_Partidas",
                column: "IdEstatisticaFora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Classificacao");

            migrationBuilder.DropTable(
                name: "TB_Palpites");

            migrationBuilder.DropTable(
                name: "TB_TBCampeonato");

            migrationBuilder.DropTable(
                name: "TB_Partidas");

            migrationBuilder.DropTable(
                name: "Tb_EstatisticaFora");

            migrationBuilder.UpdateData(
                table: "Tb_EstatisticaCasa",
                keyColumn: "IdEstatisticaCasa",
                keyValue: 2,
                column: "NomeTimeCasa",
                value: "Cortinas");
        }
    }
}
