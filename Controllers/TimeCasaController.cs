using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/timecasa")]
    public class TimeCasaController : ControllerBase
    {

        private readonly DataContext _context;

        public TimeCasaController(DataContext context)
        {
            _context = context;
        }

        #region Metodos Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa
                .FirstOrDefaultAsync(t => t.IdEstatisticaCasa == id);
                if(casa == null)
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
                List<EstatisticaTimesCasa> lista = await _context.Tb_EstatisticaCasa.ToListAsync();
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
        public async Task<IActionResult> Add(EstatisticaTimesCasa casa)
        {
            try
            {
                await _context.Tb_EstatisticaCasa.AddAsync(casa);
                await _context.SaveChangesAsync();

                return Ok(casa.IdEstatisticaCasa);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        #endregion

        #region Metodos Put

        [HttpPut]
        public async Task<IActionResult> Update(EstatisticaTimesCasa casa)
        {
            try
            {
                _context.Tb_EstatisticaCasa.Update(casa);
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