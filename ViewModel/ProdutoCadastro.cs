using ApplicationCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.ViewModel
{
    public class ProdutoCadastro
    {
        public Produto Produto { get; set; }
        public List<ProdutoRecebeIngredientes> ProdutosIngredientes  { get; set; }        
    }    
}
