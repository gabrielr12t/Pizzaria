using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApplicationCommerce.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

         [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome do produto")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Valor do produto")]
        public string ValorAtual { get; set; }



        public string ValorAntigo { get; set; }

        [RegularExpression(@"^[0-9' ']*$", ErrorMessage = ("Digite somente números"))]
        [DisplayName("Em quantos minutos este produto é produzido (em minutos)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double TempoProduzir { get; set; }

        [DisplayName("Foto do produto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Foto { get; set; }


        [DisplayName("Categoria do produto")]
        [Required(ErrorMessage = "Selecione uma categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }



        public Tamanho Tamanho { get; set; }
        public virtual int? TamanhoId { get; set; }
    }
}
