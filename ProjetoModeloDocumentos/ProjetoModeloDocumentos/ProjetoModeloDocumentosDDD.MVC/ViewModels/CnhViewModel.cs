

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDocumentosDDD.MVC.ViewModels
{
    public class CnhViewModel
    {
        [Key]
        public int CnhId { get; set; }

        [DisplayName("Nome Completo Da Pessoa")]
        [Required(ErrorMessage = "Preencha O Campo Nome Completo Da Pessoa")]
        [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        public string NomeDaPessoaCompleto { get; set; }

        [DisplayName("Nome da Mãe")]
        [Required(ErrorMessage = "Preencha O Campo Nome da Mãe")]
        [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        public string NomeMae { get; set; }

        [DisplayName("Nome do Pai")]
        [Required(ErrorMessage = "Preencha O Campo Nome do Pai")]
        [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        public string NomePai { get; set; }

        [DisplayName("Data De Nascimento")]
        [Required(ErrorMessage = "Preencha O Campo Data De Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
    }
}