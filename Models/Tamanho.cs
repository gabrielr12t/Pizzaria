using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCommerce.Models
{
    public class Tamanho
    {
        [Key]
        public int IdTamanho { get; set; }
        public string Nome { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
    }
}
