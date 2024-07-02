using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
    public enum TipoAposta
    {
        CasaVence = 1,
        ForaVence = 2,
        CasaVitoriaAnula = 3,
        ForaVitoriaAnula = 4,
         Gols= 5,
         Escanteios= 6,
         Faltas = 7,
         CartõesAmarelo = 8,
         Impedimentos = 9,
         chutesAoGol = 10 ,
         DefesaGoleiro  = 11,
         golsFeitosPorJogador = 12,
         Outros = 13

    }
}