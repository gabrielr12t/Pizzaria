using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using System.IO;
using ApplicationCommerce.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationCommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult exibirPessoas(){
            var users = _db.Pessoas.ToList();
            return View(users);
        }

        //////////////////////// Upload Images //////////////////////////////////////////////////////////////

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(ApplicationDbContext obj, IHostingEnvironment appEnvironment)
        {
            _db = obj;
            _appEnvironment = appEnvironment;
        }


       
        public IActionResult Upload_User_Profil_Image()
        {
             ViewData["imagens"]= _db.Fotos.ToList();
             return View();
        }

        

        // public async Task<Foto> Upload_User_Profil_Image(IFormFile uploaded_File)
        // {
        //     var caminho = $"images/ImagemPerfil/";

        //     Directory.CreateDirectory(string.Concat(@"wwwroot/", caminho));

        //     using (var stream = new FileStream(string.Concat(@"wwwroot/", caminho, uploaded_File.FileName), FileMode.Create))
        //     {
        //         await uploaded_File.CopyToAsync(stream);
        //     }

        //     var imagePerfil = new Foto
        //     {
        //         Caminho = string.Concat(@"~/",caminho, uploaded_File.FileName),                 
        //     };

        //     _db.Add(imagePerfil);

        //     return imagePerfil;
        // }
        [HttpPost]
        public IActionResult Upload_User_Profil_Image(IFormFile uploaded_File)
        {            
             //var pessoaFoto = ImagemUploadService.SalvarImagemPerfil(uploaded_File, _db);
             
            // var img = ImagemUploadService.up(uploaded_File);

            // Foto f = new Foto();
            //  f.Caminho = img;

            // if (img != null)
            // {
            //     _db.Fotos.Add(f);
            //     _db.SaveChanges();
            // }

            //Foto p = new Foto{Caminho = ImagemUploadService.SalvarImagemPerfil(uploaded_File)};
            
            // _db.Fotos.Add(p);
            // _db.SaveChanges();
            //ViewData["imagens"]= _db.Fotos.ToList();
            return View();
        } 
        public IActionResult ListarImagem()
        {
            var imgs = _db.Fotos.ToList();
            return View(imgs);
        }

        // [HttpPost]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Upload_User_Profil_Image(IFormFile uploaded_File)
        // {

        //     if (uploaded_File == null || uploaded_File.Length == 0)
        //     {
        //         ViewData["Error"] = "Nenhuma imgagem selecionada";
        //         return View(ViewData);
        //     }
        //     if (uploaded_File.ContentType.IndexOf("image", StringComparison.OrdinalIgnoreCase) < 0)
        //     {
        //         ViewData["Error"] = "Erro: esse arquivo não é uma imagem";
        //         return View(ViewData);
        //     }

        //     string pastaImagem = "Imagens_Usuarios";

        //     string NomeArquivo = "NOME_DATA_ID.jpg";
        //     //caminho aplicação            
        //     string CaminhoProjeto = _appEnvironment.WebRootPath;

        //     string CaminhoFotos = CaminhoProjeto + "\\Arquivos_Usuarios\\" + pastaImagem + "\\";

        //     string CaminhoCompleto = CaminhoFotos + NomeArquivo;

        //     if (!Directory.Exists(CaminhoCompleto))
        //     {
        //         Directory.CreateDirectory(CaminhoCompleto);
        //     }
        //     using (var stream = new FileStream(CaminhoCompleto, FileMode.Create))
        //     {
        //         await uploaded_File.CopyToAsync(stream);
        //     }

        //     ViewData["FileUploaded"] = CaminhoCompleto;

        //     return View();
        // }

        
         public ActionResult teste()
         {
             ViewBag.Ing = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");
             return View();
         }
         [HttpPost]
        public ActionResult teste(int id)
         {
             ViewBag.Ing = new SelectList(_db.Ingredientes.ToList(), "IdIngrediente", "Nome");
             return View();
         }


        
        public JsonResult pesquisarpreco(double Preco)
        {                               
            var prods = _db.Produtos.Where(a => a.ValorAtual <= Preco).ToList();
            return Json(prods);
        }
    }    
}
