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

        #endregion
      

    }
}