

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDocumentosDDD.MVC.ViewModels
{
    public class UsuarioSystemViewModel
    {
        [Key]
        public int UsuarioSystemId { get; set; }

        [Required(ErrorMessage = "Preencha O Campo Login")]
       // [MaxLength(20, ErrorMessage = "Maximo {0} Caracteres")]
       // [MinLength(4, ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Minimo 4 Caracteres e Maximo 30 Caracteres")]
        public string Login { get; set; }

        [StringLength(30, MinimumLength = 4 ,ErrorMessage = "Minimo 4 Caracteres e Maximo 30 Caracteres")]
        [Required(ErrorMessage = "Preencha O Campo Senha")]
       // [MaxLength(30, ErrorMessage = "Maximo {0} Caracteres")]
       // [MinLength(4, ErrorMessage = "Minimo {0} Caracteres")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar a senha")]
        [Compare("senha", ErrorMessage = "A senha e a confirmação da senha são diferentes")]
        public string ConfirmaPassword { get; set; }

        

        [Required(ErrorMessage = "Preencha O Campo Nivel")]
        [Range(1,2)]
        public int Nivel { get; set; }

        [Required(ErrorMessage = "Preencha O Campo E-Mail")]
      //  [MaxLength(100, ErrorMessage = "Maximo {0} Caracteres")]
       // [MinLength(1,ErrorMessage = "Minimo {0} Caracteres")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Minimo 1 Caracteres e Maximo 100 Caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-Mail Valido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
    }
}