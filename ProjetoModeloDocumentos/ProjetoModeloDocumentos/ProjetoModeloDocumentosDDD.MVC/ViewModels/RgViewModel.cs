

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDocumentosDDD.MVC.ViewModels
{
    public class RgViewModel
    {
        [Key]
        public int RgId { get; set; }

        [DisplayName("Nome Completo Da Pessoa")]
        [Required(ErrorMessage = "Preencha O Campo Nome Completo Da Pessoa",AllowEmptyStrings = false)]
       // [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
       // [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        public string NomeDaPessoCompleto { get; set; }

        [DisplayName("Nome da Mãe")]
        [Required(ErrorMessage = "Preencha O Campo Nome Da Mãe")]
      //  [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
      //  [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
        public string NomeMae { get; set; }

        [DisplayName("Nome do Pai")]
        [Required(ErrorMessage = "Preencha O Campo Nome do Pai")]
        //[MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        //[MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
        public string NomePai { get; set; }

        [DisplayName("Data De Nascimento")]
        [Required(ErrorMessage = "Preencha O Campo Data De Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
    }
}