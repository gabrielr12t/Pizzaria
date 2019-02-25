using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace ApplicationCommerce.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        [DisplayName("Nome: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Sobrenome: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sobrenome { get; set; }

        [DisplayName("CPF: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }

        [DisplayName("Data nascimento: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }


        public DateTime? DataCadastro { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [DisplayName("Senha: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DisplayName("Telefone: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [DisplayName("Celular: ")]
        public string Celular { get; set; }

        public int? StatusCadastro { get; set; }// 1 = ativo , 0 = inativo
        
        public string CaminhoFoto { get; set; }

               
        public int? PermissaoCadastro { get; set; }// 1 = permitido, 0 = não permitido

        public string ChaveRecuperacaoSenha { get; set; }


        public TipoPessoa TipoPessoa { get; set; }
        public virtual int TipoPessoaId { get; set; }
    }
}
