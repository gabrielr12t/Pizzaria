using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
    }
}
