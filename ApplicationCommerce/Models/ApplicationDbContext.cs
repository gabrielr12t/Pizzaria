using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{    
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Acompanhante> Acompanhantes { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<Fila> Filas { get; set; }
        public virtual DbSet<FormaEnvio> FormaEnvios { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<HistoricoCompra> HistoricoCompras { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Mensagem> Mensagems { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoHasIngrediente> ProdutoHasIngredientes { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Tamanho> Tamanhos { get; set; }
        public virtual DbSet<TipoPessoa> TipoPessoas { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }

        
    }
}
