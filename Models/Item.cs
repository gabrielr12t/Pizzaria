﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class Item
    {
        //um carrinho tem varios itens
        [Key]
        public int IdItem { get; set; }
        public int Quantidade { get; set; }                
        public Produto Produto { get; set; }
        public virtual int ProdutoId { get; set; }
        public Pedido Pedido { get; set; }
        public virtual int PedidoId { get; set; }
    }
}