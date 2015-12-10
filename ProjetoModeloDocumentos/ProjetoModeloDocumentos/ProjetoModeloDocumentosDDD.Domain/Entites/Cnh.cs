

using System;

namespace ProjetoModeloDocumentosDDD.Domain.Entites
{
   public class Cnh
    {
        public int CnhId { get; set; }

        public string NomeDaPessoaCompleto { get; set; }
            
        public string NomeMae { get; set; }

        public string NomePai { get; set; }

        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
