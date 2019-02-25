using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApplicationCommerce.Models
{
    public class ProdutoHasIngrediente
    {
        [Key]
        public int IdProdutoHasCategoria { get; set; }

        [DisplayName("Digite a quantidade em gramas")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = ("Digite somente números"))]
        [Required(ErrorMessage ="Campo obrigatório")]
        public double? Quantidade { get; set; }


        public Ingrediente Ingrediente { get; set; }
        public virtual int IngredienteId { get; set; }


        public Produto Produto { get; set; }
        public virtual int ProdutoId { get; set; }
    }
}
