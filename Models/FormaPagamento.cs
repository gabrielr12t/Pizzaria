using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class FormaPagamento
    {
        [Key]
        public int IdFormaPagamento { get; set; }
        public string Nome { get; set; }
    }
}
