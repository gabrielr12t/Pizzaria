using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class HistoricoCompra
    {
        [Key]
        public int IdHistoricoCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public double Total { get; set; }        
        public Pedido Pedido { get; set; }
        public virtual int PedidoId { get; set; }       
    }
}
