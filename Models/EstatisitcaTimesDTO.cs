
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
public class EstatisticaTIMEsDTO
{
    public List<EstatisticaTimesCasa> listacasa { get; set; }
    public List<EstatisticaTimesCasa> casacasa { get; set; }
}

}