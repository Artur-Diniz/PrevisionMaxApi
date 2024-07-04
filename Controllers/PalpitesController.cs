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
                if(p == null)
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


                if(p == null)
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
                .Contains(Nome.ToLower())|| n.NomeTimeCasa.ToLower().Contains(Nome.ToLower()));
                
                
                if(p == null)
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
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

    }

}