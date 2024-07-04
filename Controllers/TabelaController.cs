using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Data;
using PrevisionMax.Models;

namespace PrevisionMax.ConTrollers
{
    [ApiController]
    [Route("api/tabela")]
    public class TabelaController : ControllerBase
    {
        private readonly DataContext _context;

        public TabelaController(DataContext context)
        {

            _context = context;
        }


        #region Metodos Get

        [HttpGet("GetCampeonato/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                TabelaCampeonato tab = await _context.TB_TBCampeonato
                .FirstOrDefaultAsync(t => t.idCampeonato == id);
                if(tab == null)
                       throw new Exception("Não foi Encontrado um Campeonato com esse Id");


                return Ok(tab);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

         [HttpGet("GetCampeonatoNome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                List<TabelaCampeonato> tab = await _context.TB_TBCampeonato
                .Where(c => c.NomeCampeonato.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

                if(tab == null)
                       throw new Exception("Não foi Encontrado um Campeonato com esse Nome");


                return Ok(tab);
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
                List<TabelaCampeonato> lista = await _context.TB_TBCampeonato
                        .ToListAsync();

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
        public async Task<IActionResult> Add(TabelaCampeonato tb)
        {
            try
            {
                await _context.TB_TBCampeonato.AddAsync(tb);
                await _context.SaveChangesAsync();

                return Ok(tb.idCampeonato);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        #region Metodo Put

        [HttpPut]
        public async Task<IActionResult> Update(TabelaCampeonato tb)
        {
            try
            {
                _context.TB_TBCampeonato.Update(tb);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        #endregion


        #region  Metodos Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                TabelaCampeonato tbRemover = await _context
                .TB_TBCampeonato.FirstOrDefaultAsync(t => t.idCampeonato == id);
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