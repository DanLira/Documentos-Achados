

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace ProjetoModeloDocumentosDDD.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha O Campo Nome")]
       // [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        //[MinLength(3 , ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Preencha O Campo SobreNome")]
       // [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
       // [MinLength(3, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimo 3 Caracteres e Maximo 30 Caracteres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Preencha O Campo CPF")]
       // [MaxLength(11, ErrorMessage = "Maximo {0} Caracteres")]
      //  [MinLength(11, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Minimo 11 Caracteres e Maximo 11 Caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha O Campo E-Mail")]
      //  [MaxLength(100, ErrorMessage = "Maximo {0} Caracteres")]
      //  [EmailAddress(ErrorMessage = "Preencha um E-Mail Valido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Minimo 1 Caracteres e Maximo 100 Caracteres")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha O Campo Cep")]
        [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O código postal deverá estar no formato 00000000 ou 00000-000")]
      //  [MaxLength(12, ErrorMessage = "Maximo {0} Caracteres")]
       // [MinLength(5, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Minimo 5 Caracteres e Maximo 12 Caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha O Campo Login")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Minimo 4 Caracteres e Maximo 30 Caracteres")]
        public string Login { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Minimo 4 Caracteres e Maximo 30 Caracteres")]
        [Required(ErrorMessage = "Preencha O Campo Senha")]
        // [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
        // [MinLength(4, ErrorMessage = "Minimo {0} Caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar a senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação da senha são diferentes")]
        public string ConfirmaPassword { get; set; }


        [Required(ErrorMessage = "Preencha O Campo Telefone")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Minimo 8 Caracteres e Maximo 12 Caracteres")]
        public string Telefone { get; set; }

        public bool Bloquear { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<RgViewModel> Rgs { get; set; }

        public virtual IEnumerable<CpfViewModel> Cpfs { get; set; }

        public virtual IEnumerable<CnhViewModel> Cnhs { get; set; }
    }
}