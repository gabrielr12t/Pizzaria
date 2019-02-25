using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class Fila
    {
        [Key]
        public int IdFila { get; set; }
        public int Posicao { get; set; }
        public TimeSpan TempoParaFinalizar { get; set; }
    }
}
