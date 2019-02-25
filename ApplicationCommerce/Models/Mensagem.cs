using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCommerce.Models
{
    public class Mensagem
    {
        [Key]
        public int IdMensagem { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Conteudo { get; set; }

        public DateTime Data { get; set; }

        public int Visualizada { get; set; }//1 = visualizada , 0 = ñ visualizada


        public Pessoa Pessoa { get; set; }
        public virtual int PessoaId { get; set; }
    }
}
