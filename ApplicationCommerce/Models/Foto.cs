using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCommerce.Models
{
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }
        [Required(ErrorMessage = "Insira uma imagem")]
        public byte[] Caminho { get; set; }
        
    }
}
