using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/palpites")]
    public class PalpitesController : ControllerBase
    {
        private readonly DataContext _context;

        public PalpitesController(DataContext context)
        {
            _context = context;

        }

        #region Metedos Get

        [HttpGet("GetPalPites/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Palpites p = await _context.TB_Palpites
                .FirstOrDefaultAsync(p => p.idPalpites == id);
                if (p == null)
                    throw new Exception("Não foi Encontrado uma Palpite com esse Id");


                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPalPitesByPartidaId/{id}")]
        public async Task<IActionResult> GetIdByPartidas(int id)
        {
            try
            {
                List<Palpites> p = await _context.TB_Palpites
                .Where(i => i.idPartida == id).ToListAsync();


                if (p == null)
                    throw new Exception("Não foi Encontrado palpites para essa partida");


                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPalPitesByPartidaByNomeTimes/{Nome}")]
        public async Task<IActionResult> GetPartidasByNomeTimes(string Nome)
        {
            try
            {
                Partidas p = await _context.TB_Partidas.FirstOrDefaultAsync(n => n.NomeTimeCasa.ToLower()
                .Contains(Nome.ToLower()) || n.NomeTimeCasa.ToLower().Contains(Nome.ToLower()));


                if (p == null)
                    throw new Exception("Não foi Encontrado uma Palpite com esse Id");

                List<Palpites> palpites = await _context.TB_Palpites
               .Where(i => i.idPartida == p.idPartida).ToListAsync();


                return Ok(palpites);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Palpites> palpites = await _context.TB_Palpites.ToListAsync();

                return Ok(palpites);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Metodos Post

        [HttpPost]
        public async Task<IActionResult> Add(Palpites p)
        {
            try
            {
                await _context.TB_Palpites.AddAsync(p);
                await _context.SaveChangesAsync();

                return Ok(p.idPalpites);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        #endregion

        #region Metodos Put

        [HttpPut]
        public async Task<IActionResult> Update(Palpites palpites)
        {
            try
            {

                _context.TB_Palpites.Update(palpites);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region metodos Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Palpites pRemover = await _context.TB_Palpites
                .FirstOrDefaultAsync(p => p.idPalpites == id);
                _context.TB_Palpites.Remove(pRemover);

                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteAllPalpites")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                List<Palpites> palpites = await _context.TB_Palpites.ToListAsync();
                foreach (var item in palpites)
                {
                    _context.TB_Palpites.Remove(item);
                }

                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


        #region GerarPalpites

        [HttpPost("GerarPalpites")]
        public async Task<IActionResult> GerarPalpites()
        {
            try
            {
                List<Partidas> partidas = await _context.TB_Partidas.Where(p => p.PartidaAnalise == true).ToListAsync();

                List<List<Palpites>> palpites = new List<List<Palpites>>();

                List<Palpites> palpite = new List<Palpites>();

                foreach (var item in partidas)
                {

                    palpite = await MetodosPalpites(item);

                    if (palpite.Count != 0)
                        palpites.Add(palpite);


                }

                return Ok(palpites);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<List<Palpites>> MetodosPalpites(Partidas p)
        {
            List<Palpites> palpites = new List<Palpites>();
            string casaSemParenteses = RemoveParenteses(p.NomeTimeCasa);
            string foraSemParenteses = RemoveParenteses(p.NomeTimeFora);
            p.NomeTimeFora = foraSemParenteses;
            p.NomeTimeCasa = casaSemParenteses;
            EstatisticaTimes casa = await _context.Tb_EstatisticaTimes.FirstOrDefaultAsync(e => e.NomeTime == p.NomeTimeCasa);
            EstatisticaTimes fora = await _context.Tb_EstatisticaTimes.FirstOrDefaultAsync(e => e.NomeTime == p.NomeTimeFora);

            if (p.Campeonato != "Eurocopa" && p.Campeonato != "Copa America"
                    && p.Campeonato != "Copa Sul-Americana" && p.Campeonato != "Copa Libertadores"
                     && p.Campeonato != "Copa do Mundo" && p.Campeonato != "Liga dos Campeoes")
            {
                    Palpites under4 = await MetodoUnder4(casa, fora);
                    if (under4.descricao != "")
                    {
                        under4.idPartida = p.idPartida;
                        palpites.Add(under4);
                        await _context.TB_Palpites.AddAsync(under4);
                        await _context.SaveChangesAsync();
                    }
                    Palpites Over2 = await MetodoOver2(casa, fora);
                    if (Over2.descricao != "")
                    {
                        Over2.idPartida = p.idPartida;
                        palpites.Add(Over2);
                        await _context.TB_Palpites.AddAsync(Over2);
                        await _context.SaveChangesAsync();
                    }
                    Palpites Over1Gol = await GolTime(casa, fora);
                    if (Over1Gol.descricao != "")
                    {
                        Over1Gol.idPartida = p.idPartida;
                        palpites.Add(Over1Gol);
                        await _context.TB_Palpites.AddAsync(Over1Gol);
                        await _context.SaveChangesAsync();
                    }
                    Palpites underCantos = await UnderCantos(casa, fora);
                    if (underCantos.descricao != "")
                    {
                        underCantos.idPartida = p.idPartida;
                        palpites.Add(underCantos);
                        await _context.TB_Palpites.AddAsync(underCantos);
                        await _context.SaveChangesAsync();
                    }
                    Palpites overcantos = await OverCantos(casa, fora);
                    if (overcantos.descricao != "")
                    {
                        overcantos.idPartida = p.idPartida;
                        palpites.Add(overcantos);
                        await _context.TB_Palpites.AddAsync(overcantos);
                        await _context.SaveChangesAsync();
                    }
                    Palpites underCartao = await UnderCartao(casa, fora);
                    if (underCartao.descricao != "")
                    {
                        underCartao.idPartida = p.idPartida;
                        palpites.Add(underCartao);
                        await _context.TB_Palpites.AddAsync(underCartao);
                        await _context.SaveChangesAsync();
                    }
                    Palpites overcartao = await OverCartao(casa, fora);
                    if (overcartao.descricao != "")
                    {
                        overcartao.idPartida = p.idPartida;
                        palpites.Add(overcartao);
                        await _context.TB_Palpites.AddAsync(overcartao);
                        await _context.SaveChangesAsync();
                    }
                Palpites vitoriaEmpate = await Winner(casa, fora);
                if (vitoriaEmpate.descricao != "")
                {
                    vitoriaEmpate.idPartida = p.idPartida;
                    palpites.Add(vitoriaEmpate);
                    await _context.TB_Palpites.AddAsync(vitoriaEmpate);
                    await _context.SaveChangesAsync();
                }
            }

            return palpites;
        }

        private async Task<Palpites> MetodoUnder4(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpite = new Palpites();

            if (c == null || f == null)
            {
                return palpite;
            }
            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

            if (casa.Count < 3 && fora.Count < 3)
            {
                return palpite;
            }

            int numOverGols4Home = 0;
            foreach (var item in casa)
            {
                EstatisticaTimesCasa home = await _context.Tb_EstatisticaCasa
                      .FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);
                int mais4 = home.GolsCasa + home.GolsSofridosCasa;

                if (mais4 >= 4)
                    numOverGols4Home = +1;
            }

            int numOverGols4fora = 0;
            foreach (var item in fora)
            {
                EstatisticaTimesFora home = await _context.Tb_EstatisticaFora
                      .FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                int mais4 = home.GolsFora + home.GolsSofridosFora;

                if (mais4 >= 4)
                    numOverGols4fora += 1;
            }

            if (numOverGols4fora > 1 || numOverGols4Home > 1)
            { return palpite; }

            if (c.GolMediasCF <= 2.4 && f.GolMediasCF <= 2.4 && c.GolsSofridosMediasCF <= 2.0 && f.GolsSofridosMediasCF <= 2)
            {
                int medidor = 0;
                if (c.GolMediasCF > 1.6)
                    medidor += 1;
                if (f.GolMediasCF > 1.6)
                    medidor += 1;
                if (c.GolsSofridosMediasCF > 1.2)
                    medidor += 1;
                if (f.GolsSofridosMediasCF > 1.2)
                    medidor += 1;

                if (medidor > 1)
                    return palpite;
            }
            float mediaGolsEsperados = c.GolMediasCF + f.GolMediasCF + c.GolsSofridosMediasCF + f.GolsSofridosMediasCF;


            if (mediaGolsEsperados <= 4.2)
            {
                palpite.tipoAposta = TipoAposta.Gols;
                palpite.num = 3.5;

                palpite.descricao = $"Menos de 3.5 Gols para Essa Partida por Representarem" +
                $" uma espectativa de Gols abaixo de 4 gols Esperadas para esse Partida entre {c.NomeTime} e {f.NomeTime} ";
            }
            return palpite;
        }

        private async Task<Palpites> MetodoOver2(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpite = new Palpites();

            if (c == null || f == null)
            {
                return palpite;
            }
            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

            if (casa.Count < 3 && fora.Count < 3)
            {
                return palpite;
            }

            int numOverGols4Home = 0;
            foreach (var item in casa)
            {
                EstatisticaTimesCasa home = await _context.Tb_EstatisticaCasa
                      .FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);
                int mais4 = home.GolsCasa + home.GolsSofridosCasa;

                if (mais4 >= 2)
                    numOverGols4Home = +1;
            }

            int numOverGols4fora = 0;
            foreach (var item in fora)
            {
                EstatisticaTimesFora home = await _context.Tb_EstatisticaFora
                      .FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                int mais4 = home.GolsFora + home.GolsSofridosFora;

                if (mais4 >= 2)
                    numOverGols4fora += 1;
            }

            if (numOverGols4fora < 1 || numOverGols4Home < 1)
            { return palpite; }


            float mediacasa = c.GolMediasCF + c.GolsSofridosMediasCF;
            float mediafora = f.GolMediasCF + f.GolsSofridosMaiorCF;

            if (mediacasa < 1.6 && mediafora < 1.6)
            {
                return palpite;
            }

            float mediaAtaque = c.GolMediasCF + f.GolMediasCF;
            if (c.GolMediasCF < 0.8 || f.GolMediasCF < 0.8)
            {
                return palpite;
            }

            if (mediaAtaque < 2.2)
                return palpite;


            float mediaGolsEsperados = mediacasa + mediafora;
            if (mediaGolsEsperados >= 3.8)
            {
                palpite.tipoAposta = TipoAposta.Gols;
                palpite.num = 1.5;

                palpite.descricao = $"Mais de 1.5 Gols para Essa Partida por Representarem" +
                $" Constante  Media de Gols Esperadas para esse Partida entre {c.NomeTime} e {f.NomeTime} ";
            }
            return palpite;
        }

        private static string RemoveParenteses(string input)
        {
            while (input.Contains("(") && input.Contains(")"))
            {
                int startIndex = input.IndexOf("(");
                int endIndex = input.IndexOf(")", startIndex) + 1;
                if (startIndex >= 0 && endIndex > startIndex)
                {
                    input = input.Remove(startIndex, endIndex - startIndex).Trim();
                }
            }
            return input;
        }

        private async Task<Palpites> GolTime(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }

            bool CasaMarca = false;

            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
             && e.TipoPartida == "CasaCasa").ToListAsync();

            bool ForaMarca = false;
            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

            if (casa.Count < 3 && fora.Count < 3)
            {
                return palpites;
            }

            int golcasa = 0, golsofridoCasa = 0;
            foreach (var item in casa)
            {
                EstatisticaTimesCasa home = await _context.Tb_EstatisticaCasa
                      .FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);
                if (home.GolsCasa > 0)
                    golcasa++;

                if (home.GolsSofridosCasa > 0)
                    golsofridoCasa++;
            }

            int golfora = 0, golssofridosfora = 0;
            foreach (var item in fora)
            {
                EstatisticaTimesFora home = await _context.Tb_EstatisticaFora
                      .FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);
                if (home.GolsFora > 0)
                    golfora++;

                if (home.GolsSofridosFora > 0)
                    golssofridosfora++;
            }

            if (golcasa > 3 && golssofridosfora > 2)
            {
                if (c.GolMediasCF > 1.15)
                {
                    CasaMarca = true;
                }
                if (c.GolMenorCF > 0)
                {
                    CasaMarca = true;
                }
            }
            if (golfora > 3 && golsofridoCasa > 2)
            {
                if (f.GolMediasCF > 1.15)
                {
                    ForaMarca = true;
                }
                if (f.GolMenorCF > 0)
                {
                    ForaMarca = true;
                }
            }

            if (CasaMarca && ForaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 1.5;

                palpites.descricao = $"Ambas Marcam pela" +
                $" Constante  Media de Gols Esperadas para esse Partida entre {c.NomeTime} e {f.NomeTime} ";
            }
            else
            if (CasaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 0.5;

                palpites.descricao = $"Casa Marca pela" +
                $" Constante  Media de Gols Em Casa  na Partida entre {c.NomeTime} e {f.NomeTime} ";
            }
            else
            if (ForaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 0.5;

                palpites.descricao = $"Fora Marca pela" +
                $" Constante  Media de Gols Jogando Fora na Partida entre {c.NomeTime} e {f.NomeTime} ";
            }

            return palpites;
        }


        private async Task<Palpites> UnderCantos(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }

            if (c.escanteiosMediaCF < 7 && f.escanteiosMediaCF < 7)
            {
                List<Partidas> confrontos = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == f.NomeTime || e.NomeTimeCasa == f.NomeTime
            && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == c.NomeTime).ToListAsync();

                int underescateios = 0;
                if (confrontos.Count > 2)
                {
                    foreach (var item in confrontos)
                    {
                        EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);

                        EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                        int CastosTotal = (int)casa.escanteiosCasa + (int)fora.escanteiosFora;

                        if (CastosTotal < 11)
                            underescateios++;
                    }
                }

                bool escanteios = false;
                if (underescateios > 2 && confrontos.Count == 3)
                    escanteios = true;
                if (underescateios > 2 && confrontos.Count == 4)
                    escanteios = true;
                if (underescateios > 3 && confrontos.Count == 5)
                    escanteios = true;

                if (escanteios)
                {
                    palpites.tipoAposta = TipoAposta.Escanteios;
                    palpites.num = 12.5;

                    palpites.descricao = $"Under 12.5" +
                 $" os confronstos entre {c.NomeTime} e {f.NomeTime} apresentaram media baixa de escanteios entre " +
                 $" alem de apresentarem uma baixa media em suas partidas";

                }
            }
            return palpites;
        }


        private async Task<Palpites> OverCantos(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }
            bool escanteios = false;

            if (c.escanteiosMediaCF < 5 && f.escanteiosMediaCF < 5)
            {
                List<Partidas> confrontos = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == f.NomeTime || e.NomeTimeCasa == f.NomeTime
            && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == c.NomeTime).ToListAsync();

                int underescateios = 0;
                if (confrontos.Count > 2)
                {
                    foreach (var item in confrontos)
                    {
                        EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);

                        EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                        int CastosTotal = (int)casa.escanteiosCasa + (int)fora.escanteiosFora;

                        if (CastosTotal > 10)
                            underescateios++;
                    }
                }

                if (underescateios > 2 && confrontos.Count == 3)
                    escanteios = true;
                if (underescateios > 2 && confrontos.Count == 4)
                    escanteios = true;
                if (underescateios > 3 && confrontos.Count == 5)
                    escanteios = true;


            }
            if (escanteios)
            {
                palpites.tipoAposta = TipoAposta.Escanteios;
                palpites.num = 9.5;

                palpites.descricao = $"over 9.5" +
                $" os confronstos entre {c.NomeTime} e {f.NomeTime} apresentaram Alta media de escanteios " +
                $" alem de apresentarem uma media alta em suas partidas";
            }
            return palpites;
        }


        private async Task<Palpites> OverCartao(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }

            float cartoesmediacasa = c.CartoesAmareloMediaCF + c.CartoesAmareloMediaSofridosCF;
            float cartoesmediafora = f.CartoesAmareloMediaCF + f.CartoesAmareloMediaSofridosCF;
            bool palpite = false;

            if (cartoesmediacasa > 4 && cartoesmediafora > 4)
            {
                List<Partidas> confrontos = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
          && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == f.NomeTime || e.NomeTimeCasa == f.NomeTime
          && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == c.NomeTime).ToListAsync();


                int overCartao = 0;
                foreach (var item in confrontos)
                {
                    EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);

                    EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                    int cartoestotal = (int)casa.CartoesAmareloCasa + (int)fora.CartoesAmareloFora;
                    if (cartoestotal > 4)
                        overCartao++;
                }

                if (confrontos.Count == 5 && overCartao > 3)
                    palpite = true;
                if (confrontos.Count == 4 && overCartao > 2)
                    palpite = true;
                if (confrontos.Count == 3 && overCartao > 1)
                    palpite = true;
                if (confrontos.Count == 2 && overCartao > 1)
                    palpite = true;

            }
            if (palpite)
            {
                palpites.tipoAposta = TipoAposta.CartõesAmarelo;
                palpites.num = 3.5;

                palpites.descricao = $"over 3.5 cartoes para essa partida ," +
                $" os confronstos entre {c.NomeTime} e {f.NomeTime} apresentaram Alta media de cartoes " +
                $" alem de uma media alta de cartoes nos jogos";
            }


            return palpites;

        }


        private async Task<Palpites> UnderCartao(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }

            float cartoesmediacasa = c.CartoesAmareloMediaCF + c.CartoesAmareloMediaSofridosCF;
            float cartoesmediafora = f.CartoesAmareloMediaCF + f.CartoesAmareloMediaSofridosCF;
            bool palpite = false;

            if (cartoesmediacasa < 4 && cartoesmediafora < 4)
            {
                List<Partidas> confrontos = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
          && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == f.NomeTime || e.NomeTimeCasa == f.NomeTime
          && e.TipoPartida == "ConfrontoDireto" && e.NomeTimeFora == c.NomeTime).ToListAsync();


                int UnderCartao = 0;
                foreach (var item in confrontos)
                {
                    EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);

                    EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                    int cartoestotal = (int)casa.CartoesAmareloCasa + (int)fora.CartoesAmareloFora;
                    if (cartoestotal < 4)
                        UnderCartao++;
                }

                if (confrontos.Count == 5 && UnderCartao > 3)
                    palpite = true;
                if (confrontos.Count == 4 && UnderCartao > 2)
                    palpite = true;
                if (confrontos.Count == 3 && UnderCartao > 1)
                    if (confrontos.Count == 2 && UnderCartao > 1)
                        palpite = true;


            }


            if (palpite)
            {
                palpites.tipoAposta = TipoAposta.CartõesAmarelo;
                palpites.num = 5.5;

                palpites.descricao = $"Under 5.5 cartoes para essa partida ," +
               $" os confronstos entre {c.NomeTime} e {f.NomeTime} apresentaram baixa media de cartoes " +
               $" alem de uma baixa media de cartoes";
            }

            return palpites;

        }


        private async Task<Palpites> Winner(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpites = new Palpites();

            if (c == null || f == null)
            {
                return palpites;
            }


            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

            if (casa.Count < 3 || fora.Count < 3)
            {
                return palpites;
            }

            int golsSemGolCasa = 0,aprovetamentocasaWin=0, vitoraempatecasa=0;
            foreach (var item in casa)
            {
                EstatisticaTimesCasa ca = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);
               
                if (ca.GolsSofridosCasa < 0.5)
                    golsSemGolCasa++;

                if (ca.GolsCasa > ca.GolsSofridosCasa)
                {
                    aprovetamentocasaWin++;
                    vitoraempatecasa++;
                }
                else if (ca.GolsCasa >= ca.GolsSofridosCasa)
                    vitoraempatecasa++;

            }

            double porcentegemWinRateCasa = Porcentagemcount(aprovetamentocasaWin, casa.Count);
            double vitoraempatecasaDWRateCasa = Porcentagemcount(vitoraempatecasa, casa.Count);
            double porcentagemCasa = Porcentagemcount(golsSemGolCasa,casa.Count);

            float precisaoCasa = c.PassesCompletosMediaCF / c.PassesTotaisMaiorCF;

            float posseCasa = (float)c.PossedeBolaMediaCF / 100;

            float chancedeVitoriaCasa = (float)(posseCasa * 0.25 + precisaoCasa * 0.25 + c.GolMediasCF * 0.25 + porcentagemCasa * 0.25);

            int golsSemGolFora = 0,aproveitamentoWinfora=0,vitoriaemaptefora=0;
            foreach (var item in fora)
            {
                EstatisticaTimesFora fo = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                if (fo.GolsSofridosFora < 0.5)
                    golsSemGolFora++;

                if (fo.GolsFora > fo.GolsSofridosFora)
                {
                    aproveitamentoWinfora++;
                    vitoriaemaptefora++;
                }
                else if (fo.GolsFora >= fo.GolsSofridosFora)
                    vitoriaemaptefora++;

            }

            double porcentegemWinRateFora = Porcentagemcount(aproveitamentoWinfora, casa.Count);
            double vitoraempatecasaDWRateFora = Porcentagemcount(vitoriaemaptefora, casa.Count);

            double porcentagemFora = Porcentagemcount(golsSemGolFora , fora.Count);
            float precisaoFora = c.PassesCompletosMediaCF / c.PassesTotaisMaiorCF;

            float posseFora = (float)f.PossedeBolaMediaCF / 100;

            float chancedeVitoriaFora = (float)(posseFora * 0.25 + precisaoFora * 0.25 + f.GolMediasCF * 0.25 + porcentagemFora * 0.25);

            float Partida = chancedeVitoriaFora + chancedeVitoriaCasa;

            float VitoriaCasa = (chancedeVitoriaCasa / Partida)*100;
            float VitoriaFora = (chancedeVitoriaFora / Partida)*100;

            float DiferençaWin = VitoriaCasa - VitoriaFora;

            if (DiferençaWin > 10 && vitoraempatecasaDWRateCasa>=0.70)
            {
                if (DiferençaWin < 24.99 && aprovetamentocasaWin>=0.60)
                {
                    palpites.tipoAposta = TipoAposta.CasaVence;
                    palpites.num = 0;

                    palpites.descricao = $"Casa Vitoria Empate" +
                   $" o Mandante {c.NomeTime} tem se mostrar um adversário melhor em comparação ao {f.NomeTime}, tendo tendencia Maior de vitoria o Mandante";

                }
                else
                {
                    palpites.tipoAposta = TipoAposta.CasaVence;
                    palpites.num = 0;

                    palpites.descricao = $"Casa Vitoria " +
                   $"o Mandante {c.NomeTime} tem se mostrar um adversário Superior em comparação ao {f.NomeTime}, tendo tendencia Maior de vitoria o Mandante";

                }

            }
            if (DiferençaWin < -10 && vitoraempatecasaDWRateFora>=0.70 )
            {
                if (DiferençaWin > -24.99 && aproveitamentoWinfora >= 0.60)
                {
                    palpites.tipoAposta = TipoAposta.ForaVence;
                    palpites.num = 0;

                    palpites.descricao = $"Fora Vitoria Empate " +
                   $"o Mandante {c.NomeTime} tem se mostrar um adversário Fraco em comparação ao {f.NomeTime}, tendo tendencia Maior de vitoria  o Visitante";

                }
                else
                {
                    palpites.tipoAposta = TipoAposta.ForaVence;
                    palpites.num = 0;

                    palpites.descricao = $"Fora Vitoria " +
                   $"o Mandante {c.NomeTime} tem se mostrar um adversário Fraco em comparação ao {f.NomeTime}, tendo tendencia Maior de vitoria o Visitante";

                }
            }




            return palpites;

        }

        private static double Porcentagemcount(int ocorrencia, int total)
        {
            double input = 0;
            if (total == 5)
            {
                if (ocorrencia == 5)
                    input = 1;
                else if (ocorrencia == 4)
                    input = 0.8;
                else if (ocorrencia == 3)
                    input = 0.6;
                else if (ocorrencia == 2)
                    input = 0.4;
                else if (ocorrencia == 1)
                    input = 0.2;
            }
            else if (total == 4)
            {
                if (ocorrencia == 4)
                    input = 1;
                else if (ocorrencia == 3)
                    input = 0.75;
                else if (ocorrencia == 2)
                    input = 0.5;
                else if (ocorrencia == 1)
                    input = 0.25;
            }
            else if (total == 3)
            {
                if (ocorrencia == 3)
                    input = 1;
                else if (ocorrencia == 2)
                    input = 0.66;
                else if (ocorrencia == 1)
                    input = 0.33;
            }

            return input;
        }




        #endregion

    }
}

