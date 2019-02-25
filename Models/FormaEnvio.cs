using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCommerce.Models
{
    public class FormaEnvio
    {
        [Key]
        public int IdFormaEnvio { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
