

using System;

namespace ProjetoModeloDocumentosDDD.Domain.Entites
{
   public class Cpf
    {
        public int CpfId { get; set; }


        public string NomeDaPessoaCompleto { get; set; }

        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        
    }
}
