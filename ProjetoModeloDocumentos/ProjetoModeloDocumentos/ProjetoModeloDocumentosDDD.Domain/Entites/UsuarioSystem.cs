

using System;

namespace ProjetoModeloDocumentosDDD.Domain.Entites
{
   public class UsuarioSystem
    {
        public int UsuarioSystemId { get; set; }

        public string Login { get; set; }

        public string senha { get; set; }

        public int Nivel { get; set; }

        public string Email { get; set; }
    }
}
