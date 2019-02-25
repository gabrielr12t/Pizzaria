using System;
using System.IO;
using System.Threading.Tasks;
using ApplicationCommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ApplicationCommerce.Services
{
    public class ImagemUploadService
    {
        public static async Task<string> SalvarImagemPerfil(IFormFile imagem, string cpf)
        {
            try
            {
                string ext = Path.GetExtension(imagem.FileName).ToLower();

                string nomeArquivo = DateTime.Now.ToString("ddMMyyyymmssfff") + ext;

                if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                {
                    return null;
                }
                string caminhoFoto;

                var caminho = $"images/ImagemPerfil/";

                //verificando se tem imagem, se não tiver adiciono uma da pasta
                if (imagem == null || imagem.Length == 0)
                {
                    caminhoFoto = string.Concat("/dist/img/avatar5.png");
                }

                //verificando se o arquivo é foto
                if (imagem.ContentType.IndexOf("image", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    caminhoFoto = string.Concat("/dist/img/avatar5.png");
                }

                //verificando se tem diretorio
                if (!Directory.Exists(string.Concat(@"wwwroot/", caminho)))
                {
                    Directory.CreateDirectory(string.Concat(@"wwwroot/", caminho));
                }

                using (var stream = new FileStream(string.Concat(@"wwwroot/", caminho, nomeArquivo), FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                caminhoFoto = string.Concat("/" + caminho, nomeArquivo);

                return caminhoFoto;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        // upload image produto
        public static async Task<string> SalvarImagemProduto(IFormFile imagem)
        {
            try
            {
                string ext = Path.GetExtension(imagem.FileName).ToLower();

                 string nomeArquivo = DateTime.Now.ToString("ddMMyyyymmssfff") + ext;

                if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                {
                    return null;
                }
                string caminhoFoto;

                var caminho = $"images/ImagemProduto/";

                //verificando se o arquivo é foto
                if (imagem.ContentType.IndexOf("image", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    caminhoFoto = string.Concat("/dist/img/avatar5.png");
                }

                //verificando se tem diretorio
                if (!Directory.Exists(string.Concat(@"wwwroot/", caminho)))
                {
                    Directory.CreateDirectory(string.Concat(@"wwwroot/", caminho));
                }

                using (var stream = new FileStream(string.Concat(@"wwwroot/", caminho, nomeArquivo), FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                caminhoFoto = string.Concat("/" + caminho);

                return caminhoFoto;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }
    }
}