using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{
    public class Acompanhante
    {
        [Key]
        public int IdAcompanhante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Pedido Pedido { get; set; }
        public virtual int PedidoId { get; set; }
    }
}
