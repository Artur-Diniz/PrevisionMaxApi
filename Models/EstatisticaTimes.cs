
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
    public class EstatisticaTimes
    {

            [Key]
            public int IdTime{ get; set; }
            public string NomeTime { get; set; } = string.Empty;
            
            public int GolMedias { get; set; }
            public int GolMaior { get; set; }
            public int GolMenor { get; set; }
            public int GolMediasCF { get; set; }

            public int TentativasGolsMedias{ get; set; } 
            public int TentativasGolsMenor{ get; set; } 
            public int TentativasGolsMaior{ get; set; } 
            public int TentativasGolsMediasCF{ get; set; } 

            public int chutesnoGolsMedia { get; set; }
            public int chutesnoGolsMenor { get; set; }
            public int chutesnoGolsMaior { get; set; }
            public int chutesnoGolsMediaCF { get; set; }


            public int chutespraforaMedia { get; set; }
            public int chutespraforaMenor { get; set; }
            public int chutespraforaMaior { get; set; }
            public int chutespraforaMediaCF { get; set; }

            public int escanteiosMedia { get; set; }
            public int escanteiosMenor { get; set; }
            public int escanteiosMaior { get; set; }
            public int escanteiosMediaCF { get; set; }

            public int InpedimentosMedia { get; set; }
            public int InpedimentosMenor { get; set; }
            public int InpedimentosMaior { get; set; }
            public int InpedimentosMediaCF { get; set; }

            public int DefesaGoleiroMedia { get; set; }
            public int DefesaGoleiroMenor { get; set; }
            public int DefesaGoleiroMaior{ get; set; }
            public int DefesaGoleiroMediaCF { get; set; }
            
            public int FaltasMedia { get; set; }
            public int FaltasMenor { get; set; }
            public int FaltasMaior { get; set; }
            public int FaltasMediaCF { get; set; }
            
            public int CartoesVermelhosMedia { get; set; }

            public int CartoesAmareloMedia { get; set; }
            public int CartoesAmareloMenor { get; set; }
            public int CartoesAmareloMaior { get; set; }
            public int CartoesAmareloMediaCF { get; set; }


            public int PassesTotaisMedia { get; set; }
            public int PassesTotaisMenor { get; set; }
            public int PassesTotaisMaior { get; set; }
            public int PassesTotaisMediaCF { get; set; }            
            
            public int PassesCompletosMedia { get; set; }
            public int PassesCompletosMediaCF { get; set; }
            public int PassesCompletosMaior { get; set; }
            public int PassesCompletosMenor { get; set; }

            public int AtaquesperigososMedia { get; set; } 
            public int AtaquesperigososMediaCF { get; set; } 
        
    }
}
