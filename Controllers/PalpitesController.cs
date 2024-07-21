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

            if (p.Campeonato != "Eurocopa" && p.Campeonato != "Copa América"
                    && p.Campeonato != "Copa Sul-Americana" && p.Campeonato != "Copa Libertadores"
                     && p.Campeonato != "Copa do Mundo" && p.Campeonato != "Liga dos Campeões")
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
            }

            return palpites;
        }

        private async Task<Palpites> MetodoUnder4(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpite = new Palpites();
            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

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

            if (numOverGols4fora >= 3 || numOverGols4Home >= 3)
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
            float mediaGolsEsperados = c.GolMediasCF + f.GolMediasCF + c.GolsSofridosMediasCF + f.GolsSofridosMaiorCF;


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
            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
            && e.TipoPartida == "ForaFora").ToListAsync();

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
            foreach (var item in casa)
            {
                EstatisticaTimesFora home = await _context.Tb_EstatisticaFora
                      .FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);

                int mais4 = home.GolsFora + home.GolsSofridosFora;

                if (mais4 >= 2)
                    numOverGols4fora += 1;
            }

            if (numOverGols4fora < 0 || numOverGols4Home < 0)
            { return palpite; }
            float mediacasa = c.GolMediasCF + c.GolsSofridosMediasCF;
            float mediafora = f.GolMediasCF + f.GolsSofridosMaiorCF;

            if (mediacasa < 1.6 && mediafora < 1.6)
            {
                return palpite;
            }

            float mediaAtaque = c.GolMediasCF + f.GolMediasCF;
            if (c.GolMediasCF < 0.8 && f.GolMediasCF < 0.8)
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

            bool CasaMarca= false;
            if (c.GolMenorCF>0)
            {
                CasaMarca = true;
            }else
            {
                int golcasa = 0;
                if (c.GolMediasCF > 1.1)
                {
                    List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
               && e.TipoPartida == "CasaCasa").ToListAsync();

                    foreach (var item in casa)
                    {
                        EstatisticaTimesCasa home = await _context.Tb_EstatisticaCasa
                              .FirstOrDefaultAsync(e => e.IdEstatisticaCasa == item.IdEstatisticaCasa);
                        if (home.GolsCasa > 0)
                            golcasa++;
                    }
                    if (golcasa > 3)
                    {
                        CasaMarca = true;
                    }
                }

            }

            bool ForaMarca = false;
            if (f.GolMenorCF > 0)
            {
                ForaMarca = true;
            }
            else
            {
                int golfora = 0;
                if (f.GolMediasCF > 1.1)
                {
                    List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == f.NomeTime
                && e.TipoPartida == "ForaFora").ToListAsync();

                    foreach (var item in fora)
                    {
                        EstatisticaTimesFora home = await _context.Tb_EstatisticaFora
                              .FirstOrDefaultAsync(e => e.IdEstatisticaFora == item.IdEstatisticaFora);
                        if (home.GolsFora > 0)
                            golfora++;
                    }
                    if (golfora > 3)
                    {
                        ForaMarca = true;
                    }
                }

                
            }

            if (CasaMarca && ForaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 1.5;

                palpites.descricao = $"Ambas Marcam pela" +
                $" Constante  Media de Gols Esperadas para esse Partida entre {c.NomeTime} e {f.NomeTime} ";
            }else
            if (CasaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 0.5;

                palpites.descricao = $"Casa Marca pela" +
                $" Constante  Media de Gols Em Casa  na Partida entre {c.NomeTime} e {f.NomeTime} ";
            }else
            if (ForaMarca)
            {
                palpites.tipoAposta = TipoAposta.Gols;
                palpites.num = 0.5;

                palpites.descricao = $"Fora Marca pela" +
                $" Constante  Media de Gols Jogando Fora na Partida entre {c.NomeTime} e {f.NomeTime} ";
            }

            return palpites;
        }

        #endregion

    }

}