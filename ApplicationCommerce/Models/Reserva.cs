using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCommerce.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        [Required(ErrorMessage = "Informe a data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Informe a hora da reserva")]
        public TimeSpan Hora { get; set; }
        [Required(ErrorMessage = "Informe a quantidade de pessoas para a reserva")]
        public int NumeroPessoas { get; set; }
        //analisar ainda
        public int Mesa { get; set; }

        public Pessoa Pessoa { get; set; }
        public virtual int PessoaId { get; set; }
    }
}
