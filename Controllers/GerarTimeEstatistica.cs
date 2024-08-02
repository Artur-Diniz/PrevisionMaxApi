using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/EstatisticaTimes")]
    public class GerarTimesEstatisticaController : ControllerBase
    {
        private readonly DataContext _context;

        public GerarTimesEstatisticaController(DataContext context)
        {
            _context = context;

        }

        #region Metodos Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                EstatisticaTimes casa = await _context.Tb_EstatisticaTimes
                .FirstOrDefaultAsync(t => t.IdTime == id);
                if (casa == null)
                    throw new Exception("Não foi Encontrado um Time com esse Id");


                return Ok(casa);
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
                List<EstatisticaTimes> lista = await _context.Tb_EstatisticaTimes.ToListAsync();
                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeletarEstatisticas")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                List<EstatisticaTimes> estatisticaTimes = await _context.Tb_EstatisticaTimes.ToListAsync();
                foreach (var item in estatisticaTimes)
                {
                    _context.Tb_EstatisticaTimes.Remove(item);
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


    }
}