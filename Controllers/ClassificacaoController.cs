using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/classificacao")]
    public class ClassificacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassificacaoController(DataContext context)
        {
            _context = context;
        }

        #region Metodos Get

        [HttpGet("GetClassificacao/{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                Classificacao classificacao = await _context.TB_Classificacao
                .FirstOrDefaultAsync(c => c.idClassficacao == Id);

                if (classificacao == null)
                    throw new Exception("Não foi Encontrado uma Classificacao com esse Id");

                return Ok(classificacao);
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
                List<Classificacao> lista = await _context.
                TB_Classificacao.ToListAsync();

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
        public async Task<IActionResult> Add(Classificacao cl)
        {
            try
            {
                await _context.TB_Classificacao.AddAsync(cl);
                await _context.SaveChangesAsync();

                return Ok(cl.idClassficacao);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


        #region metodos Put

        [HttpPut]
        public async Task<IActionResult> update(Classificacao cl)
        {
            try
            {
                _context.TB_Classificacao.Update(cl);
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
                Classificacao cRemover = await _context
                .TB_Classificacao.FirstOrDefaultAsync(c => c.idClassficacao == id);
                _context.TB_Classificacao.Remove(cRemover);

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