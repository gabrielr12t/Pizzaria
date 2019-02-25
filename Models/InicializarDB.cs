using System.Linq;
using Microsoft.EntityFrameworkCore;

 
using System.Threading.Tasks;
using System;

namespace ApplicationCommerce.Models
{
    public class InicializarDB
    {              
        public static void Initialize(ApplicationDbContext context)
        {
            
            context.Database.EnsureCreated();
            
            if (context.Ingredientes.Any())
            {
                return;
            }            

            var tipoPessoas = new TipoPessoa[]
            {
                new TipoPessoa{Nome="Administrador"},
                new TipoPessoa{Nome="Funcionário"},
                new TipoPessoa{Nome="Cozinheiro"},
                new TipoPessoa{Nome="Cliente"}
            };

            var formasPagamento = new FormaPagamento[]
            {
                new FormaPagamento{Nome="Cartão de crédito"},
                new FormaPagamento{Nome="à Vista"}
            };

            var formasEnvio = new FormaEnvio[]
            {
                new FormaEnvio{Nome="Motoboy",Valor = 3.50},
                new FormaEnvio{Nome="Retirar a mão", Valor=0}
            };

            var tamanhos = new Tamanho[]
            {
                new Tamanho{Nome="Pequeno"},
                new Tamanho{Nome="Médio"},
                new Tamanho{Nome="Grande"}
            };

            var categorias = new Categoria[]{
                new Categoria{Nome="Pizza"},
                new Categoria{Nome="Lanche"},
                new Categoria{Nome="Comida"}
            };

            var ingredientes = new Ingrediente[]{                
                new Ingrediente{Nome="Calabresa",DataAdicao = DateTime.Now, PrecoQuilo = "19,80",Quantidade= 1500, QuantidadeMaxima = 3000},
                new Ingrediente{Nome="Mussarela",DataAdicao = DateTime.Now, PrecoQuilo = "15,80",Quantidade= 4000, QuantidadeMaxima = 5000},
                new Ingrediente{Nome="Tomate",DataAdicao = DateTime.Now, PrecoQuilo = "9,80",Quantidade= 2000, QuantidadeMaxima = 4150},
                new Ingrediente{Nome="Frango",DataAdicao = DateTime.Now, PrecoQuilo = "21,90",Quantidade= 2300, QuantidadeMaxima = 3000},
                new Ingrediente{Nome="Presunto",DataAdicao = DateTime.Now, PrecoQuilo = "14,80",Quantidade= 3500, QuantidadeMaxima = 4000},
                new Ingrediente{Nome="Bacon",DataAdicao = DateTime.Now, PrecoQuilo = "25,80",Quantidade= 1500, QuantidadeMaxima = 3220},
                new Ingrediente{Nome="Palmito",DataAdicao = DateTime.Now, PrecoQuilo = "29,80",Quantidade= 2000, QuantidadeMaxima = 3300},
                new Ingrediente{Nome="Catupiry",DataAdicao = DateTime.Now, PrecoQuilo = "35,60",Quantidade= 3800, QuantidadeMaxima = 3000},
                new Ingrediente{Nome="Atum",DataAdicao = DateTime.Now, PrecoQuilo = "24,80",Quantidade= 5000, QuantidadeMaxima = 3600},
                new Ingrediente{Nome="Cebola",DataAdicao = DateTime.Now, PrecoQuilo = "5,80",Quantidade= 1500, QuantidadeMaxima = 1500},
                new Ingrediente{Nome="Trigo",DataAdicao = DateTime.Now, PrecoQuilo = "12,20",Quantidade= 6000, QuantidadeMaxima = 10000},
                new Ingrediente{Nome="Orégano",DataAdicao = DateTime.Now, PrecoQuilo = "29,80",Quantidade= 1500, QuantidadeMaxima = 1500}                
            };

            foreach (var ings in ingredientes)
            {
                context.Ingredientes.Add(ings);
            }

            foreach (var cats in categorias)
            {
                context.Categorias.Add(cats);
            }

            foreach (FormaPagamento fp in formasPagamento)
            {
                context.FormaPagamentos.Add(fp);
            }

            foreach (FormaEnvio fe in formasEnvio)
            {
                context.FormaEnvios.Add(fe);
            }

            foreach (Tamanho t in tamanhos)
            {
                context.Tamanhos.Add(t);
            }

            foreach (TipoPessoa tp in tipoPessoas)
            {
                context.TipoPessoas.Add(tp);
            }

            context.SaveChanges();
        }
    }
}