using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime Data { get; set; }

        public double ValorTotal { get; set; }

        public FormaEnvio FormaEnvio { get; set; }

        public virtual int FormaEnvioId { get; set; }


        public Fila Fila { get; set; }
        public virtual int FilaId { get; set; }
    }
}
