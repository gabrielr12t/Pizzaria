using ApplicationCommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.ViewModel
{
    public class PessoaEndereco
    {
        public Pessoa Pessoa { get; set; }
        public IFormFile UploadedImage { get; set; }
        public Endereco Endereco { get; set; }
    }
}
