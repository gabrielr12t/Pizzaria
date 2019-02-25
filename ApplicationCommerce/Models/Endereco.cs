using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        public string Referencia { get; set; }


        public Pessoa Pessoa { get; set; }
        public virtual int PessoaId { get; set; }
    }
}
