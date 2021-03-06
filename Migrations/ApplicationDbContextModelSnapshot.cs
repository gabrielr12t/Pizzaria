﻿// <auto-generated />
using System;
using ApplicationCommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCommerce.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCommerce.Models.Acompanhante", b =>
                {
                    b.Property<int>("IdAcompanhante")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("PedidoId");

                    b.Property<double>("Valor");

                    b.HasKey("IdAcompanhante");

                    b.HasIndex("PedidoId");

                    b.ToTable("Acompanhantes");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("Cep")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.Property<int>("PessoaId");

                    b.Property<string>("Referencia");

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.HasKey("IdEndereco");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Favorito", b =>
                {
                    b.Property<int>("IdFavorito")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("IdFavorito");

                    b.HasIndex("PessoaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Fila", b =>
                {
                    b.Property<int>("IdFila")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Posicao");

                    b.Property<int>("TempoParaFinalizar");

                    b.HasKey("IdFila");

                    b.ToTable("Filas");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.FormaEnvio", b =>
                {
                    b.Property<int>("IdFormaEnvio")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<double>("Valor");

                    b.HasKey("IdFormaEnvio");

                    b.ToTable("FormaEnvios");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.FormaPagamento", b =>
                {
                    b.Property<int>("IdFormaPagamento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("IdFormaPagamento");

                    b.ToTable("FormaPagamentos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .IsRequired();

                    b.HasKey("IdFoto");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.HistoricoCompra", b =>
                {
                    b.Property<int>("IdHistoricoCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCompra");

                    b.Property<int>("PedidoId");

                    b.Property<double>("Total");

                    b.HasKey("IdHistoricoCompra");

                    b.HasIndex("PedidoId");

                    b.ToTable("HistoricoCompras");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Ingrediente", b =>
                {
                    b.Property<int>("IdIngrediente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAdicao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("PrecoQuilo")
                        .IsRequired();

                    b.Property<double>("Quantidade");

                    b.Property<double>("QuantidadeMaxima");

                    b.Property<string>("imagem");

                    b.HasKey("IdIngrediente");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Item", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("IdItem");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Mensagem", b =>
                {
                    b.Property<int>("IdMensagem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .IsRequired();

                    b.Property<DateTime>("Data");

                    b.Property<int>("PessoaId");

                    b.Property<int>("Visualizada");

                    b.HasKey("IdMensagem");

                    b.HasIndex("PessoaId");

                    b.ToTable("Mensagems");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avaliacao");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("FilaId");

                    b.Property<int>("FormaEnvioId");

                    b.Property<int?>("PessoaId");

                    b.Property<int>("Status");

                    b.Property<double>("ValorTotal");

                    b.HasKey("IdPedido");

                    b.HasIndex("FilaId");

                    b.HasIndex("FormaEnvioId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaminhoFoto");

                    b.Property<string>("Celular");

                    b.Property<string>("ChaveRecuperacaoSenha");

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("PermissaoCadastro");

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("Sobrenome")
                        .IsRequired();

                    b.Property<int?>("StatusCadastro");

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.Property<int>("TipoPessoaId");

                    b.HasKey("IdPessoa");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Foto");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("TamanhoId");

                    b.Property<int>("TempoProduzir");

                    b.Property<double>("ValorAntigo");

                    b.Property<double>("ValorAtual");

                    b.HasKey("IdProduto");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TamanhoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.ProdutoHasIngrediente", b =>
                {
                    b.Property<int>("IdProdutoHasCategoria")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredienteId");

                    b.Property<int>("ProdutoId");

                    b.Property<double?>("Quantidade")
                        .IsRequired();

                    b.HasKey("IdProdutoHasCategoria");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoHasIngredientes");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<TimeSpan>("Hora");

                    b.Property<int>("Mesa");

                    b.Property<int>("NumeroPessoas");

                    b.Property<int>("PessoaId");

                    b.HasKey("IdReserva");

                    b.HasIndex("PessoaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Tamanho", b =>
                {
                    b.Property<int>("IdTamanho")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comprimento");

                    b.Property<string>("Largura");

                    b.Property<string>("Nome");

                    b.HasKey("IdTamanho");

                    b.ToTable("Tamanhos");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.TipoPessoa", b =>
                {
                    b.Property<int>("IdTipoPessoa")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("IdTipoPessoa");

                    b.ToTable("TipoPessoas");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Acompanhante", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Endereco", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Favorito", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCommerce.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.HistoricoCompra", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Item", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCommerce.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Mensagem", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Pedido", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Fila", "Fila")
                        .WithMany()
                        .HasForeignKey("FilaId");

                    b.HasOne("ApplicationCommerce.Models.FormaEnvio", "FormaEnvio")
                        .WithMany()
                        .HasForeignKey("FormaEnvioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCommerce.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Pessoa", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Produto", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCommerce.Models.Tamanho", "Tamanho")
                        .WithMany()
                        .HasForeignKey("TamanhoId");
                });

            modelBuilder.Entity("ApplicationCommerce.Models.ProdutoHasIngrediente", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationCommerce.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCommerce.Models.Reserva", b =>
                {
                    b.HasOne("ApplicationCommerce.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
