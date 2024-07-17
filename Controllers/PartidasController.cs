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
                || n.NomeTimeFora.ToLower().Contains(Nome.ToLower()))
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
        public async Task<IActionResult> Add(Partidas Partida)
        {
            try
            {
                if (Partida == null)
                {
                    return BadRequest("Partida is null.");
                }
                if (Partida.IdEstatisticaCasa == 0)
                    Partida.IdEstatisticaCasa = 4;
                if (Partida.IdEstatisticaFora == 0)
                    Partida.IdEstatisticaFora = 1;

                if (Partida.IdEstatisticaCasa.HasValue)
                {
                    var estatisticaCasaExistente = await _context.Tb_EstatisticaCasa.FindAsync(Partida.IdEstatisticaCasa.Value);
                    if (estatisticaCasaExistente == null)
                    {
                        return BadRequest("EstatisticaCasa não encontrada.");
                    }
                }

                // Verifica se a EstatisticaFora existe, se necessário
                if (Partida.IdEstatisticaFora.HasValue)
                {
                    var estatisticaForaExistente = await _context.Tb_EstatisticaFora.FindAsync(Partida.IdEstatisticaFora.Value);
                    if (estatisticaForaExistente == null)
                    {
                        return BadRequest("EstatisticaFora não encontrada.");
                    }
                }


                await _context.TB_Partidas.AddAsync(Partida);

                if (Partida.PartidaAnalise || Partida.TipoPartida == "PartidaAnalise")
                {
                    List<int> ids = await GerarEsatisticaGeralAsync(Partida);
                    // Log para verificar os ids gerados
                }

                await _context.SaveChangesAsync();
                return Ok(Partida.idPartida);
            }
            catch (System.Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PartidaComEstatistica")]
        public async Task<IActionResult> AddGeral(PartidaComEstatisticaDTO dto)
        {
            try
            {
                string Mensagem = string.Empty;


                await _context.Tb_EstatisticaCasa.AddAsync(dto.Casa);
                await _context.Tb_EstatisticaFora.AddAsync(dto.Fora);
                await _context.SaveChangesAsync();
                dto.Partida.IdEstatisticaCasa = dto.Casa.IdEstatisticaCasa;
                dto.Partida.IdEstatisticaFora = dto.Fora.IdEstatisticaFora;
                string timeCasa = "EstatisticaGeralTimeCasa";
                string timefora = "EstatisticaGeralTimeFora";
                string idEstatisticasCasa = $"Id do {timeCasa}: {dto.Casa.IdEstatisticaCasa}";
                string idEstatisticasFora = $"Id do {timefora}: {dto.Fora.IdEstatisticaFora}";

                Mensagem = $"Id da Partida Gerada:{dto.Partida.idPartida} \n{idEstatisticasCasa} \n {idEstatisticasFora}";

                await _context.TB_Partidas.AddAsync(dto.Partida);

                await _context.SaveChangesAsync();
                return Ok(Mensagem);
            }
            catch (Exception ex)
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
                _context.TB_Partidas.Remove(pRemover);

                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion




        // #endregion

        #region Gerar EstatisticasTimes

        [HttpGet("GetEstatisticaTimes/{id}")]
        public async Task<IActionResult> GetEstatisticaTimesAsync(int id)
        {
            try
            {
                EstatisticaTimes pt = await _context.Tb_EstatisticaTimes.FirstOrDefaultAsync(p => p.IdTime == id);

                if (pt == null)
                    throw new Exception("Não foi Encontrado uma Partida com esse Id");

                return Ok(pt);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private async Task<List<int>> GerarEsatisticaGeralAsync(Partidas partidas)
        {
            try
            {
                if (partidas == null)
                {
                    throw new ArgumentNullException(nameof(partidas));
                }

                Console.WriteLine($"Iniciando geração de estatísticas para a partida entre {partidas.NomeTimeCasa} e {partidas.NomeTimeFora}");

                // Busca as estatísticas dos últimos 5 jogos em casa e fora do time da casa
                List<EstatisticaTimesCasa> listacasa = await BuscarUltimos5Casa(partidas.NomeTimeCasa, true);
                List<EstatisticaTimesCasa> casacasa = await BuscarJogosCasacasa(partidas.NomeTimeCasa);
                List<EstatisticaTimesCasa> listafora = await BuscarUltimos5Casa(partidas.NomeTimeFora, false);
                List<EstatisticaTimesCasa> forafora = await BuscarPorJogosForaFora(partidas.NomeTimeFora);

                EstatisticaTimes estatisticaCasa = new EstatisticaTimes();
                EstatisticaTimes estatisticaFora = new EstatisticaTimes();

                if (listacasa.Any())
                {
                    EstatisticaTIMEsDTO timeCasa = new EstatisticaTIMEsDTO
                    {
                        listacasa = listacasa,
                        casacasa = casacasa
                    };

                    estatisticaCasa = GerarEstatisticaTime(timeCasa);
                    estatisticaCasa.NomeTime = partidas.NomeTimeCasa;
                }

                if (listafora.Any())
                {
                    EstatisticaTIMEsDTO timeFora = new EstatisticaTIMEsDTO
                    {
                        listacasa = listafora,
                        casacasa = forafora
                    };

                    estatisticaFora = GerarEstatisticaTime(timeFora);
                    estatisticaFora.NomeTime = partidas.NomeTimeFora;

                }

                if (estatisticaCasa != null )
                {
                    await _context.Tb_EstatisticaTimes.AddAsync(estatisticaCasa);
                }

                if (estatisticaFora != null )
                {
                    await _context.Tb_EstatisticaTimes.AddAsync(estatisticaFora);
                }

                await _context.SaveChangesAsync();

                return new List<int> { estatisticaCasa.IdTime, estatisticaFora.IdTime };
            }
            catch (System.Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao gerar estatísticas: {ex.Message}");
                return new List<int>();
            }
        }



        private async Task<List<EstatisticaTimesCasa>> BuscarJogosCasacasa(string nome)
        {
            List<Partidas> casacasa = await _context.TB_Partidas.Where(p => p.NomeTimeCasa == nome
             && p.TipoPartida == "CasaCasa").ToListAsync();


            List<int> idsCasa = new List<int>();
            
            foreach (var item in casacasa)
            {
                idsCasa.Add((int)item.IdEstatisticaCasa);
            }
            

            List<EstatisticaTimesCasa> listacasa = new List<EstatisticaTimesCasa>();
            foreach (var item in idsCasa)
            {
                EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa
                .FirstOrDefaultAsync(p => p.IdEstatisticaCasa == item);

                listacasa.Add(casa);
            }

            return listacasa;

        }


        private async Task<List<EstatisticaTimesCasa>> BuscarPorJogosForaFora(string nome)
        {
            List<Partidas> casacasa = await _context.TB_Partidas.Where(p => p.NomeTimeFora == nome
            && p.TipoPartida == "ForaFora").ToListAsync();

            List<int> idsFora = new List<int>();

            foreach (var item in casacasa)
            {
                idsFora.Add((int)item.IdEstatisticaFora);
            }

            List<EstatisticaTimesFora> listafora = new List<EstatisticaTimesFora>();
            foreach (var item in idsFora)
            {
                EstatisticaTimesFora casa = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(p => p.IdEstatisticaFora == item);
                listafora.Add(casa);
            }
            List<EstatisticaTimesCasa> listaCasa = new List<EstatisticaTimesCasa>();

            foreach (var item in listafora)
            {
                EstatisticaTimesCasa c = ConverterForaParaCasa(item);
                listaCasa.Add(c);
            }

            return listaCasa;
        }

        private EstatisticaTimes GerarEstatisticaTime(EstatisticaTIMEsDTO c)
        {
            EstatisticaTimes estatistica = new EstatisticaTimes
            {
                GolMedias = (float)c.listacasa.Average(c => c.GolsCasa),
                GolMaior = c.listacasa.Max(c => c.GolsCasa),
                GolMenor = c.listacasa.Min(c => c.GolsCasa),
                GolMediasCF = (float)c.casacasa.Average(c => c.GolsCasa),
                GolMenorCF = c.casacasa.Min(c => c.GolsCasa),
                GolMaiorCF = c.casacasa.Max(c => c.GolsCasa),


                GolsSofridosMedias = (float)c.listacasa.Average(c => c.GolsSofridosCasa),
                GolsSofridosMaior = c.listacasa.Max(c => c.GolsSofridosCasa),
                GolsSofridosMenor = c.listacasa.Min(c => c.GolsSofridosCasa),
                GolsSofridosMediasCF = (float)c.casacasa.Average(c => c.GolsSofridosCasa),
                GolsSofridosMaiorCF = c.casacasa.Max(c => c.GolsSofridosCasa),
                GolsSofridosMenorCF = c.casacasa.Min(c => c.GolsSofridosCasa),

                TentativasGolsMedias = (float)c.listacasa.Average(c => c.TentativasGolsCasa),
                TentativasGolsMaior = c.listacasa.Max(c => c.TentativasGolsCasa),
                TentativasGolsMenor = c.listacasa.Min(c => c.TentativasGolsCasa),
                TentativasGolsMediasCF = (float)c.casacasa.Average(c => c.TentativasGolsCasa),
                TentativasGolsMaiorCF = c.casacasa.Max(c => c.TentativasGolsCasa),
                TentativasGolsMenorCF = c.casacasa.Min(c => c.TentativasGolsCasa),

                chutesnoGolsMedia = (float)c.listacasa.Average(c => c.chutesnoGolsCasa),
                chutesnoGolsMaior = (int)c.listacasa.Max(c => c.chutesnoGolsCasa),
                chutesnoGolsMenor = (int)c.listacasa.Min(c => c.chutesnoGolsCasa),
                chutesnoGolsMediaCF = (float)c.casacasa.Average(c => c.chutesnoGolsCasa),
                chutesnoGolsMaiorCF = (int)c.casacasa.Max(c => c.chutesnoGolsCasa),
                chutesnoGolsMenorCF = (int)c.casacasa.Min(c => c.chutesnoGolsCasa),

                chutespraforaMedia = (float)c.listacasa.Average(c => c.chutesnoGolsCasa),
                chutespraforaMaior = (int)c.listacasa.Max(c => c.chutesnoGolsCasa),
                chutespraforaMenor = (int)c.listacasa.Min(c => c.chutesnoGolsCasa),
                chutespraforaMediaCF = (float)c.casacasa.Average(c => c.chutesnoGolsCasa),
                chutespraforaMaiorCF = (int)c.casacasa.Max(c => c.chutesnoGolsCasa),
                chutespraforaMenorCF = (int)c.casacasa.Min(c => c.chutesnoGolsCasa),

                escanteiosMedia = (float)c.listacasa.Average(c => c.escanteiosCasa),
                escanteiosMaior = (int)c.listacasa.Max(c => c.escanteiosCasa),
                escanteiosMenor = (int)c.listacasa.Min(c => c.escanteiosCasa),
                escanteiosMediaCF = (float)c.casacasa.Average(c => c.escanteiosCasa),
                escanteiosMaiorCF = (int)c.casacasa.Max(c => c.escanteiosCasa),
                escanteiosMenorCF = (int)c.casacasa.Min(c => c.escanteiosCasa),

                InpedimentosMedia = (float)c.listacasa.Average(c => c.InpedimentosCasa),
                InpedimentosMaior = (int)c.listacasa.Max(c => c.InpedimentosCasa),
                InpedimentosMenor = (int)c.listacasa.Min(c => c.InpedimentosCasa),
                InpedimentosMediaCF = (float)c.casacasa.Average(c => c.InpedimentosCasa),
                InpedimentosMaiorCF = (int)c.casacasa.Max(c => c.InpedimentosCasa),
                InpedimentosMenorCF = (int)c.casacasa.Min(c => c.InpedimentosCasa),

                DefesaGoleiroMedia = (float)c.listacasa.Average(c => c.DefesaGoleiroCasa),
                DefesaGoleiroMaior = (int)c.listacasa.Max(c => c.DefesaGoleiroCasa),
                DefesaGoleiroMenor = (int)c.listacasa.Min(c => c.DefesaGoleiroCasa),
                DefesaGoleiroMediaCF = (float)c.casacasa.Average(c => c.DefesaGoleiroCasa),
                DefesaGoleiroMaiorCF = (int)c.casacasa.Max(c => c.DefesaGoleiroCasa),
                DefesaGoleiroMenorCF = (int)c.casacasa.Min(c => c.DefesaGoleiroCasa),

                FaltasMedia = (float)c.listacasa.Average(c => c.FaltasCasas),
                FaltasMaior = c.listacasa.Max(c => c.FaltasCasas),
                FaltasMenor = c.listacasa.Min(c => c.FaltasCasas),
                FaltasMediaCF = (float)c.casacasa.Average(c => c.FaltasCasas),
                FaltasMaiorCF = c.casacasa.Max(c => c.FaltasCasas),
                FaltasMenorCF = c.casacasa.Min(c => c.FaltasCasas),

                CartoesAmareloMedia = (float)c.listacasa.Average(c => c.CartoesAmareloCasa),
                CartoesAmareloMaior = (int)c.listacasa.Max(c => c.CartoesAmareloCasa),
                CartoesAmareloMenor = (int)c.listacasa.Min(c => c.CartoesAmareloCasa),
                CartoesAmareloMediaCF = (float)c.casacasa.Average(c => c.CartoesAmareloCasa),
                CartoesAmareloMaiorCF = (int)c.casacasa.Max(c => c.CartoesAmareloCasa),
                CartoesAmareloMenorCF = (int)c.casacasa.Min(c => c.CartoesAmareloCasa),

                PassesTotaisMedia = (float)c.listacasa.Average(c => c.PassesTotaisCasa),
                PassesTotaisMaior = c.listacasa.Max(c => c.PassesTotaisCasa),
                PassesTotaisMenor = c.listacasa.Min(c => c.PassesTotaisCasa),
                PassesTotaisMediaCF = (float)c.casacasa.Average(c => c.PassesTotaisCasa),
                PassesTotaisMaiorCF = c.casacasa.Max(c => c.PassesTotaisCasa),
                PassesTotaisMenorCF = c.casacasa.Min(c => c.PassesTotaisCasa),

                PassesCompletosMedia = (float)c.listacasa.Average(c => c.PassesCompletosCasa),
                PassesCompletosMediaCF = (float)c.casacasa.Average(c => c.PassesCompletosCasa),

                AtaquesperigososMedia = (float)c.listacasa.Average(c => c.AtaquesperigososCasa),
                AtaquesperigososMediaCF = (float)c.casacasa.Average(c => c.AtaquesperigososCasa)
            };
        


            return estatistica;
        }

        private EstatisticaTimesCasa ConverterForaParaCasa(EstatisticaTimesFora f)
        {

            EstatisticaTimesCasa c = new EstatisticaTimesCasa();
            c.GolsCasa = f.GolsFora;
            c.GolsSofridosCasa = f.GolsSofridosFora;
            c.TentativasGolsCasa = f.TentativasGolsFora;
            c.chutesnoGolsCasa = f.chutesnoGolsFora;
            c.chutespraforaCasa = f.chutespraforaFora;
            c.escanteiosCasa = f.escanteiosFora;
            c.InpedimentosCasa = f.InpedimentosFora;
            c.DefesaGoleiroCasa = f.DefesaGoleiroFora;
            c.FaltasCasas = f.FaltasForas;
            c.CartoesVermelhosCasa = f.CartoesVermelhosFora;
            c.CartoesAmareloCasa = f.CartoesAmareloFora;
            c.PassesTotaisCasa = f.PassesTotaisFora;
            c.PassesCompletosCasa = f.PassesCompletosFora;
            c.AtaquesperigososCasa = f.AtaquesperigososFora;
            c.NomeTimeCasa = f.NomeTimeFora;
            c.AdversarioFora = f.AdversarioCasa;

            return c;

        }

        private EstatisticaTimesFora ConverterCasaParaFora(EstatisticaTimesCasa c)
        {
            EstatisticaTimesFora f = new EstatisticaTimesFora();
            f.GolsFora = c.GolsCasa;
            f.GolsSofridosFora = c.GolsSofridosCasa;
            f.TentativasGolsFora = c.TentativasGolsCasa;
            f.chutesnoGolsFora = c.chutesnoGolsCasa;
            f.chutespraforaFora = c.chutespraforaCasa;
            f.escanteiosFora = c.escanteiosCasa;
            f.InpedimentosFora = c.InpedimentosCasa;
            f.DefesaGoleiroFora = c.DefesaGoleiroCasa;
            f.FaltasForas = c.FaltasCasas;
            f.CartoesVermelhosFora = c.CartoesVermelhosCasa;
            f.CartoesAmareloFora = c.CartoesAmareloCasa;
            f.PassesTotaisFora = c.PassesTotaisCasa;
            f.PassesCompletosFora = c.PassesCompletosCasa;
            f.AtaquesperigososFora = c.AtaquesperigososCasa;

            return f;
        }


        private async Task<List<EstatisticaTimesCasa>> BuscarUltimos5Casa(string nome, bool tipoPartidaCasa)
        {
            string tipopartida = string.Empty;

            List<Partidas> idsPartidas = new List<Partidas>();
            if (tipoPartidaCasa == true)
            {
                tipopartida = "Ultimas5Casa";


                idsPartidas = await _context.TB_Partidas.Where(p => p.NomeTimeCasa == nome
            && p.TipoPartida == tipopartida || p.NomeTimeFora == nome
            && p.TipoPartida == tipopartida).ToListAsync();
            }
            else
            {
                tipopartida = "Ultimas5Fora";

                idsPartidas = await _context.TB_Partidas.Where(p => p.NomeTimeCasa == nome
            && p.TipoPartida == tipopartida || p.NomeTimeFora == nome
            && p.TipoPartida == tipopartida).ToListAsync();
            }

            List<int> idsCasa = new List<int>();
            List<int> idsfora = new List<int>();

            foreach (var item in idsPartidas)
            {
                if (nome == item.NomeTimeCasa)
                    idsCasa.Add((int)item.IdEstatisticaCasa);
                else if (nome == item.NomeTimeFora)
                    idsfora.Add((int)item.IdEstatisticaFora);
            }

            List<EstatisticaTimesCasa> listacasa = new List<EstatisticaTimesCasa>();

            if (idsCasa.Count > 0)
            {
                foreach (var item in idsCasa)
                {
                    EstatisticaTimesCasa casa = await _context.Tb_EstatisticaCasa.FirstOrDefaultAsync(p => p.IdEstatisticaCasa == item);
                    listacasa.Add(casa);
                }
            }

            List<EstatisticaTimesFora> listafora = new List<EstatisticaTimesFora>();
            if (idsfora.Count > 0)
            {
                foreach (var item in idsfora)
                {
                    EstatisticaTimesFora fora = await _context.Tb_EstatisticaFora.FirstOrDefaultAsync(p => p.IdEstatisticaFora == item);
                    listafora.Add(fora);
                }
            }

            if (listafora.Count > 0)
                foreach (var f in listafora)
                {
                    EstatisticaTimesCasa c = ConverterForaParaCasa(f);

                    listacasa.Add(c);
                }

            return listacasa;

        }


        #endregion

    }
}