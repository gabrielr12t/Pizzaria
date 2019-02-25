using ApplicationCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.ViewModel
{
    public class IngredientesToList
    {
        public Ingrediente Ingrediente { get; set; }
        public ICollection<Ingrediente> Ingredientes{ get; set; }
    }
}
