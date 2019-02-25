using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCommerce.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FuncionarioController(ApplicationDbContext obj)
        {
            _db = obj;
        }
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        
       public IActionResult Pedido()
       {
        //  var prods = (from p in _db.Produtos join cat in _db.Categorias on p.CategoriaId equals cat.IdCategoria select new {
        //             pID = p.IdProduto,
        //             pNOME = p.Nome,
        //             pVALOR = p.ValorAtual,
        //             cID = cat.IdCategoria,
        //             cNOME = cat.Nome                                          
        //     }).ToList();

                   
            ViewBag.Categorias = _db.Categorias.ToList();
            return View();
       }      
       [HttpPost]
       public IActionResult CarregarProdutos(int Id)
       {
            var prods = (from p in _db.Produtos join  phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente where p.CategoriaId == Id select new {
                proId = p.IdProduto,
                    categoria = p.Categoria.Nome,
                    nome = p.Nome,
                    ingrediente = i.Nome,                                                                                   
                    preco = p.ValorAtual

            }).ToList ();


           //var produtos = _db.Produtos.Where(c => c.CategoriaId == Id);
           return Json(prods);
       }         
    }
}