using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/Partidas")]
    public class PartidasController : ControllerBase
    {
        private readonly DataContext _context;

        public PartidasController(DataContext context)
        {
            _context = context;

        }

        #region Metodos Get

        [HttpGet("GetPartidas/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Partidas pt = await _context.TB_Partidas.FirstOrDefaultAsync(p => p.idPartida == id);

                if (pt == null)
                    throw new Exception("Não foi Encontrado uma Partida com esse Id");

                return Ok(pt);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPartidaByNomeTimes/{Nome}")]
        public async Task<IActionResult> GetPartidasByNomeTimes(string Nome)
        {
            try
            {
                List<Partidas> p = await _context.TB_Partidas.Where(n => n.NomeTimeCasa.ToLower().Contains(Nome.ToLower())
                || n.NomeTimeCasa.ToLower().Contains(Nome.ToLower()))
                .ToListAsync();




                if (p == null)
                    throw new Exception("Não foi Encontrado uma Palpite com esse Id");


                return Ok(p);
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
                List<Partidas> partidas = await _context.TB_Partidas.ToListAsync();

                return Ok(partidas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region Metedos Post
        [HttpPost]
        public async Task<IActionResult> Add(Partidas p)
        {
            try
            {
                await _context.TB_Partidas.AddAsync(p);



                await _context.SaveChangesAsync();
                return Ok(p.idPartida);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region metodos Put

        [HttpPut]
        public async Task<IActionResult> Update(Partidas p)
        {
            try
            {
                _context.TB_Partidas.Update(p);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region Metodos Delete

        [HttpDelete("id")]
        public async Task<IActionResult> Delte(int id)
        {
            try
            {
                Partidas pRemover = await _context.TB_Partidas
                .FirstOrDefaultAsync(p => p.idPartida == id);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region  Metodos Gerar Palpites
        public Palpites GerarPalpitesAsync(Partidas partidas)
        {
            Palpites palpites = new Palpites();


            return palpites;

        }


        #endregion

        #region Gerar EstatisticasTimes
        public async Task<EstatisticaTimes> GerarEsatisticaGeralAsync(Partidas partidas)
        {
            EstatisticaTimes estatistica = new EstatisticaTimes();

             List<EstatisticaTimesCasa> listacasa = await _context.Tb_EstatisticaCasa.Where(c => c.NomeTimeCasa == partidas.NomeTimeCasa|| c.NomeTimeCasa == partidas.NomeTimeFora).ToListAsync();

                if (listacasa.Any())
                {
                    estatistica.GolMedias = (float)listacasa.Average(c => c.GolsCasa);
                    estatistica.GolMaior = listacasa.Max(c => c.GolsCasa);
                    estatistica.GolMenor = listacasa.Min(c => c.GolsCasa);

                    estatistica.GolsSofridosMedias = (float)listacasa.Average(c => c.GolsSofridosCasa);
                    estatistica.GolsSofridosMaior = listacasa.Max(c => c.GolsSofridosCasa);
                    estatistica.GolsSofridosMenor = listacasa.Min(c => c.GolsSofridosCasa);

                    estatistica.TentativasGolsMedias = (float)listacasa.Average(c => c.TentativasGolsCasa);
                    estatistica.TentativasGolsMaior = listacasa.Max(c => c.TentativasGolsCasa);
                    estatistica.TentativasGolsMenor = listacasa.Min(c => c.TentativasGolsCasa);

                    estatistica.chutesnoGolsMedia = (float)listacasa.Average(c => c.chutesnoGolsCasa);
                    estatistica.chutesnoGolsMaior = (int)listacasa.Max(c => c.chutesnoGolsCasa);
                    estatistica.chutesnoGolsMenor = (int)listacasa.Min(c => c.chutesnoGolsCasa);

                    estatistica.chutespraforaMedia = (float)listacasa.Average(c => c.chutesnoGolsCasa);
                    estatistica.chutespraforaMaior = (int)listacasa.Max(c => c.chutesnoGolsCasa);
                    estatistica.chutespraforaMenor = (int)listacasa.Min(c => c.chutesnoGolsCasa);

                    estatistica.escanteiosMedia = (float)listacasa.Average(c => c.escanteiosCasa);
                    estatistica.escanteiosMaior = (int)listacasa.Max(c => c.escanteiosCasa);
                    estatistica.escanteiosMenor = (int)listacasa.Min(c => c.escanteiosCasa);

                    estatistica.InpedimentosMedia = (float)listacasa.Average(c => c.InpedimentosCasa);
                    estatistica.InpedimentosMaior = (int)listacasa.Max(c => c.InpedimentosCasa);
                    estatistica.InpedimentosMenor = (int)listacasa.Min(c => c.InpedimentosCasa);

                    estatistica.DefesaGoleiroMedia = (float)listacasa.Average(c => c.DefesaGoleiroCasa);
                    estatistica.DefesaGoleiroMaior = (int)listacasa.Max(c => c.DefesaGoleiroCasa);
                    estatistica.DefesaGoleiroMenor = (int)listacasa.Min(c => c.DefesaGoleiroCasa);

                    estatistica.FaltasMedia = (float)listacasa.Average(c => c.FaltasCasas);
                    estatistica.FaltasMaior = listacasa.Max(c => c.FaltasCasas);
                    estatistica.FaltasMenor = listacasa.Min(c => c.FaltasCasas);

                    estatistica.CartoesAmareloMedia = (float)listacasa.Average(c => c.CartoesAmareloCasa);
                    estatistica.CartoesAmareloMaior = (int)listacasa.Max(c => c.CartoesAmareloCasa);
                    estatistica.CartoesAmareloMenor = (int)listacasa.Min(c => c.CartoesAmareloCasa);

                    estatistica.PassesTotaisMedia = (float)listacasa.Average(c => c.PassesTotaisCasa);
                    estatistica.PassesTotaisMaior = listacasa.Max(c => c.PassesTotaisCasa);
                    estatistica.PassesTotaisMenor = listacasa.Min(c => c.PassesTotaisCasa);

                    estatistica.PassesCompletosMedia = (float)listacasa.Average(c => c.PassesCompletosCasa);
                    estatistica.PassesCompletosMaior = listacasa.Max(c => c.PassesCompletosCasa);
                    estatistica.PassesCompletosMenor = listacasa.Min(c => c.PassesCompletosCasa);

                    estatistica.AtaquesperigososMedia = (float)listacasa.Average(c => c.AtaquesperigososCasa);
                }


            return estatistica;       
        }
        #endregion

    }
}