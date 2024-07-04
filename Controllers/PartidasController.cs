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
        public Palpites GerarPalpites(Partidas partidas)
        {
            Palpites palpites = new Palpites();


            return palpites;

        }
        #endregion
    }
}