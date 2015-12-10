

using System;

namespace ProjetoModeloDocumentosDDD.Domain.Entites
{
  public  class Rg 
    {
        public int RgId { get; set; }

        public string NomeDaPessoCompleto { get; set; }  

        public string NomeMae { get; set; }

        public string NomePai { get; set; }

        public DateTime Datanascimento { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}
