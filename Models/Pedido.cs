using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ApplicationCommerce.Models {
    public class Pedido {
        [Key]
        public int IdPedido { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public int Status { get; set; } //0 = na fila, 1 = está sendo feito , 2 = em preparação para entrega , 3 = saiu para entrega, 4 = entregue, -2 = cancelado
        public string Avaliacao { get; set; }
        public FormaEnvio FormaEnvio { get; set; }
        public virtual int FormaEnvioId { get; set; }
        
        [ForeignKey("PessoaId")]
        public virtual Pessoa Pessoa { get; set; }
        public int? PessoaId { get; set; }
        public Fila Fila { get; set; }
        public virtual int? FilaId { get; set; }
    }
}