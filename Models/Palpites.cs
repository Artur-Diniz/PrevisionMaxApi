
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevisionMax.Models
{
    public class Palpites
    {
        [Key]
        public int idPalpites { get; set; }

        [ForeignKey("Partidas")]
        public int idPartida { get; set; }
        public TipoAposta tipoAposta { get; set; }     
        public double? num { get; set; }   //exemplo em casao de gol Maio que gols ou menor que esse num é o parametro
        public string descricao { get; set; } = string.Empty;
    }
}