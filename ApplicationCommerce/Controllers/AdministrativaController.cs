using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApplicationCommerce.Models;
using ApplicationCommerce.Services;
using ApplicationCommerce.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ApplicationCommerce.Controllers
{
    public class AdministrativaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _enviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Pessoa _pessoa { get; set; }
        private ISession _session => _httpContextAccessor.HttpContext.Session;


        public AdministrativaController(ApplicationDbContext obj, IHostingEnvironment i, IHttpContextAccessor httpContextAccessor)
        {
            _db = obj;
            _enviroment = i;
            _httpContextAccessor = httpContextAccessor;

            //verifica login
            var session = _session.GetInt32("ID");
            _pessoa = session != null ? _pessoa = _db.Pessoas.Single(c => c.IdPessoa == session) : null;
        }


        // verificando admin
        public bool IsAdmin()
        {
            if (_pessoa != null)
                return _pessoa.TipoPessoaId == 1 ? true : false;
            return false;
        }

        public ActionResult Index()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");

            return View();
        }

        // -----------------------------------------------------------------------------------------------------------
        public IActionResult Cadastro()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");


            // ----- verificando admin

            ViewBag.Tipo = new SelectList(_db.TipoPessoas.ToList(), "IdTipoPessoa", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(PessoaEndereco p)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");


            ViewBag.Tipo = new SelectList(_db.TipoPessoas.ToList(), "IdTipoPessoa", "Nome");

            string nome = p.Pessoa.Nome;
            string email = p.Pessoa.Email;
            string assunto = "Cadastro efetuado com sucesso!!!";
            string corpo = "Olá senhor " + nome + @", seu cadastro foi efetuado em nosso sistema web para pedidos. Aproveite e receba ofertas com muito desconto.";
            bool enviou;
            if (ModelState.IsValid)
            {

                enviou = EmailService.SendEmail(nome, email, assunto, corpo);

                if (!enviou)
                {
                    ViewData["Email"] = "não enviado";
                    return View();
                }
                ViewData["Email"] = null;

                string senha = Criptografia.CriptografiaSenha(p.Pessoa.Senha);
                try
                {
                    _db.Pessoas.Add(p.Pessoa);
                    p.Pessoa.DataCadastro = DateTime.Now;
                    p.Pessoa.PermissaoCadastro = 0;
                    p.Pessoa.StatusCadastro = 1;
                    HttpContext.Session.SetString("ID", p.Pessoa.IdPessoa.ToString());
                    _db.Enderecos.Add(p.Endereco);
                    p.Endereco.PessoaId = p.Pessoa.IdPessoa;
                    _db.SaveChanges();
                    ModelState.Clear();
                }
                catch
                {
                    return View(p.Pessoa);
                }
            }
            return View();
        }

        // ----------------------------------------------------------------------------------------------------------------

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Pessoa p)
        {
            string senha = Criptografia.CriptografiaSenha(p.Senha);

            var em = _db.Pessoas.Where(j => j.Email == p.Email.ToLower()).FirstOrDefault();

            var pes = _db.Pessoas.Where(u => u.Email.Equals(p.Email.ToLower()) && u.Senha.Equals(senha)).FirstOrDefault();
            if (em != null)
            {
                if (pes != null)
                {
                    _session.SetInt32("ID", pes.IdPessoa);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Senha incorreta");
                }
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Usuário não possui cadastro");
            }
            return View();
        }
        // ------------------------------------------------------------------------------------------------
        public ActionResult RecuperarSenha()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RecuperarSenha(Pessoa p)
        {
            var pes = _db.Pessoas.SingleOrDefault(e => e.Email.Equals(p.Email.ToLower()));

            if (pes != null)
            {
                string senha = GerarSenhaService.SenhaHash();
                string nome = pes.Nome;
                string email = pes.Email;
                string assunto = "Recuperação de senha";
                string corpo = "Olá senhor " + pes.Nome + @", Recomendamos que troque sua senha nas configurações<br/><strong>Sua nova senha:</strong><p  style='font-size:16px'> " + senha + " </p>";
                bool enviou = EmailService.SendEmail(nome, email, assunto, corpo);
                if (enviou)
                {
                    string newSenha = Criptografia.CriptografiaSenha(senha);
                    ViewData["Enviou"] = "enviou";
                    var newPessoa = _db.Pessoas.Where(x => x.Email.Equals(p.Email)).FirstOrDefault();
                    newPessoa.Senha = newSenha;
                    _db.SaveChanges();
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ViewData["Enviou"] = "erro";
                    return View();
                }
            }
            else
            {
                ModelState.Clear();
                ViewData["Erro"] = "erro";
                return View();
            }
        }

        //--------------------------------------------------------------------------------------------
        public ActionResult CadastrarIngrediente()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin


            var lista = _db.Ingredientes.ToList();

            if (lista.Count != 0)
            {
                ViewData["Lista"] = lista.OrderBy(c => c.Nome).ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarIngrediente(CadastrarEditarIngredientes i)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin


            if (ModelState.IsValid)
            {
                //var ing = new Ingrediente { Nome = i.Ingredientes.Nome, DataAdicao = DateTime.Now, PrecoQuilo = i.Ingredientes.PrecoQuilo, Quantidade = i.Ingredientes.Quantidade, QuantidadeMaxima = i.Ingredientes.QuantidadeMaxima };
                _db.Ingredientes.Add(i.Ingredientes);
                i.Ingredientes.DataAdicao = DateTime.Now;
                _db.SaveChanges();
                ModelState.Clear();
            }

            var lista = _db.Ingredientes.ToList();

            if (lista.Count != 0)
            {
                ViewData["Lista"] = lista.OrderBy(c => c.Nome).ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditarIngrediente(string IdE, CadastrarEditarIngredientes ingrediente, string qtdAlterar, string Btn)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin



            int id = int.Parse(IdE);
            var ing = _db.Ingredientes.Single(g => g.IdIngrediente == id);

            double qtdBanco = ing.Quantidade;
            double qtdAltera = double.Parse(qtdAlterar);

            bool alterado = false;

            switch (Btn)
            {
                case "Adicionar":
                    if (ing != null && ModelState.IsValid)
                    {
                        ing.Nome = ingrediente.IngredienteEdit.Nome;
                        ing.Quantidade = qtdBanco + qtdAltera;
                        ing.PrecoQuilo = ingrediente.IngredienteEdit.PrecoQuilo;
                        ing.QuantidadeMaxima = ingrediente.IngredienteEdit.QuantidadeMaxima;
                        ing.DataAdicao = DateTime.Now;
                        _db.Ingredientes.Update(ing);
                        _db.SaveChanges();
                        alterado = true;
                    }
                    break;
                case "Remover":
                    if (ing != null && ModelState.IsValid)
                    {
                        ing.Nome = ingrediente.IngredienteEdit.Nome;
                        ing.Quantidade = qtdBanco - qtdAltera;
                        ing.PrecoQuilo = ingrediente.IngredienteEdit.PrecoQuilo;
                        ing.QuantidadeMaxima = ingrediente.IngredienteEdit.QuantidadeMaxima;
                        ing.DataAdicao = DateTime.Now;
                        _db.Ingredientes.Update(ing);
                        _db.SaveChanges();
                        alterado = true;
                    }
                    break;
            }
            if (alterado)
            {
                ViewData["Alterado"] = "s";
            }
            return RedirectToAction("CadastrarIngrediente");
        }
        public ActionResult ExcluirIngrediente(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin




            var ing = _db.Ingredientes.Single(x => x.IdIngrediente == id);
            _db.Remove(ing);
            _db.SaveChanges();
            return RedirectToAction("CadastrarIngrediente");
        }

        // ----------------------------------------------------------------------------------------------

        public ActionResult CadastrarCategoria()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin

            var cats = _db.Categorias.ToList();

            if (cats.Count != 0)
            {
                ViewData["categorias"] = cats;
            }
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria cat)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin



            if (ModelState.IsValid)
            {
                _db.Categorias.Add(cat);
                _db.SaveChanges();

                var cats = _db.Categorias.ToList();
                if (cats.Count != 0)
                {
                    ViewData["categorias"] = cats;
                }
                ModelState.Clear();
                return View();
            }
            return View();

        }
        public ActionResult ExcluirCategoria(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin



            var ing = _db.Categorias.Single(x => x.IdCategoria == id);
            _db.Remove(ing);
            _db.SaveChanges();
            return RedirectToAction("CadastrarCategoria");
        }

        // ------------------------------------------------------------------------
        [HttpGet]
        public ActionResult CadastrarProduto()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin




            ViewBag.Ingredientes = _db.Ingredientes.ToList();
            //ViewData["Produtos"] = _db.Produtos.Join(_db.ProdutoHasIngredientes, c => c.Id, cm => cm.Id)
            ViewBag.Categoria = new SelectList(_db.Categorias.ToList(), "IdCategoria", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarProduto(Produto p, int ddlCategoria, string[] selectedIngredientes)
        {
            if (!IsAdmin())
                return RedirectToAction("Login");
            // ----- verificando admin


            if (ModelState.IsValid)
            {
                _db.Produtos.Add(p);
                p.CategoriaId = ddlCategoria;
                p.ValorAntigo = "0";

                _db.SaveChanges();
                foreach (var id in selectedIngredientes)
                {
                    var prodHasIng = new ProdutoHasIngrediente();
                    prodHasIng.IngredienteId = Convert.ToInt32(id);
                    prodHasIng.ProdutoId = p.IdProduto;
                    prodHasIng.Quantidade = 0;
                    _db.ProdutoHasIngredientes.Add(prodHasIng);
                    _db.SaveChanges();
                }
            }
            else
            {
                return View();
            }
            ViewBag.Ingredientes = _db.Ingredientes.ToList();
            ViewBag.Categoria = new SelectList(_db.Categorias.ToList(), "IdCategoria", "Nome");
            ModelState.Clear();
            return View();
        }
        // -------------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditarProduto()
        {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");

            var prods = (from p in _db.Produtos
                         join phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId
                         join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente
                         select new
                         {
                             proId = p.IdProduto,
                             proNome = p.Nome,
                             proIngrediente = i.Nome,
                             proHasQuantidade = phi.Quantidade,
                             proHasIngProId = phi.ProdutoId,
                             proHasIngId = phi.IdProdutoHasCategoria,
                             idIngredienteHas = phi.IngredienteId,
                             idIngrediente = i.IdIngrediente

                         }).ToList();

            var listaProEdit = new List<ProdutoEditar>();

            foreach (var item in prods)
            {
                ProdutoEditar pe = new ProdutoEditar();
                pe.Produtos = new Produto();
                pe.Ingredientes = new Ingrediente();
                pe.ProdutoHasIngredientes = new ProdutoHasIngrediente();


                pe.Produtos.IdProduto = item.proId;
                pe.Produtos.Nome = item.proNome;
                pe.Ingredientes.Nome = item.proIngrediente;
                pe.ProdutoHasIngredientes.Quantidade = item.proHasQuantidade;
                pe.ProdutoHasIngredientes.ProdutoId = item.proHasIngProId;
                pe.ProdutoHasIngredientes.IdProdutoHasCategoria = item.proHasIngId;
                pe.ProdutoHasIngredientes.IngredienteId = item.idIngrediente;
                pe.Ingredientes.IdIngrediente = item.idIngrediente;
                listaProEdit.Add(pe);
            }

            ViewData["Ingredientes"] = _db.Ingredientes.ToList();
            //ViewBag.Ingrediente = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");

            if (listaProEdit != null)
            {
                ViewData["produ"] = listaProEdit.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditarProduto(ProdutoHasIngrediente phin)
        {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");

            var prods = (from p in _db.Produtos
                         join phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId
                         join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente
                         select new
                         {
                             proId = p.IdProduto,
                             proNome = p.Nome,
                             proIngrediente = i.Nome,
                             proHasQuantidade = phi.Quantidade,
                             proHasIngProId = phi.ProdutoId,
                             proHasIngId = phi.IdProdutoHasCategoria,
                             idIngredienteHas = phi.IngredienteId,
                             idIngrediente = i.IdIngrediente

                         }).ToList();

            var listaProEdit = new List<ProdutoEditar>();

            foreach (var item in prods)
            {
                ProdutoEditar pe = new ProdutoEditar();
                pe.Produtos = new Produto();
                pe.Ingredientes = new Ingrediente();
                pe.ProdutoHasIngredientes = new ProdutoHasIngrediente();


                pe.Produtos.IdProduto = item.proId;
                pe.Produtos.Nome = item.proNome;
                pe.Ingredientes.Nome = item.proIngrediente;
                pe.ProdutoHasIngredientes.Quantidade = item.proHasQuantidade;
                pe.ProdutoHasIngredientes.ProdutoId = item.proHasIngProId;
                pe.ProdutoHasIngredientes.IdProdutoHasCategoria = item.proHasIngId;
                pe.ProdutoHasIngredientes.IngredienteId = item.idIngrediente;
                pe.Ingredientes.IdIngrediente = item.idIngrediente;
                listaProEdit.Add(pe);
            }
            ViewData["Ingredientes"] = _db.Ingredientes.ToList();
            //ViewBag.Ingrediente = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");

            if (listaProEdit != null)
            {
                ViewData["produ"] = listaProEdit.ToList();
            }
            return View();
        }


        //------------------------------------------------------------------------------------------------------


        public ActionResult ExcluirItemProduto(int id)
        {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");

            var itemProduto = _db.ProdutoHasIngredientes.Single(x => x.IdProdutoHasCategoria == id);
            _db.Remove(itemProduto);
            _db.SaveChanges();
            return RedirectToAction("EditarProduto");
        }

        public ActionResult EditQtdItemProduto(ProdutoEditar pe, int IdE)
        {
            var phi = _db.ProdutoHasIngredientes.Single(g => g.IdProdutoHasCategoria == IdE);

            phi.Quantidade = pe.ProdutoHasIngredientes.Quantidade;
            _db.ProdutoHasIngredientes.Update(phi);
            _db.SaveChanges();
            return RedirectToAction("EditarProduto");
        }

        public ActionResult AdicionarItemPRoduto(ProdutoEditar pe, int idPHI)
        {
            _db.ProdutoHasIngredientes.Add(pe.ProdutoHasIngredientes);
            return RedirectToAction("EditarProduto");
        }
        // -------------------------------------------------------------------------

        //CONTINUARs
        public ActionResult Estoque()
        {
            if (!IsAdmin())
                return RedirectToAction("Login");

            var ingredientes = _db.Ingredientes.ToList();
            double qtd;
            double qtdMax;


            if (ingredientes != null)
            {

                foreach (var item in ingredientes)
                {
                    qtd = item.Quantidade;
                    qtdMax = item.QuantidadeMaxima;

                    if ((qtd / qtdMax) * 100 > 50)
                    {

                    }
                    if ((qtd / qtdMax) * 100 <= 50 && (qtd / qtdMax) * 100 >= 25)
                    {

                    }
                    if ((qtd / qtdMax) * 100 < 25)
                    {

                    }
                }

                ViewData["ingredientes"] = ingredientes.ToList();
            }
            return View();
        }

        // ----------------------------------------------------------------------------------
    }
}