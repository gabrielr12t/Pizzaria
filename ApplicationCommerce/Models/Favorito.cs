using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }
        public Pessoa Pessoa { get; set; }
        public virtual int PessoaId { get; set; }

        public Produto Produto { get; set; }
        public virtual int ProdutoId { get; set; }
    }
}
