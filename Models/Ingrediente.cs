using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCommerce.Models
{
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [RegularExpression(@"^[0-9' ']*$", ErrorMessage = ("Digite somente números"))]
        [DisplayName("Quantidade para adicionar (em gramas)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Quantidade { get; set; }


        public string imagem { get; set; }


        [DataType(DataType.Currency)]
        [DisplayName("Preço do quilo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PrecoQuilo { get; set; }

        [RegularExpression(@"^[0-9' ']*$", ErrorMessage = ("Digite somente números"))]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Quantidade máxima para estoque (em gramas)")]
        public double QuantidadeMaxima { get; set; }

        [DisplayName("Data de modificação")]
        public DateTime DataAdicao { get; set; }
    }
}
