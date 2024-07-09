
using System;
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
        public int IdTime { get; set; }
        public string NomeTime { get; set; } = string.Empty;

        public float GolMedias { get; set; }
        public int GolMaior { get; set; }
        public int GolMenor { get; set; }
        public float GolMediasCF { get; set; }
        public float GolMenorCF { get; set; }
        public float GolMaiorCF { get; set; }

        public float GolsSofridosMedias { get; set; }
        public int GolsSofridosMaior { get; set; }
        public int GolsSofridosMenor { get; set; }
        public float GolsSofridosMediasCF { get; set; }
        public float GolsSofridosMenorCF { get; set; }
        public float GolsSofridosMaiorCF { get; set; }


        public float TentativasGolsMedias { get; set; }
        public int TentativasGolsMenor { get; set; }
        public int TentativasGolsMaior { get; set; }
        public float TentativasGolsMediasCF { get; set; }
        public float TentativasGolsMenorCF { get; set; }
        public float TentativasGolsMaiorCF { get; set; }

        public float chutesnoGolsMedia { get; set; }
        public int chutesnoGolsMenor { get; set; }
        public int chutesnoGolsMaior { get; set; }
        public float chutesnoGolsMediaCF { get; set; }
        public float chutesnoGolsMenorCF { get; set; }
        public float chutesnoGolsMaiorCF { get; set; }


        public float chutespraforaMedia { get; set; }
        public int chutespraforaMenor { get; set; }
        public int chutespraforaMaior { get; set; }
        public float chutespraforaMediaCF { get; set; }
        public float chutespraforaMenorCF { get; set; }
        public float chutespraforaMaiorCF { get; set; }

        public float escanteiosMedia { get; set; }
        public int escanteiosMenor { get; set; }
        public int escanteiosMaior { get; set; }
        public float escanteiosMediaCF { get; set; }
        public float escanteiosMenorCF { get; set; }
        public float escanteiosMaiorCF { get; set; }

        public float InpedimentosMedia { get; set; }
        public int InpedimentosMenor { get; set; }
        public int InpedimentosMaior { get; set; }
        public float InpedimentosMediaCF { get; set; }
        public float InpedimentosMenorCF { get; set; }
        public float InpedimentosMaiorCF { get; set; }

        public float DefesaGoleiroMedia { get; set; }
        public int DefesaGoleiroMenor { get; set; }
        public int DefesaGoleiroMaior { get; set; }

        public float DefesaGoleiroMediaCF { get; set; }
        public float DefesaGoleiroMenorCF { get; set; }
        public float DefesaGoleiroMaiorCF { get; set; }

        public float FaltasMedia { get; set; }
        public int FaltasMenor { get; set; }
        public int FaltasMaior { get; set; }

        public float FaltasMediaCF { get; set; }
        public float FaltasMenorCF { get; set; }
        public float FaltasMaiorCF { get; set; }

        public float CartoesVermelhosMedia { get; set; }

        public float CartoesAmareloMedia { get; set; }
        public int CartoesAmareloMenor { get; set; }
        public int CartoesAmareloMaior { get; set; }

        public float CartoesAmareloMediaCF { get; set; }
        public float CartoesAmareloMenorCF { get; set; }
        public float CartoesAmareloMaiorCF { get; set; }


        public float PassesTotaisMedia { get; set; }
        public int PassesTotaisMenor { get; set; }
        public int PassesTotaisMaior { get; set; }
        public float PassesTotaisMediaCF { get; set; }
        public float PassesTotaisMenorCF { get; set; }
        public float PassesTotaisMaiorCF { get; set; }

        public float PassesCompletosMedia { get; set; }
        public float PassesCompletosMediaCF { get; set; }

        public float AtaquesperigososMedia { get; set; }
        public float AtaquesperigososMediaCF { get; set; }

    }
}
