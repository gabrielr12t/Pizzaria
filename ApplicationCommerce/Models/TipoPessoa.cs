using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{
    public class TipoPessoa
    {
       [Key]
        public int IdTipoPessoa { get; set; }
        [DisplayName("Tipo de Usuário")]
        public string Nome { get; set; }
    }
}
