using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/classificacao")]
    public class EstatisticaTabelaController : ControllerBase
    {
        private readonly DataContext _context;

        public EstatisticaTabelaController(DataContext context)
        {
            _context = context;
        }

        #region Metodos Get

        [HttpGet("GetEstaistica/{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                EstatisticaTabela estatisticaTabela = await _context.TB_EstatisticaTabela
                .FirstOrDefaultAsync(c => c.IdEstatisticaTabela == Id);

                if (estatisticaTabela == null)
                    throw new Exception("Não foi Encontrado uma estatistica Tabela com esse Id");

                return Ok(estatisticaTabela);
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
                List<EstatisticaTabela> lista = await _context.
                TB_EstatisticaTabela.ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region Metedos Post

        [HttpPost]
        public async Task<IActionResult> Add(EstatisticaTabela Tb)
        {
            try
            {
                await _context.TB_EstatisticaTabela.AddAsync(Tb);
                await _context.SaveChangesAsync();

                return Ok(Tb.IdEstatisticaTabela);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


        #region metodos Put

        [HttpPut]
        public async Task<IActionResult> update(EstatisticaTabela Tb)
        {
            try
            {
                _context.TB_EstatisticaTabela.Update(Tb);
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
                EstatisticaTabela cRemover = await _context
                .TB_EstatisticaTabela.FirstOrDefaultAsync(c => c.IdEstatisticaTabela == id);
                _context.TB_EstatisticaTabela.Remove(cRemover);

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