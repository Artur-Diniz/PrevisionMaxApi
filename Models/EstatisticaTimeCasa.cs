
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
    public class EstatisticaTimesCasa
    {

            [Key]
            public int IdEstatisticaCasa { get; set; }
            public string NomeTimeCasa { get; set; } = string.Empty;
            public int GolsCasa { get; set; }
            public int GolsSofridosCasa { get; set; }
            public string AdversarioFora { get; set; }

            public int TentativasGolsCasa { get; set; }
            public int? chutesnoGolsCasa { get; set; }
            public int chutespraforaCasa { get; set; }
            public int? escanteiosCasa { get; set; }
            public int? InpedimentosCasa { get; set; }
            public int? DefesaGoleiroCasa { get; set; }
            public int FaltasCasas { get; set; }
            public int? CartoesVermelhosCasa { get; set; }
            public int? CartoesAmareloCasa { get; set; }
            public int PassesTotaisCasa { get; set; }
            public int PassesCompletosCasa { get; set; }
            public int AtaquesperigososCasa { get; set; }

        public static implicit operator EstatisticaTimesCasa(EstatisticaTimesFora v)
        {
            throw new NotImplementedException();
        }
    }
}
