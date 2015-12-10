

using System;
using System.Collections.Generic;
namespace ProjetoModeloDocumentosDDD.Domain.Entites
{
   public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Cep { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public bool Bloquear { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<Rg> Rgs { get; set; }

        public virtual IEnumerable<Cpf> Cpfs { get; set; }

        public virtual IEnumerable<Cnh> Cnhs { get; set; }
    }
}
