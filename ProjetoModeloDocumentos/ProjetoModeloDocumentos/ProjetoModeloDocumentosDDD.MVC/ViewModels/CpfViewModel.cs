

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDocumentosDDD.MVC.ViewModels
{
    public class CpfViewModel
    {
        [Key]
        public int CpfId { get; set; }

        [DisplayName("Nome Completo Da Pessoa")]
        [Required(ErrorMessage = "Preencha O Campo Nome Completo da Pessoa")]
        //[MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        //[MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
        public string NomeDaPessoaCompleto { get; set; }

        [DisplayName("Data De Nascimento")]
        [Required(ErrorMessage = "Preencha O Campo Data De Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
    }
}