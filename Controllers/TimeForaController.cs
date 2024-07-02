using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("Controller")]
    public class TimeForaController : ControllerBase
    {

        private readonly DataContext _context;

        public TimeForaController(DataContext context)
        { 
            _context = context;
        }
        
          #region Metodos Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora
                .FirstOrDefaultAsync(t => t.IdEstatisticaFora == id);

                return Ok(fora);
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
                List<EstatisticaTimesFora> lista = await _context.Tb_EstatisticaFora.ToListAsync();
                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


        #region Metodos Post

        [HttpPost]
        public async Task<IActionResult> Add(EstatisticaTimesFora fora)
        {
            try
            {
                await _context.Tb_EstatisticaFora.AddAsync(fora);
                await _context.SaveChangesAsync();

                return Ok(fora.IdEstatisticaFora);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        #endregion

        
        #region Metodos Put

        [HttpPut]
        public async Task<IActionResult> Update(EstatisticaTimesFora fora)
        {
            try
            {
                _context.Tb_EstatisticaFora.Update(fora);
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
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EstatisticaTimesCasa CasaRemover = await _context.Tb_EstatisticaCasa
                .FirstOrDefaultAsync(c => c.IdEstatisticaCasa == id);
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