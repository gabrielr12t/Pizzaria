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
using Newtonsoft.Json;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ApplicationCommerce.Controllers {
    public class AdministrativaController : Controller {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _enviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Pessoa _pessoa { get; set; }
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AdministrativaController (ApplicationDbContext obj, IHostingEnvironment i, IHttpContextAccessor httpContextAccessor) {
            _db = obj;
            _enviroment = i;
            _httpContextAccessor = httpContextAccessor;

            //verifica login
            var session = _session.GetInt32 ("ID");
            _pessoa = session != null ? _db.Pessoas.Single (c => c.IdPessoa == session) : null;
        }

        // verificando admin
        public bool IsAdmin () {
            if (_pessoa != null)
                return _pessoa.TipoPessoaId == 1 ? true : false;
            return false;
        }

        public ActionResult Index () {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");

            return View ();
        }

        // -----------------------------------------------------------------------------------------------------------
        public IActionResult Cadastro () {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");

            // ----- verificando admin

            ViewBag.Tipo = new SelectList (_db.TipoPessoas.ToList (), "IdTipoPessoa", "Nome");
            return View ();
        }

        [HttpPost]
        public IActionResult Cadastro (PessoaEndereco p, IFormFile img) {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");

            ViewBag.Tipo = new SelectList (_db.TipoPessoas.ToList (), "IdTipoPessoa", "Nome");

            string nome = p.Pessoa.Nome;
            string email = p.Pessoa.Email;
            string assunto = "Cadastro efetuado com sucesso!!!";
            string corpo = "Olá senhor " + nome + @", seu cadastro foi efetuado em nosso sistema web para pedidos. Aproveite e receba ofertas com muito desconto.";
            bool enviou;
            if (ModelState.IsValid) {

                enviou = EmailService.SendEmail (nome, email, assunto, corpo);

                if (!enviou) {
                    ViewData["Email"] = "não enviado";
                    return View ();
                }
                ViewData["Email"] = null;

                string senha = Criptografia.CriptografiaSenha (p.Pessoa.Senha);
                try {
                    _db.Pessoas.Add (p.Pessoa);

                    p.Pessoa.DataCadastro = DateTime.Now;
                    p.Pessoa.PermissaoCadastro = 0;
                    p.Pessoa.StatusCadastro = 1;
                    p.Pessoa.Senha = senha;

                    Task<string> tarefa = ImagemUploadService.SalvarImagemPerfil (img, p.Pessoa.Cpf);

                    if (tarefa.Result == null) {
                        p.Pessoa.CaminhoFoto = string.Concat ("/dist/img/avatar5.png");
                    } else {
                        p.Pessoa.CaminhoFoto = tarefa.Result;
                    }

                    _db.Enderecos.Add (p.Endereco);
                    p.Endereco.PessoaId = p.Pessoa.IdPessoa;

                    _db.SaveChanges ();
                    ModelState.Clear ();
                } catch {
                    return View (p.Pessoa);
                }
            }
            return View ();
        }

        // ----------------------------------------------------------------------------------------------------------------

        public ActionResult Login () {
            return View ();
        }

        [HttpPost]
        public ActionResult Login (Pessoa p) {
            string senha = Criptografia.CriptografiaSenha (p.Senha);

            var em = _db.Pessoas.Where (j => j.Email == p.Email.ToLower ()).FirstOrDefault ();

            var pes = _db.Pessoas.Where (u => u.Email.Equals (p.Email.ToLower ()) && u.Senha.Equals (senha)).FirstOrDefault ();
            if (em != null) {
                if (pes != null) {
                    _session.SetInt32 ("ID", pes.IdPessoa);
                    return RedirectToAction ("Index");
                } else {
                    ModelState.AddModelError ("", "Senha incorreta");
                }
            } else {
                ModelState.Clear ();
                ModelState.AddModelError ("", "Usuário não possui cadastro");
            }
            return View ();
        }
        // ------------------------------------------------------------------------------------------------
        public ActionResult RecuperarSenha () {

            return View ();
        }

        [HttpPost]
        public ActionResult RecuperarSenha (Pessoa p) {
            var pes = _db.Pessoas.SingleOrDefault (e => e.Email.Equals (p.Email.ToLower ()));

            if (pes != null) {
                string senha = GerarSenhaService.SenhaHash ();
                string nome = pes.Nome;
                string email = pes.Email;
                string assunto = "Recuperação de senha";
                string corpo = "Olá senhor " + pes.Nome + @", Recomendamos que troque sua senha nas configurações<br/><strong>Sua nova senha:</strong><p  style='font-size:16px'> " + senha + " </p>";
                bool enviou = EmailService.SendEmail (nome, email, assunto, corpo);
                if (enviou) {
                    string newSenha = Criptografia.CriptografiaSenha (senha);
                    ViewData["Enviou"] = "enviou";
                    var newPessoa = _db.Pessoas.Where (x => x.Email.Equals (p.Email)).FirstOrDefault ();
                    newPessoa.Senha = newSenha;
                    _db.SaveChanges ();
                    ModelState.Clear ();
                    return View ();
                } else {
                    ViewData["Enviou"] = "erro";
                    return View ();
                }
            } else {
                ModelState.Clear ();
                ViewData["Erro"] = "erro";
                return View ();
            }
        }

        //--------------------------------------------------------------------------------------------
        public ActionResult CadastrarIngrediente () {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            var lista = _db.Ingredientes.ToList ();

            if (lista.Count != 0) {
                ViewData["Lista"] = lista.OrderBy (c => c.Nome).ToList ();
            }
            return View ();
        }

        [HttpPost]
        public ActionResult CadastrarIngrediente (CadastrarEditarIngredientes i) {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            if (ModelState.IsValid) {
                //var ing = new Ingrediente { Nome = i.Ingredientes.Nome, DataAdicao = DateTime.Now, PrecoQuilo = i.Ingredientes.PrecoQuilo, Quantidade = i.Ingredientes.Quantidade, QuantidadeMaxima = i.Ingredientes.QuantidadeMaxima };
                _db.Ingredientes.Add (i.Ingredientes);
                i.Ingredientes.DataAdicao = DateTime.Now;
                _db.SaveChanges ();
                ModelState.Clear ();
            }

            var lista = _db.Ingredientes.ToList ();

            if (lista.Count != 0) {
                ViewData["Lista"] = lista.OrderBy (c => c.Nome).ToList ();
            }
            return View ();
        }

        [HttpPost]
        public ActionResult EditarIngrediente (string IdE, CadastrarEditarIngredientes ingrediente, string qtdAlterar, string Btn) {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            int id = int.Parse (IdE);
            var ing = _db.Ingredientes.Single (g => g.IdIngrediente == id);

            double qtdBanco = ing.Quantidade;
            double qtdAltera = double.Parse (qtdAlterar);

            bool alterado = false;

            switch (Btn) {
                case "Adicionar":
                    if (ing != null && ModelState.IsValid) {
                        ing.Nome = ingrediente.IngredienteEdit.Nome;
                        ing.Quantidade = qtdBanco + qtdAltera;
                        ing.PrecoQuilo = ingrediente.IngredienteEdit.PrecoQuilo;
                        ing.QuantidadeMaxima = ingrediente.IngredienteEdit.QuantidadeMaxima;
                        ing.DataAdicao = DateTime.Now;
                        _db.Ingredientes.Update (ing);
                        _db.SaveChanges ();
                        alterado = true;
                    }
                    break;
                case "Remover":
                    if (ing != null && ModelState.IsValid) {
                        ing.Nome = ingrediente.IngredienteEdit.Nome;
                        ing.Quantidade = qtdBanco - qtdAltera;
                        ing.PrecoQuilo = ingrediente.IngredienteEdit.PrecoQuilo;
                        ing.QuantidadeMaxima = ingrediente.IngredienteEdit.QuantidadeMaxima;
                        ing.DataAdicao = DateTime.Now;
                        _db.Ingredientes.Update (ing);
                        _db.SaveChanges ();
                        alterado = true;
                    }
                    break;
            }
            if (alterado) {
                ViewData["Alterado"] = "s";
            }
            return RedirectToAction ("CadastrarIngrediente");
        }
        public ActionResult ExcluirIngrediente (int Id) {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            var ing = _db.Ingredientes.FirstOrDefault (x => x.IdIngrediente == Id);
            if (ing != null) {
                _db.Remove (ing);
                _db.SaveChanges ();
            }

            return RedirectToAction ("CadastrarIngrediente");
        }

        // ----------------------------------------------------------------------------------------------

        public ActionResult CadastrarCategoria () {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            var cats = _db.Categorias.ToList ();

            if (cats.Count != 0) {
                ViewData["categorias"] = cats;
            }
            return View ();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria (Categoria cat) {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");
            // ----- verificando admin

            if (ModelState.IsValid) {
                _db.Categorias.Add (cat);
                _db.SaveChanges ();

                var cats = _db.Categorias.ToList ();
                if (cats.Count != 0) {
                    ViewData["categorias"] = cats;
                }
                ModelState.Clear ();
                return View ();
            }
            return View ();

        }
        public ActionResult ExcluirCategoria (int id) {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");
            // // ----- verificando admin

            var ing = _db.Categorias.Single (x => x.IdCategoria == id);
            _db.Remove (ing);
            _db.SaveChanges ();
            return RedirectToAction ("CadastrarCategoria");
        }

        // ------------------------------------------------------------------------
        [HttpGet]
        public ActionResult CadastrarProduto () {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");
            // // ----- verificando admin

            ViewBag.Ingredientes = _db.Ingredientes.ToList ();
            ViewBag.VerificaCategoria = _db.Categorias.ToList ();
            ViewBag.Categoria = new SelectList (_db.Categorias.ToList (), "IdCategoria", "Nome");
            return View ();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CadastrarProduto (Produto Produto, List<ProdutoRecebeIngredientes> Ingredientes) {
            // if (!IsAdmin())
            //     return RedirectToAction("Login");
            // ----- verificando admin

            if (ModelState.IsValid) {
                _db.Produtos.Add (Produto);
                //Task<string> task = ImagemUploadService.SalvarImagemProduto(Foto);
                // Prod.Foto = task.Result;
                _db.SaveChanges ();
                foreach (var ings in Ingredientes) {
                    var prodHasIng = new ProdutoHasIngrediente ();
                    prodHasIng.IngredienteId = Convert.ToInt32 (ings.idIng);
                    prodHasIng.ProdutoId = Produto.IdProduto;
                    prodHasIng.Quantidade = ings.quantidadeIng;
                    _db.ProdutoHasIngredientes.Add (prodHasIng);
                    _db.SaveChanges ();
                }

            } else {
                ViewBag.Ingredientes = _db.Ingredientes.ToList ();
                ViewBag.VerificaCategoria = _db.Categorias.ToList ();
                ViewBag.Categoria = new SelectList (_db.Categorias.ToList (), "IdCategoria", "Nome");
                return Json (Produto);
            }
            ViewBag.Ingredientes = _db.Ingredientes.ToList ();
            ViewBag.VerificaCategoria = _db.Categorias.ToList ();
            ViewBag.Categoria = new SelectList (_db.Categorias.ToList (), "IdCategoria", "Nome");

            //ModelState.Clear ();
            return Json (Produto);
        }

        public ActionResult SalvarFoto (int Id, IFormFile files) {
            if (Id != 0) {
                var produto = _db.Produtos.Single (c => c.IdProduto == Id);
                produto.Foto = "foto";
                _db.SaveChanges ();
                return Json (produto);
            } else {
                return Json (null);
            }
        }

        public JsonResult RecebeIdProduto (int Id) {
            var prods = _db.Produtos.Where (c => c.CategoriaId == Id).ToList ();
            return Json (prods);
        }
        // -------------------------------------------------------------------------

        [HttpGet]
        public ActionResult EditarProduto () {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");~

            var prods = (from p in _db.Produtos join phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId into pGroup from phi in pGroup.DefaultIfEmpty () join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente into iGroup from i in iGroup.DefaultIfEmpty () select new {
                proId = p.IdProduto,
                    proNome = p.Nome,
                    proIngrediente = i.Nome == null ? "Sem ingrediente" : i.Nome,
                    proHasQuantidade = phi.Quantidade == null ? 0 : phi.Quantidade,
                    proHasIngProId = phi.ProdutoId == null ? 0 : phi.ProdutoId,
                    proHasIngId = phi.IdProdutoHasCategoria == null ? 0 : phi.IdProdutoHasCategoria,
                    idIngredienteHas = phi.IngredienteId == null ? 0 : phi.IngredienteId,
                    idIngrediente = i.IdIngrediente == null ? 0 : i.IdIngrediente
            }).ToList ();

            var listaProEdit = new List<ProdutoEditar> ();
            foreach (var item in prods) {
                ProdutoEditar pe = new ProdutoEditar ();
                pe.Produtos = new Produto ();
                pe.Ingredientes = new Ingrediente ();
                pe.ProdutoHasIngredientes = new ProdutoHasIngrediente ();
                pe.Produtos.IdProduto = item.proId;
                pe.Produtos.Nome = item.proNome;
                pe.Ingredientes.Nome = item.proIngrediente;
                pe.ProdutoHasIngredientes.Quantidade = item.proHasQuantidade;
                pe.ProdutoHasIngredientes.ProdutoId = item.proHasIngProId;
                pe.ProdutoHasIngredientes.IdProdutoHasCategoria = item.proHasIngId;
                pe.ProdutoHasIngredientes.IngredienteId = item.idIngrediente;
                pe.Ingredientes.IdIngrediente = item.idIngrediente;
                listaProEdit.Add (pe);
            }

            //ViewBag.Ingrediente = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");

            if (listaProEdit != null) {
                ViewBag.Produtos = listaProEdit.ToList ();
                ViewBag.Ingredientes = _db.Ingredientes.ToList ();
            }
            return View ();
        }

        [HttpPost]
        public ActionResult EditarProduto (ProdutoHasIngrediente phin) {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");

            var prods = (from p in _db.Produtos join phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId into pGroup from phi in pGroup.DefaultIfEmpty () join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente into iGroup from i in iGroup.DefaultIfEmpty () select new {
                proId = p.IdProduto,
                    proNome = p.Nome,
                    proIngrediente = i.Nome == null ? "Sem ingrediente" : i.Nome,
                    proHasQuantidade = phi.Quantidade == null ? 0 : phi.Quantidade,
                    proHasIngProId = phi.ProdutoId == null ? 0 : phi.ProdutoId,
                    proHasIngId = phi.IdProdutoHasCategoria == null ? 0 : phi.IdProdutoHasCategoria,
                    idIngredienteHas = phi.IngredienteId == null ? 0 : phi.IngredienteId,
                    idIngrediente = i.IdIngrediente == null ? 0 : i.IdIngrediente
            }).ToList ();

            var listaProEdit = new List<ProdutoEditar> ();

            foreach (var item in prods) {
                ProdutoEditar pe = new ProdutoEditar ();
                pe.Produtos = new Produto ();
                pe.Ingredientes = new Ingrediente ();
                pe.ProdutoHasIngredientes = new ProdutoHasIngrediente ();

                pe.Produtos.IdProduto = item.proId;
                pe.Produtos.Nome = item.proNome;
                pe.Ingredientes.Nome = item.proIngrediente;
                pe.ProdutoHasIngredientes.Quantidade = item.proHasQuantidade;
                pe.ProdutoHasIngredientes.ProdutoId = item.proHasIngProId;
                pe.ProdutoHasIngredientes.IdProdutoHasCategoria = item.proHasIngId;
                pe.ProdutoHasIngredientes.IngredienteId = item.idIngrediente;
                pe.Ingredientes.IdIngrediente = item.idIngrediente;
                listaProEdit.Add (pe);
            }

            //ViewBag.Ingrediente = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");

            if (listaProEdit != null) {
                ViewBag.Produtos = listaProEdit.ToList ();
            }
            return View ();
        }

        //------------------------------------------------------------------------------------------------------

        public ActionResult ExcluirItemProduto (int id) {
            //if (!IsAdmin())
            //    return RedirectToAction("Login");

            var itemProduto = _db.ProdutoHasIngredientes.Single (x => x.IdProdutoHasCategoria == id);
            _db.Remove (itemProduto);
            _db.SaveChanges ();
            return RedirectToAction ("EditarProduto");
        }

        public ActionResult EditQtdItemProduto (ProdutoEditar pe, int IdE) {
            var phi = _db.ProdutoHasIngredientes.Single (g => g.IdProdutoHasCategoria == IdE);

            phi.Quantidade = pe.ProdutoHasIngredientes.Quantidade;
            _db.ProdutoHasIngredientes.Update (phi);
            _db.SaveChanges ();
            return RedirectToAction ("EditarProduto");
        }

        [HttpPost]
        public ActionResult AdicionarItemPRoduto (int IdProduct, ProdutoEditar pe) {
            ProdutoHasIngrediente p = new ProdutoHasIngrediente ();
            p.IngredienteId = pe.ProdutoHasIngredientes.Ingrediente.IdIngrediente;
            p.ProdutoId = IdProduct;
            p.Quantidade = pe.ProdutoHasIngredientes.Quantidade;
            _db.ProdutoHasIngredientes.Add (p);
            _db.SaveChanges ();
            return RedirectToAction ("EditarProduto");
        }
        // -------------------------------------------------------------------------

        //CONTINUARs
        public ActionResult Estoque () {
            // if (!IsAdmin ())
            //     return RedirectToAction ("Login");

            var ingredientes = _db.Ingredientes.ToList ();
            double qtd;
            double qtdMax;

            if (ingredientes != null) {

                foreach (var item in ingredientes) {
                    qtd = item.Quantidade;
                    qtdMax = item.QuantidadeMaxima;

                    if ((qtd / qtdMax) * 100 > 50) {

                    }
                    if ((qtd / qtdMax) * 100 <= 50 && (qtd / qtdMax) * 100 >= 25) {

                    }
                    if ((qtd / qtdMax) * 100 < 25) {

                    }
                }

                ViewData["ingredientes"] = ingredientes.ToList ();
            }
            return View ();
        }

        // ----------------------------------------------------------------------------------  
        public IActionResult teste () {
            ViewBag.FormaEntrega = new SelectList (_db.FormaEnvios.ToList (), "IdFormaEnvio", "Nome");
            ViewBag.Categorias = _db.Categorias.ToList ();
            return View ();
        }

        [HttpPost]
        public IActionResult CarregarProdutos (int Id) {

            var prods = (from p in _db.Produtos join phi in _db.ProdutoHasIngredientes on p.IdProduto equals phi.ProdutoId into phiGroup from phi in phiGroup.DefaultIfEmpty () join i in _db.Ingredientes on phi.IngredienteId equals i.IdIngrediente into iGroup from i in iGroup.DefaultIfEmpty () where p.CategoriaId == Id select new {
                IdProduto = p.IdProduto,
                    categoria = p.Categoria.Nome,
                    nome = p.Nome,
                    ingrediente = i.Nome == null ? "Sem ingrediente" : i.Nome,
                    preco = p.ValorAtual
            }).ToList ();

            return Json (prods);
        }

        [HttpPost]
        public IActionResult FinalizarPedido (string Telefone, List<ProdutoCarrinho> Carrinho) {

            var user = (from p in _db.Pessoas join e in _db.Enderecos on p.IdPessoa equals e.PessoaId where p.Telefone == Telefone || p.Celular == Telefone select new {
                IdPessoa = p.IdPessoa,
                    Nome = p.Nome,
                    Cep = e.Cep,
                    Rua = e.Rua,
                    Bairro = e.Bairro,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Numero = e.Numero,
                    Referencia = e.Referencia
            }).ToList ();
            int cont = user.Count;

            if (cont == 0) {
                return Json (null);
            }
            //var entrega = _db.FormaEnvios.SingleOrDefault (c => c.IdFormaEnvio == envio);

            double total = 0;

            foreach (var item in Carrinho) {
                total += item.valor * item.quantidade;
            }
            //total += entrega.Valor;

            //buscando cliente e verificando se ele está cadastrado
            Fila fila = new Fila ();
            var f = _db.Filas.LastOrDefault ();

            fila.Posicao = f != null ? f.Posicao + 1 : 1;

            Pedido pedido = new Pedido ();
            pedido.Data = DateTime.Now;
            //pedido.FormaEnvioId = envio;
            pedido.Status = 0;
            pedido.ValorTotal = total;
            pedido.Avaliacao = "";
            pedido.PessoaId = user[0].IdPessoa;
            pedido.Fila = fila;
            _db.Pedidos.Add (pedido);

            HistoricoCompra hc = new HistoricoCompra ();
            hc.PedidoId = pedido.IdPedido;
            hc.DataCompra = DateTime.Now;
            hc.Total = total;
            _db.HistoricoCompras.Add (hc);

            //atualizando estoque
            string nome = "";
            bool passou = true;
            Item itens;
            //cadastrando item e somando o total;
            foreach (var item in Carrinho) {

                itens = new Item ();
                //var prodHas = _db.ProdutoHasIngredientes.Where (x => x.ProdutoId == item.id).Include(_db.Produtos ).ToList ();
                var prods = (from phi in _db.ProdutoHasIngredientes join p in _db.Produtos on phi.ProdutoId equals p.IdProduto where phi.ProdutoId == item.id select new {
                    produto = p.Nome,
                        gastoIngrediente = phi.Quantidade,
                        tempoProduzir = p.TempoProduzir,
                        idIngrediente = phi.IngredienteId
                }).ToList ();
                if (passou) {
                    passou = false;
                    foreach (var item2 in prods) {
                        if (item2.produto != nome) {
                            nome = item2.produto;
                            fila.TempoParaFinalizar += item2.tempoProduzir * item.quantidade;
                        }
                        var ing = _db.Ingredientes.SingleOrDefault (x => x.IdIngrediente == item2.idIngrediente);
                        ing.Quantidade -= Convert.ToDouble (item2.gastoIngrediente) * item.quantidade;
                        _db.Update (ing);
                        if (item2 == prods.Last ()) {
                            passou = true;
                        }
                    }
                }

                itens.PedidoId = pedido.IdPedido;
                itens.ProdutoId = item.id;
                itens.Quantidade = item.quantidade;
                _db.Items.Add (itens);
                _db.SaveChanges ();
            }
            _db.Filas.Add (fila);
            return Json (user);

        }
    }
}