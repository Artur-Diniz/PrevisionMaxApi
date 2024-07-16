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

                    palpites.Add(palpite);


                }
                foreach (List<Palpites> i in palpites)
                {
                    foreach (var item in palpite)
                    {
                        await _context.TB_Palpites.AddAsync(item);
                    }
                  

                }



                await _context.SaveChangesAsync();

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
            EstatisticaTimes casa = await _context.Tb_EstatisticaTimes.FirstOrDefaultAsync(e => e.NomeTime == p.NomeTimeCasa);
            EstatisticaTimes fora = await _context.Tb_EstatisticaTimes.FirstOrDefaultAsync(e => e.NomeTime == p.NomeTimeFora);

            if (p.Campeonato != "Eurocopa" && p.Campeonato != "Copa América"
                    && p.Campeonato != "Copa Sul-Americana" && p.Campeonato != "Copa Libertadores"
                     && p.Campeonato != "Copa do Mundo" && p.Campeonato != "Liga dos Campeões")
            {
                Palpites under4 = await MetodoUnder4(casa, fora);
                if (under4.descricao != "")
                    palpites.Add(under4);
                Palpites Over2 = await MetodoOver2(casa, fora);
                 if (Over2.descricao != "")
                    palpites.Add(Over2);
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

                palpite.descricao = "Menos de 3.5 Gols para Essa Partida por Representarem" +
                " Baixa Media de Gols Esperadas para esse Partida";
            }
            return palpite;
        }

        private async Task<Palpites> MetodoOver2(EstatisticaTimes c, EstatisticaTimes f)
        {
            Palpites palpite = new Palpites();
            List<Partidas> casa = await _context.TB_Partidas.Where(e => e.NomeTimeCasa == c.NomeTime
            && e.TipoPartida == "CasaCasa").ToListAsync();

            List<Partidas> fora = await _context.TB_Partidas.Where(e => e.NomeTimeFora == c.NomeTime
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

            if (numOverGols4fora < 1 || numOverGols4Home < 1)
            { return palpite; }
            float mediacasa = c.GolMediasCF + c.GolsSofridosMediasCF;
            float mediafora = f.GolMediasCF + f.GolsSofridosMaiorCF;

            if (mediacasa < 1.6 && mediafora < 1.6)
            {
                return palpite;
            }

            float mediaGolsEsperados = mediacasa + mediafora;
            if (mediaGolsEsperados >= 3.8)
            {
                palpite.tipoAposta = TipoAposta.Gols;
                palpite.num = 1.5;

                palpite.descricao = "Mais de 1.5 Gols para Essa Partida por Representarem" +
                " Constante  Media de Gols Esperadas para esse Partida";
            }
            return palpite;
        }
        

        #endregion

    }

}