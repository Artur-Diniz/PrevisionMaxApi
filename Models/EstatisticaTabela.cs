
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
    public class EstatisticaTabela
    {

        [Key]
        public int IdEstatisticaTabela { get; set; }
        public string NomeCampeonato { get; set; } = string.Empty;
        public string tipoTabela { get; set; } = string.Empty;
        public string NomeTime { get; set; } = string.Empty;
        public double Media { get; set; }
        public int Over_05 { get; set; }
        public int Over_15 { get; set; }
        public int Over_25 { get; set; }
        public int Over_35 { get; set; }
        public int Over_45 { get; set; }
        public int Over_55 { get; set; }
        public int AmbasMarcam { get; set; }
        public int SemGols { get; set; }
        public int golMarcado { get; set; }
        public int golSofrido { get; set; }
    }
}
